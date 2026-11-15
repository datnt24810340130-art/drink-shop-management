using System.Data;
using DrinkShop.DAL.Database;
using DrinkShop.DTO;
using Microsoft.Data.SqlClient;

namespace DrinkShop.DAL;

public sealed class NhanVienDAL
{
    private const string SelectNhanVienSql = """
        SELECT nv.MaNV, nv.HoTen, nv.SoDienThoai, nv.Email, nv.MaTaiKhoan,
               tk.TenDangNhap, tk.MaQuyen, q.TenQuyen, tk.TrangThai
        FROM dbo.NhanVien AS nv
        INNER JOIN dbo.TaiKhoan AS tk ON tk.MaTaiKhoan = nv.MaTaiKhoan
        INNER JOIN dbo.Quyen AS q ON q.MaQuyen = tk.MaQuyen
        """;

    public DataTable GetAllNhanVien()
    {
        return DatabaseHelper.ExecuteDataTable(SelectNhanVienSql + " ORDER BY nv.MaNV;");
    }

    public DataTable SearchNhanVien(string keyword)
    {
        const string sql = SelectNhanVienSql + " WHERE nv.HoTen LIKE @keyword OR nv.SoDienThoai LIKE @keyword OR tk.TenDangNhap LIKE @keyword ORDER BY nv.MaNV;";
        return DatabaseHelper.ExecuteDataTable(sql,
        [new SqlParameter("@keyword", SqlDbType.NVarChar, 150) { Value = $"%{keyword.Trim()}%" }]);
    }

    public DataTable GetAllQuyen()
    {
        return DatabaseHelper.ExecuteDataTable("SELECT MaQuyen, TenQuyen FROM dbo.Quyen ORDER BY MaQuyen;");
    }

    public bool IsUsernameTaken(string username, int exceptMaTaiKhoan = 0)
    {
        const string sql = "SELECT COUNT(1) FROM dbo.TaiKhoan WHERE TenDangNhap = @username AND MaTaiKhoan <> @maTaiKhoan;";
        object? result = DatabaseHelper.ExecuteScalar(sql,
        [
            new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = username.Trim() },
            new SqlParameter("@maTaiKhoan", SqlDbType.Int) { Value = exceptMaTaiKhoan }
        ]);
        return Convert.ToInt32(result) > 0;
    }

    public void InsertNhanVien(NhanVienDTO nhanVien, TaiKhoanDTO taiKhoan)
    {
        using var connection = DatabaseHelper.GetConnection();
        using SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            const string accountSql = "INSERT INTO dbo.TaiKhoan(TenDangNhap, MatKhau, MaQuyen, TrangThai) OUTPUT INSERTED.MaTaiKhoan VALUES (@username, @password, @role, @active);";
            using var accountCommand = new SqlCommand(accountSql, connection, transaction);
            accountCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = taiKhoan.TenDangNhap.Trim() });
            accountCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64) { Value = DatabaseHelper.HashPassword(taiKhoan.MatKhau) });
            accountCommand.Parameters.Add(new SqlParameter("@role", SqlDbType.Int) { Value = taiKhoan.MaQuyen });
            accountCommand.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit) { Value = taiKhoan.TrangThai });
            int maTaiKhoan = Convert.ToInt32(accountCommand.ExecuteScalar());

            const string employeeSql = "INSERT INTO dbo.NhanVien(HoTen, SoDienThoai, Email, MaTaiKhoan) VALUES (@hoTen, @phone, @email, @maTaiKhoan);";
            using var employeeCommand = new SqlCommand(employeeSql, connection, transaction);
            employeeCommand.Parameters.Add(new SqlParameter("@hoTen", SqlDbType.NVarChar, 100) { Value = nhanVien.HoTen.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 15) { Value = nhanVien.SoDienThoai.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = nhanVien.Email.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@maTaiKhoan", SqlDbType.Int) { Value = maTaiKhoan });
            employeeCommand.ExecuteNonQuery();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool UpdateNhanVien(NhanVienDTO nhanVien)
    {
        using var connection = DatabaseHelper.GetConnection();
        using SqlTransaction transaction = connection.BeginTransaction();
        try
        {
            const string employeeSql = "UPDATE dbo.NhanVien SET HoTen = @hoTen, SoDienThoai = @phone, Email = @email WHERE MaNV = @maNV;";
            using var employeeCommand = new SqlCommand(employeeSql, connection, transaction);
            employeeCommand.Parameters.Add(new SqlParameter("@hoTen", SqlDbType.NVarChar, 100) { Value = nhanVien.HoTen.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@phone", SqlDbType.VarChar, 15) { Value = nhanVien.SoDienThoai.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 100) { Value = nhanVien.Email.Trim() });
            employeeCommand.Parameters.Add(new SqlParameter("@maNV", SqlDbType.Int) { Value = nhanVien.MaNV });
            int employeeRows = employeeCommand.ExecuteNonQuery();
            if (employeeRows == 0)
            {
                transaction.Rollback();
                return false;
            }

            const string accountSql = """
                UPDATE dbo.TaiKhoan
                SET TenDangNhap = @username, MaQuyen = @role, TrangThai = @active,
                    MatKhau = CASE WHEN @password = '' THEN MatKhau ELSE @password END
                WHERE MaTaiKhoan = @maTaiKhoan;
                """;
            using var accountCommand = new SqlCommand(accountSql, connection, transaction);
            accountCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = nhanVien.TenDangNhap.Trim() });
            accountCommand.Parameters.Add(new SqlParameter("@role", SqlDbType.Int) { Value = nhanVien.MaQuyen });
            accountCommand.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit) { Value = nhanVien.TrangThai });
            string passwordHash = string.IsNullOrWhiteSpace(nhanVien.MatKhau) ? string.Empty : DatabaseHelper.HashPassword(nhanVien.MatKhau);
            accountCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64) { Value = passwordHash });
            accountCommand.Parameters.Add(new SqlParameter("@maTaiKhoan", SqlDbType.Int) { Value = nhanVien.MaTaiKhoan });
            int accountRows = accountCommand.ExecuteNonQuery();
            if (accountRows == 0)
            {
                transaction.Rollback();
                return false;
            }

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public bool DoiTrangThai(int maNV, int trangThai)
    {
        const string sql = "UPDATE tk SET TrangThai = @trangThai FROM dbo.TaiKhoan AS tk INNER JOIN dbo.NhanVien AS nv ON nv.MaTaiKhoan = tk.MaTaiKhoan WHERE nv.MaNV = @maNV;";
        return DatabaseHelper.ExecuteNonQuery(sql,
        [
            new SqlParameter("@trangThai", SqlDbType.Bit) { Value = trangThai != 0 },
            new SqlParameter("@maNV", SqlDbType.Int) { Value = maNV }
        ]) > 0;
    }
}

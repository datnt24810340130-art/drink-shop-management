using System.Data;
using DrinkShop.DAL.Database;
using DrinkShop.DTO;
using Microsoft.Data.SqlClient;

namespace DrinkShop.DAL;

public sealed class TaiKhoanDAL
{
    public TaiKhoanDTO? KiemTraDangNhap(string username, string password)
    {
        const string sql = """
            SELECT tk.MaTaiKhoan, tk.TenDangNhap, tk.MatKhau, tk.MaQuyen, q.TenQuyen,
                   tk.TrangThai, nv.MaNV, nv.HoTen
            FROM dbo.TaiKhoan AS tk
            INNER JOIN dbo.Quyen AS q ON q.MaQuyen = tk.MaQuyen
            INNER JOIN dbo.NhanVien AS nv ON nv.MaTaiKhoan = tk.MaTaiKhoan
            WHERE tk.TenDangNhap = @username AND tk.MatKhau = @passwordHash;
            """;
        var parameters = new[]
        {
            new SqlParameter("@username", SqlDbType.VarChar, 50) { Value = username },
            new SqlParameter("@passwordHash", SqlDbType.VarChar, 64) { Value = DatabaseHelper.HashPassword(password) }
        };
        var table = DatabaseHelper.ExecuteDataTable(sql, parameters);
        if (table.Rows.Count == 0)
        {
            return null;
        }

        DataRow row = table.Rows[0];
        return new TaiKhoanDTO
        {
            MaTaiKhoan = Convert.ToInt32(row["MaTaiKhoan"]),
            TenDangNhap = Convert.ToString(row["TenDangNhap"]) ?? string.Empty,
            MatKhau = Convert.ToString(row["MatKhau"]) ?? string.Empty,
            MaQuyen = Convert.ToInt32(row["MaQuyen"]),
            TenQuyen = Convert.ToString(row["TenQuyen"]) ?? string.Empty,
            TrangThai = Convert.ToBoolean(row["TrangThai"]),
            MaNV = Convert.ToInt32(row["MaNV"]),
            HoTen = Convert.ToString(row["HoTen"]) ?? string.Empty
        };
    }
}

using System.Net.Mail;
using System.Text.RegularExpressions;
using DrinkShop.DAL;
using DrinkShop.DTO;
using System.Data;

namespace DrinkShop.BLL;

public sealed class NhanVienBLL
{
    private static readonly Regex PhoneRegex = new("^\\d{10}$", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private readonly NhanVienDAL _nhanVienDAL = new();

    public DataTable GetAllNhanVien() => _nhanVienDAL.GetAllNhanVien();
    public DataTable SearchNhanVien(string keyword) => string.IsNullOrWhiteSpace(keyword) ? GetAllNhanVien() : _nhanVienDAL.SearchNhanVien(keyword);
    public DataTable GetAllQuyen() => _nhanVienDAL.GetAllQuyen();

    public void InsertNhanVien(NhanVienDTO nhanVien)
    {
        ValidateEmployee(nhanVien);
        ValidateCredentials(nhanVien, true);
        _nhanVienDAL.InsertNhanVien(nhanVien, new TaiKhoanDTO
        {
            TenDangNhap = nhanVien.TenDangNhap,
            MatKhau = nhanVien.MatKhau,
            MaQuyen = nhanVien.MaQuyen,
            TrangThai = nhanVien.TrangThai
        });
    }

    public bool UpdateNhanVien(NhanVienDTO nhanVien)
    {
        ValidateEmployee(nhanVien);
        ValidateCredentials(nhanVien, false);
        return _nhanVienDAL.UpdateNhanVien(nhanVien);
    }

    public bool DoiTrangThai(int maNV, int trangThai) => _nhanVienDAL.DoiTrangThai(maNV, trangThai);

    private void ValidateEmployee(NhanVienDTO nhanVien)
    {
        if (string.IsNullOrWhiteSpace(nhanVien.HoTen))
        {
            throw new ArgumentException("Vui lòng nhập họ tên nhân viên.");
        }
        if (nhanVien.HoTen.Trim().Length > 100)
        {
            throw new ArgumentException("Họ tên không được vượt quá 100 ký tự.");
        }
        if (!PhoneRegex.IsMatch(nhanVien.SoDienThoai.Trim()))
        {
            throw new ArgumentException("Số điện thoại phải gồm đúng 10 chữ số.");
        }
        if (string.IsNullOrWhiteSpace(nhanVien.Email) || !IsValidEmail(nhanVien.Email.Trim()))
        {
            throw new ArgumentException("Vui lòng nhập địa chỉ email hợp lệ.");
        }
        if (nhanVien.Email.Trim().Length > 100)
        {
            throw new ArgumentException("Email không được vượt quá 100 ký tự.");
        }
        if (nhanVien.MaQuyen <= 0)
        {
            throw new ArgumentException("Vui lòng chọn quyền cho tài khoản.");
        }
    }

    private void ValidateCredentials(NhanVienDTO nhanVien, bool requirePassword)
    {
        string username = nhanVien.TenDangNhap.Trim();
        if (string.IsNullOrWhiteSpace(username) || username.Length > 50)
        {
            throw new ArgumentException("Tên đăng nhập là bắt buộc và không vượt quá 50 ký tự.");
        }
        if (_nhanVienDAL.IsUsernameTaken(username, requirePassword ? 0 : nhanVien.MaTaiKhoan))
        {
            throw new ArgumentException("Tên đăng nhập đã tồn tại trong hệ thống.");
        }
        if (requirePassword && string.IsNullOrWhiteSpace(nhanVien.MatKhau))
        {
            throw new ArgumentException("Vui lòng nhập mật khẩu cho tài khoản.");
        }
        if (!string.IsNullOrEmpty(nhanVien.MatKhau) && nhanVien.MatKhau.Length < 6)
        {
            throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự.");
        }
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            return new MailAddress(email).Address == email;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}

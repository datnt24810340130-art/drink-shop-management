using DrinkShop.DAL;
using DrinkShop.DTO;

namespace DrinkShop.BLL;

public sealed class TaiKhoanBLL
{
    private readonly TaiKhoanDAL _taiKhoanDAL = new();

    public TaiKhoanDTO? DangNhap(string username, string password, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            errorMessage = "Vui lòng nhập tên đăng nhập.";
            return null;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            errorMessage = "Vui lòng nhập mật khẩu.";
            return null;
        }

        TaiKhoanDTO? taiKhoan = _taiKhoanDAL.KiemTraDangNhap(username.Trim(), password);
        if (taiKhoan is null)
        {
            errorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác.";
            return null;
        }

        if (!taiKhoan.TrangThai)
        {
            errorMessage = "Tài khoản đã bị khóa. Vui lòng liên hệ quản trị viên.";
            return null;
        }

        errorMessage = string.Empty;
        return taiKhoan;
    }
}

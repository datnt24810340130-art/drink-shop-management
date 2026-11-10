using DrinkShop.DTO;

namespace DrinkShop.GUI.Helpers;

public static class UserSession
{
    public static int MaTaiKhoan { get; private set; }
    public static string TenDangNhap { get; private set; } = string.Empty;
    public static int MaNV { get; private set; }
    public static string HoTen { get; private set; } = string.Empty;
    public static int MaQuyen { get; private set; }
    public static string TenQuyen { get; private set; } = string.Empty;
    public static bool IsAuthenticated => MaTaiKhoan > 0;

    public static void Start(TaiKhoanDTO taiKhoan)
    {
        ArgumentNullException.ThrowIfNull(taiKhoan);
        MaTaiKhoan = taiKhoan.MaTaiKhoan;
        TenDangNhap = taiKhoan.TenDangNhap;
        MaNV = taiKhoan.MaNV;
        HoTen = taiKhoan.HoTen;
        MaQuyen = taiKhoan.MaQuyen;
        TenQuyen = taiKhoan.TenQuyen;
    }

    public static void Clear()
    {
        MaTaiKhoan = 0;
        TenDangNhap = string.Empty;
        MaNV = 0;
        HoTen = string.Empty;
        MaQuyen = 0;
        TenQuyen = string.Empty;
    }
}

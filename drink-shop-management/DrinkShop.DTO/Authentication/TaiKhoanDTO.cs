namespace DrinkShop.DTO;

public sealed class TaiKhoanDTO
{
    public int MaTaiKhoan { get; set; }
    public string TenDangNhap { get; set; } = string.Empty;
    public string MatKhau { get; set; } = string.Empty;
    public int MaQuyen { get; set; }
    public string TenQuyen { get; set; } = string.Empty;
    public bool TrangThai { get; set; }
    public int MaNV { get; set; }
    public string HoTen { get; set; } = string.Empty;
}

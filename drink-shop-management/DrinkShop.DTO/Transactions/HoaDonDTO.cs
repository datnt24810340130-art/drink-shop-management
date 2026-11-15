namespace DrinkShop.DTO;

/// <summary>
/// DTO đại diện cho hóa đơn bán hàng (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public class HoaDonDTO
{
    public int MaHoaDon { get; set; }
    public int MaBan { get; set; }
    public int MaNV { get; set; }
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public decimal TongTien { get; set; }
    public int GiamGia { get; set; }
    public decimal TienKhachDua { get; set; }
    public decimal TienThoi { get; set; }
    public string? PhuongThucThanhToan { get; set; }
    public string TrangThai { get; set; } = "Chưa thanh toán";

    // Thuộc tính phụ trợ hiển thị
    public string? TenBan { get; set; }
    public string? TenNhanVien { get; set; }
}

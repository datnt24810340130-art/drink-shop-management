namespace DrinkShop.DTO;

/// <summary>
/// DTO đại diện cho từng dòng món trong hóa đơn (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public class ChiTietHoaDonDTO
{
    public int MaCTHD { get; set; }
    public int MaHoaDon { get; set; }
    public int MaSanPham { get; set; }
    public int SoLuong { get; set; }
    public decimal DonGia { get; set; }
    public decimal ThanhTien { get; set; }
    public string? GhiChu { get; set; }

    // Thuộc tính phụ trợ hiển thị
    public string? TenSanPham { get; set; }
}

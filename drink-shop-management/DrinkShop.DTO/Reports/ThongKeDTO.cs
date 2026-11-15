namespace DrinkShop.DTO;

/// <summary>
/// DTO phục vụ cho các truy vấn thống kê, báo cáo doanh thu & món bán chạy (Phụ trách: Lê Tuấn Anh)
/// </summary>
public class ThongKeDTO
{
    public DateTime Ngay { get; set; }
    public int SoLuongDon { get; set; }
    public decimal DoanhThu { get; set; }

    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; } = string.Empty;
    public int SoLuongDaBan { get; set; }
}

namespace DrinkShop.DTO;

/// <summary>
/// DTO đại diện cho món nước / sản phẩm đồ uống (Phụ trách: Lê Tuấn Anh)
/// </summary>
public class SanPhamDTO
{
    public int MaSanPham { get; set; }
    public string TenSanPham { get; set; } = string.Empty;
    public int MaDanhMuc { get; set; }
    public decimal DonGia { get; set; }
    public string? HinhAnh { get; set; }
    public bool TrangThai { get; set; } = true;

    // Thuộc tính phụ trợ hiển thị giao diện
    public string? TenDanhMuc { get; set; }
}

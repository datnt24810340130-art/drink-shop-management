namespace DrinkShop.DTO;

/// <summary>
/// DTO đại diện cho danh mục đồ uống (Phụ trách: Lê Tuấn Anh)
/// </summary>
public class DanhMucDTO
{
    public int MaDanhMuc { get; set; }
    public string TenDanhMuc { get; set; } = string.Empty;
    public bool TrangThai { get; set; } = true;
}

namespace DrinkShop.DTO;

/// <summary>
/// DTO đại diện cho bàn nước (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public class BanDTO
{
    public int MaBan { get; set; }
    public string TenBan { get; set; } = string.Empty;
    public string TrangThai { get; set; } = "Trống"; // 'Trống', 'Có khách', 'Đã đặt'
}

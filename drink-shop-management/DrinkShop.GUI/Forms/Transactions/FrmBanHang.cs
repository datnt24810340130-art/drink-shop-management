using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình bán hàng POS & đặt món tại bàn (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public partial class FrmBanHang : Form
{
    private readonly BanBLL _banBLL = new();
    private readonly SanPhamBLL _sanPhamBLL = new();
    private readonly HoaDonBLL _hoaDonBLL = new();

    public FrmBanHang()
    {
        InitializeComponent();
    }
}

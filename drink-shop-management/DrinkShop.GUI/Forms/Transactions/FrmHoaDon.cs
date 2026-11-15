using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình quản lý hóa đơn và thanh toán (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public partial class FrmHoaDon : Form
{
    private readonly HoaDonBLL _hoaDonBLL = new();

    public FrmHoaDon()
    {
        InitializeComponent();
    }
}

using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình quản lý danh sách & sơ đồ bàn (Phụ trách: Nguyễn Trọng Hiếu)
/// </summary>
public partial class FrmBan : Form
{
    private readonly BanBLL _banBLL = new();

    public FrmBan()
    {
        InitializeComponent();
    }
}

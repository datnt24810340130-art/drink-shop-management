using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình quản lý sản phẩm đồ uống (Phụ trách: Lê Tuấn Anh)
/// </summary>
public partial class FrmSanPham : Form
{
    private readonly SanPhamBLL _sanPhamBLL = new();

    public FrmSanPham()
    {
        InitializeComponent();
    }
}

using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình quản lý danh mục đồ uống (Phụ trách: Lê Tuấn Anh)
/// </summary>
public partial class FrmDanhMuc : Form
{
    private readonly DanhMucBLL _danhMucBLL = new();

    public FrmDanhMuc()
    {
        InitializeComponent();
    }
}

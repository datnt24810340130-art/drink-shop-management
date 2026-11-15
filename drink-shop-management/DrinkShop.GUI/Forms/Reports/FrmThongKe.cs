using DrinkShop.BLL;

namespace DrinkShop.GUI.Forms;

/// <summary>
/// Màn hình báo cáo thống kê doanh thu & KPI (Phụ trách: Lê Tuấn Anh)
/// </summary>
public partial class FrmThongKe : Form
{
    private readonly ThongKeBLL _thongKeBLL = new();

    public FrmThongKe()
    {
        InitializeComponent();
    }
}

using DrinkShop.GUI.Helpers;

namespace DrinkShop.GUI.Forms;

public partial class FrmMain : Form
{
    private static readonly Color SidebarColor = Color.FromArgb(30, 39, 44);
    private static readonly Color AccentColor = Color.FromArgb(26, 188, 156);
    private readonly Dictionary<string, Button> _navigationButtons = new();

    public FrmMain()
    {
        InitializeComponent();
        RegisterNavigationButtons();
    }

    private void RegisterNavigationButtons()
    {
        _navigationButtons["Dashboard"] = btnDashboard;
        _navigationButtons["Bán hàng"] = btnBanHang;
        _navigationButtons["Bàn"] = btnBan;
        _navigationButtons["Đồ uống"] = btnSanPham;
        _navigationButtons["Danh mục"] = btnDanhMuc;
        _navigationButtons["Hóa đơn"] = btnHoaDon;
        _navigationButtons["Nhân viên"] = btnNhanVien;
        _navigationButtons["Thống kê"] = btnThongKe;
        _navigationButtons["Đăng xuất"] = btnLogout;
    }

    private void FrmMain_Load(object? sender, EventArgs e)
    {
        lblUserInfo.Text = $"Xin chào: {UserSession.HoTen} [{UserSession.TenQuyen}]";
        ApplyRoleVisibility();
        UpdateClock();
        clockTimer.Start();
        OpenPage("Dashboard", new NavigationPageForm("Dashboard", "Chào mừng đến với hệ thống quản lý Drink Shop."));
    }

    private void FrmMain_FormClosed(object? sender, FormClosedEventArgs e)
    {
        clockTimer.Stop();
    }

    private void ClockTimer_Tick(object? sender, EventArgs e)
    {
        UpdateClock();
    }

    private void BtnDashboard_Click(object? sender, EventArgs e)
    {
        OpenPage("Dashboard", new NavigationPageForm("Dashboard", "Tổng quan hoạt động cửa hàng."));
    }

    private void BtnBanHang_Click(object? sender, EventArgs e)
    {
        OpenPage("Bán hàng", new NavigationPageForm("Bán hàng", "Phân hệ bán hàng sẽ được tích hợp tại đây."));
    }

    private void BtnBan_Click(object? sender, EventArgs e)
    {
        OpenPage("Bàn", new NavigationPageForm("Bàn", "Phân hệ quản lý bàn sẽ được tích hợp tại đây."));
    }

    private void BtnSanPham_Click(object? sender, EventArgs e)
    {
        OpenPage("Đồ uống", new NavigationPageForm("Đồ uống", "Phân hệ quản lý đồ uống sẽ được tích hợp tại đây."));
    }

    private void BtnDanhMuc_Click(object? sender, EventArgs e)
    {
        OpenPage("Danh mục", new NavigationPageForm("Danh mục", "Phân hệ quản lý danh mục sẽ được tích hợp tại đây."));
    }

    private void BtnHoaDon_Click(object? sender, EventArgs e)
    {
        OpenPage("Hóa đơn", new NavigationPageForm("Hóa đơn", "Phân hệ hóa đơn sẽ được tích hợp tại đây."));
    }

    private void BtnNhanVien_Click(object? sender, EventArgs e)
    {
        OpenPage("Nhân viên", new FrmNhanVien());
    }

    private void BtnThongKe_Click(object? sender, EventArgs e)
    {
        OpenPage("Thống kê", new NavigationPageForm("Thống kê", "Phân hệ thống kê sẽ được tích hợp tại đây."));
    }

    private void BtnLogout_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void ApplyRoleVisibility()
    {
        bool isCashier = UserSession.TenQuyen.Contains("cashier", StringComparison.OrdinalIgnoreCase)
            || UserSession.TenQuyen.Contains("thu ngân", StringComparison.OrdinalIgnoreCase);
        btnNhanVien.Visible = !isCashier;
        btnThongKe.Visible = !isCashier;
    }

    private void OpenPage(string title, Form form)
    {
        lblCurrentTitle.Text = title;
        FormHelper.OpenChildForm(form, pnlContent);
        if (_navigationButtons.TryGetValue(title, out Button? button))
        {
            SetActiveButton(button);
        }
    }

    private void SetActiveButton(Button activeButton)
    {
        foreach (Button button in _navigationButtons.Values)
        {
            button.BackColor = SidebarColor;
        }
        activeButton.BackColor = AccentColor;
    }

    private void UpdateClock()
    {
        lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
    }

    private sealed class NavigationPageForm : Form
    {
        public NavigationPageForm(string title, string description)
        {
            BackColor = Color.White;
            Padding = new Padding(32);
            var titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 55,
                Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold),
                ForeColor = Color.FromArgb(44, 62, 80)
            };
            var descriptionLabel = new Label
            {
                Text = description,
                Dock = DockStyle.Top,
                Height = 45,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Color.FromArgb(100, 112, 121)
            };
            Controls.Add(descriptionLabel);
            Controls.Add(titleLabel);
        }
    }
}

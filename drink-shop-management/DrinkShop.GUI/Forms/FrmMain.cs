using DrinkShop.GUI.Helpers;

namespace DrinkShop.GUI.Forms;

public sealed class FrmMain : Form
{
    private static readonly Color SidebarColor = Color.FromArgb(30, 39, 44);
    private static readonly Color AccentColor = Color.FromArgb(26, 188, 156);
    private readonly Panel pnlSidebar = new();
    private readonly Panel pnlHeader = new();
    private readonly Panel pnlContent = new();
    private readonly Label lblCurrentTitle = new();
    private readonly Label lblUserInfo = new();
    private readonly Label lblClock = new();
    private readonly System.Windows.Forms.Timer clockTimer = new();
    private readonly Dictionary<string, Button> _navigationButtons = new();

    private readonly Button btnDashboard = new();
    private readonly Button btnBanHang = new();
    private readonly Button btnBan = new();
    private readonly Button btnSanPham = new();
    private readonly Button btnDanhMuc = new();
    private readonly Button btnHoaDon = new();
    private readonly Button btnNhanVien = new();
    private readonly Button btnThongKe = new();
    private readonly Button btnLogout = new();

    public FrmMain()
    {
        InitializeUi();
        ApplyRoleVisibility();
        UpdateClock();
        clockTimer.Interval = 1000;
        clockTimer.Tick += (_, _) => UpdateClock();
        clockTimer.Start();
        FormClosed += (_, _) => clockTimer.Dispose();
        OpenPage("Dashboard", new NavigationPageForm("Dashboard", "Chào mừng đến với hệ thống quản lý Drink Shop."));
    }

    private void InitializeUi()
    {
        Text = "Drink Shop Management";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(1100, 700);
        Size = new Size(1380, 850);
        BackColor = Color.FromArgb(241, 244, 246);
        Font = new Font("Segoe UI", 9.5F);

        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Width = 245;
        pnlSidebar.BackColor = SidebarColor;
        pnlSidebar.Padding = new Padding(12, 12, 12, 10);

        var brand = new Label
        {
            Text = "DRINK SHOP",
            Dock = DockStyle.Top,
            Height = 68,
            ForeColor = Color.White,
            Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var separator = new Panel { Dock = DockStyle.Top, Height = 1, BackColor = Color.FromArgb(65, 81, 94) };

        var menuPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true,
            BackColor = SidebarColor,
            Padding = new Padding(0, 16, 0, 0)
        };
        AddNavigation(menuPanel, btnDashboard, "Dashboard");
        AddNavigation(menuPanel, btnBanHang, "Bán hàng");
        AddNavigation(menuPanel, btnBan, "Bàn");
        AddNavigation(menuPanel, btnSanPham, "Đồ uống");
        AddNavigation(menuPanel, btnDanhMuc, "Danh mục");
        AddNavigation(menuPanel, btnHoaDon, "Hóa đơn");
        AddNavigation(menuPanel, btnNhanVien, "Nhân viên");
        AddNavigation(menuPanel, btnThongKe, "Thống kê");
        AddNavigation(menuPanel, btnLogout, "Đăng xuất");

        pnlSidebar.Controls.Add(menuPanel);
        pnlSidebar.Controls.Add(separator);
        pnlSidebar.Controls.Add(brand);

        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 76;
        pnlHeader.BackColor = Color.White;
        pnlHeader.Padding = new Padding(24, 10, 24, 10);
        lblCurrentTitle.Dock = DockStyle.Left;
        lblCurrentTitle.Width = 350;
        lblCurrentTitle.Text = "Dashboard";
        lblCurrentTitle.TextAlign = ContentAlignment.MiddleLeft;
        lblCurrentTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        lblCurrentTitle.ForeColor = Color.FromArgb(44, 62, 80);
        lblClock.Dock = DockStyle.Right;
        lblClock.Width = 190;
        lblClock.TextAlign = ContentAlignment.MiddleRight;
        lblClock.ForeColor = Color.FromArgb(90, 105, 115);
        lblUserInfo.Dock = DockStyle.Right;
        lblUserInfo.Width = 330;
        lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
        lblUserInfo.ForeColor = Color.FromArgb(44, 62, 80);
        lblUserInfo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblUserInfo.Text = $"Xin chào: {UserSession.HoTen} [{UserSession.TenQuyen}]";
        pnlHeader.Controls.Add(lblClock);
        pnlHeader.Controls.Add(lblUserInfo);
        pnlHeader.Controls.Add(lblCurrentTitle);

        pnlContent.Dock = DockStyle.Fill;
        pnlContent.BackColor = Color.FromArgb(241, 244, 246);
        pnlContent.Padding = new Padding(20);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);

        btnDashboard.Click += (_, _) => OpenPage("Dashboard", new NavigationPageForm("Dashboard", "Tổng quan hoạt động cửa hàng."));
        btnBanHang.Click += (_, _) => OpenPage("Bán hàng", new NavigationPageForm("Bán hàng", "Phân hệ bán hàng sẽ được tích hợp tại đây."));
        btnBan.Click += (_, _) => OpenPage("Bàn", new NavigationPageForm("Bàn", "Phân hệ quản lý bàn sẽ được tích hợp tại đây."));
        btnSanPham.Click += (_, _) => OpenPage("Đồ uống", new NavigationPageForm("Đồ uống", "Phân hệ quản lý đồ uống sẽ được tích hợp tại đây."));
        btnDanhMuc.Click += (_, _) => OpenPage("Danh mục", new NavigationPageForm("Danh mục", "Phân hệ quản lý danh mục sẽ được tích hợp tại đây."));
        btnHoaDon.Click += (_, _) => OpenPage("Hóa đơn", new NavigationPageForm("Hóa đơn", "Phân hệ hóa đơn sẽ được tích hợp tại đây."));
        btnNhanVien.Click += (_, _) => OpenPage("Nhân viên", new FrmNhanVien());
        btnThongKe.Click += (_, _) => OpenPage("Thống kê", new NavigationPageForm("Thống kê", "Phân hệ thống kê sẽ được tích hợp tại đây."));
        btnLogout.Click += (_, _) => Close();
    }

    private void AddNavigation(FlowLayoutPanel parent, Button button, string text)
    {
        button.Text = text;
        button.Width = 215;
        button.Height = 43;
        button.Margin = new Padding(0, 3, 0, 3);
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Padding = new Padding(15, 0, 0, 0);
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = SidebarColor;
        button.ForeColor = Color.FromArgb(218, 226, 232);
        button.Font = new Font("Segoe UI", 9.5F);
        button.Cursor = Cursors.Hand;
        button.Click += (_, _) => SetActiveButton(button);
        parent.Controls.Add(button);
        _navigationButtons[text] = button;
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

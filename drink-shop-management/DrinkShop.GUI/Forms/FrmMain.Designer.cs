#nullable disable

namespace DrinkShop.GUI.Forms;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlSidebar;
    private Label lblBrand;
    private Panel pnlSeparator;
    private FlowLayoutPanel menuPanel;
    private Button btnDashboard;
    private Button btnBanHang;
    private Button btnBan;
    private Button btnSanPham;
    private Button btnDanhMuc;
    private Button btnHoaDon;
    private Button btnNhanVien;
    private Button btnThongKe;
    private Button btnLogout;
    private Panel pnlHeader;
    private Label lblCurrentTitle;
    private Label lblUserInfo;
    private Label lblClock;
    private System.Windows.Forms.Timer clockTimer;
    private Panel pnlContent;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlSidebar = new Panel();
        lblBrand = new Label();
        pnlSeparator = new Panel();
        menuPanel = new FlowLayoutPanel();
        btnDashboard = new Button();
        btnBanHang = new Button();
        btnBan = new Button();
        btnSanPham = new Button();
        btnDanhMuc = new Button();
        btnHoaDon = new Button();
        btnNhanVien = new Button();
        btnThongKe = new Button();
        btnLogout = new Button();
        pnlHeader = new Panel();
        lblCurrentTitle = new Label();
        lblUserInfo = new Label();
        lblClock = new Label();
        pnlContent = new Panel();
        clockTimer = new System.Windows.Forms.Timer(components);
        pnlSidebar.SuspendLayout();
        menuPanel.SuspendLayout();
        pnlHeader.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(30, 39, 44);
        pnlSidebar.Controls.Add(menuPanel);
        pnlSidebar.Controls.Add(pnlSeparator);
        pnlSidebar.Controls.Add(lblBrand);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Padding = new Padding(12, 12, 12, 10);
        pnlSidebar.Size = new Size(245, 811);
        pnlSidebar.TabIndex = 0;
        // 
        // lblBrand
        // 
        lblBrand.Dock = DockStyle.Top;
        lblBrand.Font = new Font("Segoe UI Semibold", 17F, FontStyle.Bold);
        lblBrand.ForeColor = Color.White;
        lblBrand.Location = new Point(12, 12);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(221, 68);
        lblBrand.TabIndex = 0;
        lblBrand.Text = "DRINK SHOP";
        lblBrand.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlSeparator
        // 
        pnlSeparator.BackColor = Color.FromArgb(65, 81, 94);
        pnlSeparator.Dock = DockStyle.Top;
        pnlSeparator.Location = new Point(12, 80);
        pnlSeparator.Name = "pnlSeparator";
        pnlSeparator.Size = new Size(221, 1);
        pnlSeparator.TabIndex = 1;
        // 
        // menuPanel
        // 
        menuPanel.AutoScroll = true;
        menuPanel.BackColor = Color.FromArgb(30, 39, 44);
        menuPanel.Controls.Add(btnDashboard);
        menuPanel.Controls.Add(btnBanHang);
        menuPanel.Controls.Add(btnBan);
        menuPanel.Controls.Add(btnSanPham);
        menuPanel.Controls.Add(btnDanhMuc);
        menuPanel.Controls.Add(btnHoaDon);
        menuPanel.Controls.Add(btnNhanVien);
        menuPanel.Controls.Add(btnThongKe);
        menuPanel.Controls.Add(btnLogout);
        menuPanel.Dock = DockStyle.Fill;
        menuPanel.FlowDirection = FlowDirection.TopDown;
        menuPanel.Location = new Point(12, 81);
        menuPanel.Name = "menuPanel";
        menuPanel.Padding = new Padding(0, 16, 0, 0);
        menuPanel.Size = new Size(221, 720);
        menuPanel.TabIndex = 2;
        menuPanel.WrapContents = false;
        // 
        // btnDashboard
        // 
        btnDashboard.BackColor = Color.FromArgb(30, 39, 44);
        btnDashboard.Cursor = Cursors.Hand;
        btnDashboard.FlatAppearance.BorderSize = 0;
        btnDashboard.FlatStyle = FlatStyle.Flat;
        btnDashboard.Font = new Font("Segoe UI", 9.5F);
        btnDashboard.ForeColor = Color.FromArgb(218, 226, 232);
        btnDashboard.Location = new Point(0, 19);
        btnDashboard.Margin = new Padding(0, 3, 0, 3);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Padding = new Padding(15, 0, 0, 0);
        btnDashboard.Size = new Size(215, 43);
        btnDashboard.TabIndex = 0;
        btnDashboard.Text = "Dashboard";
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnDashboard.UseVisualStyleBackColor = false;
        btnDashboard.Click += BtnDashboard_Click;
        // 
        // btnBanHang
        // 
        btnBanHang.BackColor = Color.FromArgb(30, 39, 44);
        btnBanHang.Cursor = Cursors.Hand;
        btnBanHang.FlatAppearance.BorderSize = 0;
        btnBanHang.FlatStyle = FlatStyle.Flat;
        btnBanHang.Font = new Font("Segoe UI", 9.5F);
        btnBanHang.ForeColor = Color.FromArgb(218, 226, 232);
        btnBanHang.Location = new Point(0, 68);
        btnBanHang.Margin = new Padding(0, 3, 0, 3);
        btnBanHang.Name = "btnBanHang";
        btnBanHang.Padding = new Padding(15, 0, 0, 0);
        btnBanHang.Size = new Size(215, 43);
        btnBanHang.TabIndex = 1;
        btnBanHang.Text = "Bán hàng";
        btnBanHang.TextAlign = ContentAlignment.MiddleLeft;
        btnBanHang.UseVisualStyleBackColor = false;
        btnBanHang.Click += BtnBanHang_Click;
        // 
        // btnBan
        // 
        btnBan.BackColor = Color.FromArgb(30, 39, 44);
        btnBan.Cursor = Cursors.Hand;
        btnBan.FlatAppearance.BorderSize = 0;
        btnBan.FlatStyle = FlatStyle.Flat;
        btnBan.Font = new Font("Segoe UI", 9.5F);
        btnBan.ForeColor = Color.FromArgb(218, 226, 232);
        btnBan.Location = new Point(0, 117);
        btnBan.Margin = new Padding(0, 3, 0, 3);
        btnBan.Name = "btnBan";
        btnBan.Padding = new Padding(15, 0, 0, 0);
        btnBan.Size = new Size(215, 43);
        btnBan.TabIndex = 2;
        btnBan.Text = "Bàn";
        btnBan.TextAlign = ContentAlignment.MiddleLeft;
        btnBan.UseVisualStyleBackColor = false;
        btnBan.Click += BtnBan_Click;
        // 
        // btnSanPham
        // 
        btnSanPham.BackColor = Color.FromArgb(30, 39, 44);
        btnSanPham.Cursor = Cursors.Hand;
        btnSanPham.FlatAppearance.BorderSize = 0;
        btnSanPham.FlatStyle = FlatStyle.Flat;
        btnSanPham.Font = new Font("Segoe UI", 9.5F);
        btnSanPham.ForeColor = Color.FromArgb(218, 226, 232);
        btnSanPham.Location = new Point(0, 166);
        btnSanPham.Margin = new Padding(0, 3, 0, 3);
        btnSanPham.Name = "btnSanPham";
        btnSanPham.Padding = new Padding(15, 0, 0, 0);
        btnSanPham.Size = new Size(215, 43);
        btnSanPham.TabIndex = 3;
        btnSanPham.Text = "Đồ uống";
        btnSanPham.TextAlign = ContentAlignment.MiddleLeft;
        btnSanPham.UseVisualStyleBackColor = false;
        btnSanPham.Click += BtnSanPham_Click;
        // 
        // btnDanhMuc
        // 
        btnDanhMuc.BackColor = Color.FromArgb(30, 39, 44);
        btnDanhMuc.Cursor = Cursors.Hand;
        btnDanhMuc.FlatAppearance.BorderSize = 0;
        btnDanhMuc.FlatStyle = FlatStyle.Flat;
        btnDanhMuc.Font = new Font("Segoe UI", 9.5F);
        btnDanhMuc.ForeColor = Color.FromArgb(218, 226, 232);
        btnDanhMuc.Location = new Point(0, 215);
        btnDanhMuc.Margin = new Padding(0, 3, 0, 3);
        btnDanhMuc.Name = "btnDanhMuc";
        btnDanhMuc.Padding = new Padding(15, 0, 0, 0);
        btnDanhMuc.Size = new Size(215, 43);
        btnDanhMuc.TabIndex = 4;
        btnDanhMuc.Text = "Danh mục";
        btnDanhMuc.TextAlign = ContentAlignment.MiddleLeft;
        btnDanhMuc.UseVisualStyleBackColor = false;
        btnDanhMuc.Click += BtnDanhMuc_Click;
        // 
        // btnHoaDon
        // 
        btnHoaDon.BackColor = Color.FromArgb(30, 39, 44);
        btnHoaDon.Cursor = Cursors.Hand;
        btnHoaDon.FlatAppearance.BorderSize = 0;
        btnHoaDon.FlatStyle = FlatStyle.Flat;
        btnHoaDon.Font = new Font("Segoe UI", 9.5F);
        btnHoaDon.ForeColor = Color.FromArgb(218, 226, 232);
        btnHoaDon.Location = new Point(0, 264);
        btnHoaDon.Margin = new Padding(0, 3, 0, 3);
        btnHoaDon.Name = "btnHoaDon";
        btnHoaDon.Padding = new Padding(15, 0, 0, 0);
        btnHoaDon.Size = new Size(215, 43);
        btnHoaDon.TabIndex = 5;
        btnHoaDon.Text = "Hóa đơn";
        btnHoaDon.TextAlign = ContentAlignment.MiddleLeft;
        btnHoaDon.UseVisualStyleBackColor = false;
        btnHoaDon.Click += BtnHoaDon_Click;
        // 
        // btnNhanVien
        // 
        btnNhanVien.BackColor = Color.FromArgb(30, 39, 44);
        btnNhanVien.Cursor = Cursors.Hand;
        btnNhanVien.FlatAppearance.BorderSize = 0;
        btnNhanVien.FlatStyle = FlatStyle.Flat;
        btnNhanVien.Font = new Font("Segoe UI", 9.5F);
        btnNhanVien.ForeColor = Color.FromArgb(218, 226, 232);
        btnNhanVien.Location = new Point(0, 313);
        btnNhanVien.Margin = new Padding(0, 3, 0, 3);
        btnNhanVien.Name = "btnNhanVien";
        btnNhanVien.Padding = new Padding(15, 0, 0, 0);
        btnNhanVien.Size = new Size(215, 43);
        btnNhanVien.TabIndex = 6;
        btnNhanVien.Text = "Nhân viên";
        btnNhanVien.TextAlign = ContentAlignment.MiddleLeft;
        btnNhanVien.UseVisualStyleBackColor = false;
        btnNhanVien.Click += BtnNhanVien_Click;
        // 
        // btnThongKe
        // 
        btnThongKe.BackColor = Color.FromArgb(30, 39, 44);
        btnThongKe.Cursor = Cursors.Hand;
        btnThongKe.FlatAppearance.BorderSize = 0;
        btnThongKe.FlatStyle = FlatStyle.Flat;
        btnThongKe.Font = new Font("Segoe UI", 9.5F);
        btnThongKe.ForeColor = Color.FromArgb(218, 226, 232);
        btnThongKe.Location = new Point(0, 362);
        btnThongKe.Margin = new Padding(0, 3, 0, 3);
        btnThongKe.Name = "btnThongKe";
        btnThongKe.Padding = new Padding(15, 0, 0, 0);
        btnThongKe.Size = new Size(215, 43);
        btnThongKe.TabIndex = 7;
        btnThongKe.Text = "Thống kê";
        btnThongKe.TextAlign = ContentAlignment.MiddleLeft;
        btnThongKe.UseVisualStyleBackColor = false;
        btnThongKe.Click += BtnThongKe_Click;
        // 
        // btnLogout
        // 
        btnLogout.BackColor = Color.FromArgb(30, 39, 44);
        btnLogout.Cursor = Cursors.Hand;
        btnLogout.FlatAppearance.BorderSize = 0;
        btnLogout.FlatStyle = FlatStyle.Flat;
        btnLogout.Font = new Font("Segoe UI", 9.5F);
        btnLogout.ForeColor = Color.FromArgb(218, 226, 232);
        btnLogout.Location = new Point(0, 411);
        btnLogout.Margin = new Padding(0, 3, 0, 3);
        btnLogout.Name = "btnLogout";
        btnLogout.Padding = new Padding(15, 0, 0, 0);
        btnLogout.Size = new Size(215, 43);
        btnLogout.TabIndex = 8;
        btnLogout.Text = "Đăng xuất";
        btnLogout.TextAlign = ContentAlignment.MiddleLeft;
        btnLogout.UseVisualStyleBackColor = false;
        btnLogout.Click += BtnLogout_Click;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblClock);
        pnlHeader.Controls.Add(lblUserInfo);
        pnlHeader.Controls.Add(lblCurrentTitle);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(245, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(24, 10, 24, 10);
        pnlHeader.Size = new Size(1119, 76);
        pnlHeader.TabIndex = 1;
        // 
        // lblCurrentTitle
        // 
        lblCurrentTitle.Dock = DockStyle.Left;
        lblCurrentTitle.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
        lblCurrentTitle.ForeColor = Color.FromArgb(44, 62, 80);
        lblCurrentTitle.Location = new Point(24, 10);
        lblCurrentTitle.Name = "lblCurrentTitle";
        lblCurrentTitle.Size = new Size(350, 56);
        lblCurrentTitle.TabIndex = 0;
        lblCurrentTitle.Text = "Dashboard";
        lblCurrentTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblUserInfo
        // 
        lblUserInfo.Dock = DockStyle.Right;
        lblUserInfo.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblUserInfo.ForeColor = Color.FromArgb(44, 62, 80);
        lblUserInfo.Location = new Point(595, 10);
        lblUserInfo.Name = "lblUserInfo";
        lblUserInfo.Size = new Size(330, 56);
        lblUserInfo.TabIndex = 1;
        lblUserInfo.Text = "Xin chào: Quản trị hệ thống [Admin]";
        lblUserInfo.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblClock
        // 
        lblClock.Dock = DockStyle.Right;
        lblClock.ForeColor = Color.FromArgb(90, 105, 115);
        lblClock.Location = new Point(925, 10);
        lblClock.Name = "lblClock";
        lblClock.Size = new Size(170, 56);
        lblClock.TabIndex = 2;
        lblClock.TextAlign = ContentAlignment.MiddleRight;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.FromArgb(241, 244, 246);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(245, 76);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(20);
        pnlContent.Size = new Size(1119, 735);
        pnlContent.TabIndex = 2;
        // 
        // clockTimer
        // 
        clockTimer.Interval = 1000;
        clockTimer.Tick += ClockTimer_Tick;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241, 244, 246);
        ClientSize = new Size(1364, 811);
        Controls.Add(pnlContent);
        Controls.Add(pnlHeader);
        Controls.Add(pnlSidebar);
        Font = new Font("Segoe UI", 9.5F);
        MinimumSize = new Size(1100, 700);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drink Shop Management";
        FormClosed += FrmMain_FormClosed;
        Load += FrmMain_Load;
        pnlSidebar.ResumeLayout(false);
        menuPanel.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        ResumeLayout(false);
    }
}


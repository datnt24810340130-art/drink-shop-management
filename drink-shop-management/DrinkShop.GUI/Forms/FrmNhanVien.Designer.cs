#nullable disable

namespace DrinkShop.GUI.Forms;

partial class FrmNhanVien
{
    private System.ComponentModel.IContainer components = null;
    private Panel pnlLeft = null!;
    private Panel pnlRight = null!;
    private Panel pnlSearch = null!;
    private Panel pnlEditor = null!;
    private Panel pnlActions = null!;
    private Label lblTitle = null!;
    private Label lblSearch = null!;
    private Label lblThongTinNhanVien = null!;
    private Label lblTaiKhoan = null!;
    private Label lblHoTen = null!;
    private Label lblSoDienThoai = null!;
    private Label lblEmail = null!;
    private Label lblTenDangNhap = null!;
    private Label lblMatKhau = null!;
    private Label lblQuyen = null!;
    private DataGridView dgvNhanVien = null!;
    private TextBox txtHoTen = null!;
    private TextBox txtSoDienThoai = null!;
    private TextBox txtEmail = null!;
    private TextBox txtTenDangNhap = null!;
    private TextBox txtMatKhau = null!;
    private ComboBox cboQuyen = null!;
    private CheckBox chkTrangThai = null!;
    private TextBox txtTimKiem = null!;
    private Button btnThem = null!;
    private Button btnSua = null!;
    private Button btnKhoa = null!;
    private Button btnLuu = null!;
    private Button btnHuy = null!;
    private Button btnLamMoi = null!;
    private Label lblMessage = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlLeft = new Panel();
        dgvNhanVien = new DataGridView();
        pnlSearch = new Panel();
        txtTimKiem = new TextBox();
        lblSearch = new Label();
        lblTitle = new Label();
        pnlRight = new Panel();
        pnlEditor = new Panel();
        lblThongTinNhanVien = new Label();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        lblSoDienThoai = new Label();
        txtSoDienThoai = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblTaiKhoan = new Label();
        lblTenDangNhap = new Label();
        txtTenDangNhap = new TextBox();
        lblMatKhau = new Label();
        txtMatKhau = new TextBox();
        lblQuyen = new Label();
        cboQuyen = new ComboBox();
        chkTrangThai = new CheckBox();
        lblMessage = new Label();
        pnlActions = new Panel();
        btnThem = new Button();
        btnSua = new Button();
        btnKhoa = new Button();
        btnLuu = new Button();
        btnHuy = new Button();
        btnLamMoi = new Button();
        pnlLeft.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvNhanVien).BeginInit();
        pnlSearch.SuspendLayout();
        pnlRight.SuspendLayout();
        pnlEditor.SuspendLayout();
        pnlActions.SuspendLayout();
        SuspendLayout();
        // 
        // pnlLeft
        // 
        pnlLeft.BackColor = Color.Transparent;
        pnlLeft.Controls.Add(dgvNhanVien);
        pnlLeft.Controls.Add(pnlSearch);
        pnlLeft.Controls.Add(lblTitle);
        pnlLeft.Dock = DockStyle.Fill;
        pnlLeft.Location = new Point(14, 16);
        pnlLeft.Margin = new Padding(3, 4, 3, 4);
        pnlLeft.Name = "pnlLeft";
        pnlLeft.Padding = new Padding(0, 0, 14, 0);
        pnlLeft.Size = new Size(909, 901);
        pnlLeft.TabIndex = 0;
        // 
        // dgvNhanVien
        // 
        dgvNhanVien.AllowUserToAddRows = false;
        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvNhanVien.BackgroundColor = Color.White;
        dgvNhanVien.BorderStyle = BorderStyle.None;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 62, 80);
        dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dataGridViewCellStyle1.ForeColor = Color.White;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dgvNhanVien.ColumnHeadersHeight = 38;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(204, 239, 232);
        dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(30, 39, 44);
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle2;
        dgvNhanVien.Dock = DockStyle.Fill;
        dgvNhanVien.EnableHeadersVisualStyles = false;
        dgvNhanVien.Location = new Point(0, 123);
        dgvNhanVien.Margin = new Padding(3, 4, 3, 4);
        dgvNhanVien.MultiSelect = false;
        dgvNhanVien.Name = "dgvNhanVien";
        dgvNhanVien.ReadOnly = true;
        dgvNhanVien.RowHeadersVisible = false;
        dgvNhanVien.RowHeadersWidth = 51;
        dgvNhanVien.RowTemplate.Height = 34;
        dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvNhanVien.Size = new Size(895, 778);
        dgvNhanVien.TabIndex = 0;
        dgvNhanVien.CellClick += DgvNhanVien_CellClick;
        dgvNhanVien.DataError += DgvNhanVien_DataError;
        // 
        // pnlSearch
        // 
        pnlSearch.Controls.Add(txtTimKiem);
        pnlSearch.Controls.Add(lblSearch);
        pnlSearch.Dock = DockStyle.Top;
        pnlSearch.Location = new Point(0, 59);
        pnlSearch.Margin = new Padding(3, 4, 3, 4);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Padding = new Padding(0, 5, 0, 11);
        pnlSearch.Size = new Size(895, 64);
        pnlSearch.TabIndex = 1;
        // 
        // txtTimKiem
        // 
        txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtTimKiem.Location = new Point(97, 7);
        txtTimKiem.Margin = new Padding(3, 4, 3, 4);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Họ tên, số điện thoại hoặc tên đăng nhập";
        txtTimKiem.Size = new Size(680, 27);
        txtTimKiem.TabIndex = 0;
        txtTimKiem.TextChanged += txtTimKiem_TextChanged;
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.ForeColor = Color.FromArgb(44, 62, 80);
        lblSearch.Location = new Point(2, 15);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(70, 20);
        lblSearch.TabIndex = 1;
        lblSearch.Text = "Tìm kiếm";
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(895, 59);
        lblTitle.TabIndex = 2;
        lblTitle.Text = "Quản lý nhân viên & tài khoản";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // pnlRight
        // 
        pnlRight.BackColor = Color.White;
        pnlRight.Controls.Add(pnlEditor);
        pnlRight.Dock = DockStyle.Right;
        pnlRight.Location = new Point(923, 16);
        pnlRight.Margin = new Padding(3, 4, 3, 4);
        pnlRight.Name = "pnlRight";
        pnlRight.Padding = new Padding(14, 16, 14, 16);
        pnlRight.Size = new Size(434, 901);
        pnlRight.TabIndex = 1;
        // 
        // pnlEditor
        // 
        pnlEditor.AutoScroll = true;
        pnlEditor.BackColor = Color.White;
        pnlEditor.Controls.Add(lblThongTinNhanVien);
        pnlEditor.Controls.Add(lblHoTen);
        pnlEditor.Controls.Add(txtHoTen);
        pnlEditor.Controls.Add(lblSoDienThoai);
        pnlEditor.Controls.Add(txtSoDienThoai);
        pnlEditor.Controls.Add(lblEmail);
        pnlEditor.Controls.Add(txtEmail);
        pnlEditor.Controls.Add(lblTaiKhoan);
        pnlEditor.Controls.Add(lblTenDangNhap);
        pnlEditor.Controls.Add(txtTenDangNhap);
        pnlEditor.Controls.Add(lblMatKhau);
        pnlEditor.Controls.Add(txtMatKhau);
        pnlEditor.Controls.Add(lblQuyen);
        pnlEditor.Controls.Add(cboQuyen);
        pnlEditor.Controls.Add(chkTrangThai);
        pnlEditor.Controls.Add(lblMessage);
        pnlEditor.Controls.Add(pnlActions);
        pnlEditor.Dock = DockStyle.Fill;
        pnlEditor.Location = new Point(14, 16);
        pnlEditor.Margin = new Padding(3, 4, 3, 4);
        pnlEditor.Name = "pnlEditor";
        pnlEditor.Padding = new Padding(18, 21, 18, 21);
        pnlEditor.Size = new Size(406, 869);
        pnlEditor.TabIndex = 0;
        // 
        // lblThongTinNhanVien
        // 
        lblThongTinNhanVien.AutoSize = true;
        lblThongTinNhanVien.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblThongTinNhanVien.ForeColor = Color.FromArgb(44, 62, 80);
        lblThongTinNhanVien.Location = new Point(21, 24);
        lblThongTinNhanVien.Name = "lblThongTinNhanVien";
        lblThongTinNhanVien.Padding = new Padding(0, 3, 0, 5);
        lblThongTinNhanVien.Size = new Size(165, 31);
        lblThongTinNhanVien.TabIndex = 0;
        lblThongTinNhanVien.Text = "Thông tin nhân viên";
        // 
        // lblHoTen
        // 
        lblHoTen.AutoSize = true;
        lblHoTen.ForeColor = Color.FromArgb(70, 83, 92);
        lblHoTen.Location = new Point(21, 69);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(54, 20);
        lblHoTen.TabIndex = 1;
        lblHoTen.Text = "Họ tên";
        // 
        // txtHoTen
        // 
        txtHoTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtHoTen.BackColor = Color.FromArgb(248, 249, 250);
        txtHoTen.BorderStyle = BorderStyle.FixedSingle;
        txtHoTen.Location = new Point(21, 95);
        txtHoTen.Margin = new Padding(3, 4, 3, 4);
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(356, 27);
        txtHoTen.TabIndex = 2;
        // 
        // lblSoDienThoai
        // 
        lblSoDienThoai.AutoSize = true;
        lblSoDienThoai.ForeColor = Color.FromArgb(70, 83, 92);
        lblSoDienThoai.Location = new Point(21, 135);
        lblSoDienThoai.Name = "lblSoDienThoai";
        lblSoDienThoai.Size = new Size(97, 20);
        lblSoDienThoai.TabIndex = 3;
        lblSoDienThoai.Text = "Số điện thoại";
        // 
        // txtSoDienThoai
        // 
        txtSoDienThoai.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtSoDienThoai.BackColor = Color.FromArgb(248, 249, 250);
        txtSoDienThoai.BorderStyle = BorderStyle.FixedSingle;
        txtSoDienThoai.Location = new Point(21, 160);
        txtSoDienThoai.Margin = new Padding(3, 4, 3, 4);
        txtSoDienThoai.Name = "txtSoDienThoai";
        txtSoDienThoai.Size = new Size(356, 27);
        txtSoDienThoai.TabIndex = 4;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.ForeColor = Color.FromArgb(70, 83, 92);
        lblEmail.Location = new Point(21, 200);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(46, 20);
        lblEmail.TabIndex = 5;
        lblEmail.Text = "Email";
        // 
        // txtEmail
        // 
        txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtEmail.BackColor = Color.FromArgb(248, 249, 250);
        txtEmail.BorderStyle = BorderStyle.FixedSingle;
        txtEmail.Location = new Point(21, 225);
        txtEmail.Margin = new Padding(3, 4, 3, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(356, 27);
        txtEmail.TabIndex = 6;
        // 
        // lblTaiKhoan
        // 
        lblTaiKhoan.AutoSize = true;
        lblTaiKhoan.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        lblTaiKhoan.ForeColor = Color.FromArgb(44, 62, 80);
        lblTaiKhoan.Location = new Point(21, 269);
        lblTaiKhoan.Name = "lblTaiKhoan";
        lblTaiKhoan.Size = new Size(171, 23);
        lblTaiKhoan.TabIndex = 7;
        lblTaiKhoan.Text = "Tài khoản đăng nhập";
        // 
        // lblTenDangNhap
        // 
        lblTenDangNhap.AutoSize = true;
        lblTenDangNhap.ForeColor = Color.FromArgb(70, 83, 92);
        lblTenDangNhap.Location = new Point(21, 309);
        lblTenDangNhap.Name = "lblTenDangNhap";
        lblTenDangNhap.Size = new Size(107, 20);
        lblTenDangNhap.TabIndex = 8;
        lblTenDangNhap.Text = "Tên đăng nhập";
        // 
        // txtTenDangNhap
        // 
        txtTenDangNhap.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtTenDangNhap.BackColor = Color.FromArgb(248, 249, 250);
        txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
        txtTenDangNhap.Location = new Point(21, 335);
        txtTenDangNhap.Margin = new Padding(3, 4, 3, 4);
        txtTenDangNhap.Name = "txtTenDangNhap";
        txtTenDangNhap.Size = new Size(356, 27);
        txtTenDangNhap.TabIndex = 9;
        // 
        // lblMatKhau
        // 
        lblMatKhau.AutoSize = true;
        lblMatKhau.ForeColor = Color.FromArgb(70, 83, 92);
        lblMatKhau.Location = new Point(21, 375);
        lblMatKhau.Name = "lblMatKhau";
        lblMatKhau.Size = new Size(70, 20);
        lblMatKhau.TabIndex = 10;
        lblMatKhau.Text = "Mật khẩu";
        // 
        // txtMatKhau
        // 
        txtMatKhau.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtMatKhau.BackColor = Color.FromArgb(248, 249, 250);
        txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
        txtMatKhau.Location = new Point(21, 400);
        txtMatKhau.Margin = new Padding(3, 4, 3, 4);
        txtMatKhau.Name = "txtMatKhau";
        txtMatKhau.Size = new Size(356, 27);
        txtMatKhau.TabIndex = 11;
        txtMatKhau.UseSystemPasswordChar = true;
        // 
        // lblQuyen
        // 
        lblQuyen.AutoSize = true;
        lblQuyen.ForeColor = Color.FromArgb(70, 83, 92);
        lblQuyen.Location = new Point(21, 440);
        lblQuyen.Name = "lblQuyen";
        lblQuyen.Size = new Size(51, 20);
        lblQuyen.TabIndex = 12;
        lblQuyen.Text = "Quyền";
        // 
        // cboQuyen
        // 
        cboQuyen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
        cboQuyen.Location = new Point(21, 465);
        cboQuyen.Margin = new Padding(3, 4, 3, 4);
        cboQuyen.Name = "cboQuyen";
        cboQuyen.Size = new Size(356, 28);
        cboQuyen.TabIndex = 13;
        // 
        // chkTrangThai
        // 
        chkTrangThai.AutoSize = true;
        chkTrangThai.ForeColor = Color.FromArgb(44, 62, 80);
        chkTrangThai.Location = new Point(21, 513);
        chkTrangThai.Margin = new Padding(3, 4, 3, 4);
        chkTrangThai.Name = "chkTrangThai";
        chkTrangThai.Size = new Size(204, 24);
        chkTrangThai.TabIndex = 14;
        chkTrangThai.Text = "Tài khoản đang hoạt động";
        // 
        // lblMessage
        // 
        lblMessage.AutoSize = true;
        lblMessage.ForeColor = Color.FromArgb(192, 57, 43);
        lblMessage.Location = new Point(21, 555);
        lblMessage.Name = "lblMessage";
        lblMessage.Padding = new Padding(0, 8, 0, 8);
        lblMessage.Size = new Size(0, 36);
        lblMessage.TabIndex = 15;
        // 
        // pnlActions
        // 
        pnlActions.BackColor = Color.White;
        pnlActions.Controls.Add(btnThem);
        pnlActions.Controls.Add(btnSua);
        pnlActions.Controls.Add(btnKhoa);
        pnlActions.Controls.Add(btnLuu);
        pnlActions.Controls.Add(btnHuy);
        pnlActions.Controls.Add(btnLamMoi);
        pnlActions.Dock = DockStyle.Bottom;
        pnlActions.Location = new Point(18, 570);
        pnlActions.Margin = new Padding(3, 4, 3, 4);
        pnlActions.Name = "pnlActions";
        pnlActions.Size = new Size(349, 347);
        pnlActions.TabIndex = 16;
        // 
        // btnThem
        // 
        btnThem.BackColor = Color.FromArgb(26, 188, 156);
        btnThem.Cursor = Cursors.Hand;
        btnThem.FlatAppearance.BorderSize = 0;
        btnThem.FlatStyle = FlatStyle.Flat;
        btnThem.ForeColor = Color.White;
        btnThem.Location = new Point(-2, 8);
        btnThem.Margin = new Padding(3, 4, 3, 4);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(112, 45);
        btnThem.TabIndex = 0;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = false;
        btnThem.Click += btnThem_Click;
        // 
        // btnSua
        // 
        btnSua.BackColor = Color.FromArgb(52, 152, 219);
        btnSua.Cursor = Cursors.Hand;
        btnSua.FlatAppearance.BorderSize = 0;
        btnSua.FlatStyle = FlatStyle.Flat;
        btnSua.ForeColor = Color.White;
        btnSua.Location = new Point(116, 8);
        btnSua.Margin = new Padding(3, 4, 3, 4);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(112, 45);
        btnSua.TabIndex = 1;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = false;
        btnSua.Click += btnSua_Click;
        // 
        // btnKhoa
        // 
        btnKhoa.BackColor = Color.FromArgb(230, 126, 34);
        btnKhoa.Cursor = Cursors.Hand;
        btnKhoa.FlatAppearance.BorderSize = 0;
        btnKhoa.FlatStyle = FlatStyle.Flat;
        btnKhoa.ForeColor = Color.White;
        btnKhoa.Location = new Point(235, 8);
        btnKhoa.Margin = new Padding(3, 4, 3, 4);
        btnKhoa.Name = "btnKhoa";
        btnKhoa.Size = new Size(112, 45);
        btnKhoa.TabIndex = 2;
        btnKhoa.Text = "Khóa / Mở";
        btnKhoa.UseVisualStyleBackColor = false;
        btnKhoa.Click += btnKhoa_Click;
        // 
        // btnLuu
        // 
        btnLuu.BackColor = Color.FromArgb(39, 174, 96);
        btnLuu.Cursor = Cursors.Hand;
        btnLuu.FlatAppearance.BorderSize = 0;
        btnLuu.FlatStyle = FlatStyle.Flat;
        btnLuu.ForeColor = Color.White;
        btnLuu.Location = new Point(0, 60);
        btnLuu.Margin = new Padding(3, 4, 3, 4);
        btnLuu.Name = "btnLuu";
        btnLuu.Size = new Size(112, 45);
        btnLuu.TabIndex = 3;
        btnLuu.Text = "Lưu";
        btnLuu.UseVisualStyleBackColor = false;
        btnLuu.Click += btnLuu_Click;
        // 
        // btnHuy
        // 
        btnHuy.BackColor = Color.FromArgb(127, 140, 141);
        btnHuy.Cursor = Cursors.Hand;
        btnHuy.FlatAppearance.BorderSize = 0;
        btnHuy.FlatStyle = FlatStyle.Flat;
        btnHuy.ForeColor = Color.White;
        btnHuy.Location = new Point(118, 60);
        btnHuy.Margin = new Padding(3, 4, 3, 4);
        btnHuy.Name = "btnHuy";
        btnHuy.Size = new Size(112, 45);
        btnHuy.TabIndex = 4;
        btnHuy.Text = "Hủy";
        btnHuy.UseVisualStyleBackColor = false;
        btnHuy.Click += btnHuy_Click;
        // 
        // btnLamMoi
        // 
        btnLamMoi.BackColor = Color.FromArgb(44, 62, 80);
        btnLamMoi.Cursor = Cursors.Hand;
        btnLamMoi.FlatAppearance.BorderSize = 0;
        btnLamMoi.FlatStyle = FlatStyle.Flat;
        btnLamMoi.ForeColor = Color.White;
        btnLamMoi.Location = new Point(235, 60);
        btnLamMoi.Margin = new Padding(3, 4, 3, 4);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(112, 45);
        btnLamMoi.TabIndex = 5;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = false;
        btnLamMoi.Click += btnLamMoi_Click;
        // 
        // FrmNhanVien
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 248);
        ClientSize = new Size(1371, 933);
        Controls.Add(pnlLeft);
        Controls.Add(pnlRight);
        Font = new Font("Segoe UI", 9F);
        Margin = new Padding(3, 4, 3, 4);
        MinimumSize = new Size(1140, 784);
        Name = "FrmNhanVien";
        Padding = new Padding(14, 16, 14, 16);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Quản lý nhân viên";
        Load += FrmNhanVien_Load;
        pnlLeft.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvNhanVien).EndInit();
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        pnlRight.ResumeLayout(false);
        pnlEditor.ResumeLayout(false);
        pnlEditor.PerformLayout();
        pnlActions.ResumeLayout(false);
        ResumeLayout(false);
    }

}

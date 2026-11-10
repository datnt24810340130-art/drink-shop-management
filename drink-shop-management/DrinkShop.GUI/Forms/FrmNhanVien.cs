using System.Data;
using DrinkShop.BLL;
using DrinkShop.DTO;
using Microsoft.Data.SqlClient;

namespace DrinkShop.GUI.Forms;

public sealed class FrmNhanVien : Form
{
    private enum EditMode { View, Add, Edit }

    private readonly NhanVienBLL _nhanVienBLL = new();
    private readonly DataGridView dgvNhanVien = new();
    private readonly TextBox txtHoTen = new();
    private readonly TextBox txtSoDienThoai = new();
    private readonly TextBox txtEmail = new();
    private readonly TextBox txtTenDangNhap = new();
    private readonly TextBox txtMatKhau = new();
    private readonly ComboBox cboQuyen = new();
    private readonly CheckBox chkTrangThai = new();
    private readonly TextBox txtTimKiem = new();
    private readonly Button btnThem = new();
    private readonly Button btnSua = new();
    private readonly Button btnKhoa = new();
    private readonly Button btnLuu = new();
    private readonly Button btnHuy = new();
    private readonly Button btnLamMoi = new();
    private readonly Label lblMessage = new();
    private EditMode _editMode;
    private int _selectedMaNV;
    private int _selectedMaTaiKhoan;

    public FrmNhanVien()
    {
        InitializeUi();
        Load += FrmNhanVien_Load;
    }

    private void InitializeUi()
    {
        BackColor = Color.FromArgb(245, 247, 248);
        Font = new Font("Segoe UI", 9F);
        Padding = new Padding(12);

        var title = new Label
        {
            Text = "Quản lý nhân viên & tài khoản",
            Dock = DockStyle.Top,
            Height = 44,
            Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold),
            ForeColor = Color.FromArgb(44, 62, 80)
        };
        var searchPanel = new Panel { Dock = DockStyle.Top, Height = 48, Padding = new Padding(0, 4, 0, 8) };
        var searchLabel = new Label { Text = "Tìm kiếm", AutoSize = true, Location = new Point(2, 11), ForeColor = Color.FromArgb(44, 62, 80) };
        txtTimKiem.Location = new Point(85, 5);
        txtTimKiem.Size = new Size(350, 28);
        txtTimKiem.PlaceholderText = "Họ tên, số điện thoại hoặc tên đăng nhập";
        txtTimKiem.TextChanged += (_, _) => LoadEmployees();
        searchPanel.Controls.Add(searchLabel);
        searchPanel.Controls.Add(txtTimKiem);

        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            Orientation = Orientation.Vertical,
            SplitterDistance = 650,
            FixedPanel = FixedPanel.Panel2,
            BackColor = Color.FromArgb(245, 247, 248),
            Padding = new Padding(0, 4, 0, 0)
        };
        ConfigureGrid();
        split.Panel1.Controls.Add(dgvNhanVien);
        BuildEditor(split.Panel2);

        Controls.Add(split);
        Controls.Add(searchPanel);
        Controls.Add(title);
        ConfigureActions();
    }

    private void ConfigureGrid()
    {
        dgvNhanVien.Dock = DockStyle.Fill;
        dgvNhanVien.BackgroundColor = Color.White;
        dgvNhanVien.BorderStyle = BorderStyle.None;
        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvNhanVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvNhanVien.MultiSelect = false;
        dgvNhanVien.ReadOnly = true;
        dgvNhanVien.AllowUserToAddRows = false;
        dgvNhanVien.RowHeadersVisible = false;
        dgvNhanVien.EnableHeadersVisualStyles = false;
        dgvNhanVien.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
        dgvNhanVien.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvNhanVien.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
        dgvNhanVien.ColumnHeadersHeight = 38;
        dgvNhanVien.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 239, 232);
        dgvNhanVien.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 39, 44);
        dgvNhanVien.RowTemplate.Height = 34;
        dgvNhanVien.DataError += (_, e) => { e.ThrowException = false; };
        dgvNhanVien.CellClick += DgvNhanVien_CellClick;
    }

    private void BuildEditor(Control parent)
    {
        var editor = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Padding = new Padding(16), AutoScroll = true };
        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            AutoSize = true,
            ColumnCount = 1,
            RowCount = 0,
            Padding = new Padding(2)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        AddEditorTitle(layout, "Thông tin nhân viên");
        AddField(layout, "Họ tên", txtHoTen);
        AddField(layout, "Số điện thoại", txtSoDienThoai);
        AddField(layout, "Email", txtEmail);
        AddEditorTitle(layout, "Tài khoản đăng nhập");
        AddField(layout, "Tên đăng nhập", txtTenDangNhap);
        AddField(layout, "Mật khẩu", txtMatKhau);
        txtMatKhau.UseSystemPasswordChar = true;
        AddField(layout, "Quyền", cboQuyen);
        cboQuyen.DropDownStyle = ComboBoxStyle.DropDownList;
        chkTrangThai.Text = "Tài khoản đang hoạt động";
        chkTrangThai.AutoSize = true;
        chkTrangThai.ForeColor = Color.FromArgb(44, 62, 80);
        layout.Controls.Add(chkTrangThai);
        layout.Controls.Add(lblMessage);
        lblMessage.ForeColor = Color.FromArgb(192, 57, 43);
        lblMessage.AutoSize = true;
        lblMessage.Padding = new Padding(0, 6, 0, 6);

        var buttons = new FlowLayoutPanel { Dock = DockStyle.Top, AutoSize = true, WrapContents = true, Padding = new Padding(0, 4, 0, 0) };
        ConfigureButton(btnThem, "Thêm", buttons, Color.FromArgb(26, 188, 156));
        ConfigureButton(btnSua, "Sửa", buttons, Color.FromArgb(52, 152, 219));
        ConfigureButton(btnKhoa, "Khóa / Mở", buttons, Color.FromArgb(230, 126, 34));
        ConfigureButton(btnLuu, "Lưu", buttons, Color.FromArgb(39, 174, 96));
        ConfigureButton(btnHuy, "Hủy", buttons, Color.FromArgb(127, 140, 141));
        ConfigureButton(btnLamMoi, "Làm mới", buttons, Color.FromArgb(44, 62, 80));
        editor.Controls.Add(buttons);
        editor.Controls.Add(layout);
        parent.Controls.Add(editor);
    }

    private static void AddEditorTitle(TableLayoutPanel layout, string text)
    {
        var label = new Label
        {
            Text = text,
            AutoSize = true,
            Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold),
            ForeColor = Color.FromArgb(44, 62, 80),
            Padding = new Padding(0, 10, 0, 4)
        };
        layout.Controls.Add(label);
    }

    private static void AddField(TableLayoutPanel layout, string labelText, Control field)
    {
        layout.Controls.Add(new Label { Text = labelText, AutoSize = true, ForeColor = Color.FromArgb(70, 83, 92), Padding = new Padding(0, 4, 0, 2) });
        field.Dock = DockStyle.Top;
        field.Height = 30;
        if (field is TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.FromArgb(248, 249, 250);
        }
        layout.Controls.Add(field);
    }

    private static void ConfigureButton(Button button, string text, FlowLayoutPanel panel, Color color)
    {
        button.Text = text;
        button.Width = 98;
        button.Height = 34;
        button.Margin = new Padding(0, 3, 5, 3);
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = color;
        button.ForeColor = Color.White;
        button.Cursor = Cursors.Hand;
        panel.Controls.Add(button);
    }

    private void ConfigureActions()
    {
        btnThem.Click += (_, _) => BeginAdd();
        btnSua.Click += (_, _) => BeginEdit();
        btnKhoa.Click += (_, _) => ToggleSelectedStatus();
        btnLuu.Click += (_, _) => SaveEmployee();
        btnHuy.Click += (_, _) => ResetEditor();
        btnLamMoi.Click += (_, _) => RefreshData();
    }

    private void FrmNhanVien_Load(object? sender, EventArgs e)
    {
        try
        {
            cboQuyen.DisplayMember = "TenQuyen";
            cboQuyen.ValueMember = "MaQuyen";
            cboQuyen.DataSource = _nhanVienBLL.GetAllQuyen();
            LoadEmployees();
            SetEditorEnabled(false);
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void LoadEmployees()
    {
        try
        {
            DataTable employees = _nhanVienBLL.SearchNhanVien(txtTimKiem.Text);
            employees.Columns.Add("TrangThaiHienThi", typeof(string));
            foreach (DataRow employee in employees.Rows)
            {
                bool isActive = !employee.IsNull("TrangThai") && Convert.ToBoolean(employee["TrangThai"]);
                employee["TrangThaiHienThi"] = isActive ? "Hoạt động" : "Bị khóa";
            }

            dgvNhanVien.DataSource = employees;
            if (dgvNhanVien.Columns.Contains("MaTaiKhoan")) dgvNhanVien.Columns["MaTaiKhoan"].Visible = false;
            if (dgvNhanVien.Columns.Contains("MaQuyen")) dgvNhanVien.Columns["MaQuyen"].Visible = false;
            if (dgvNhanVien.Columns.Contains("TrangThai")) dgvNhanVien.Columns["TrangThai"].Visible = false;
            SetHeader("MaNV", "Mã NV");
            SetHeader("HoTen", "Họ tên");
            SetHeader("SoDienThoai", "Số điện thoại");
            SetHeader("Email", "Email");
            SetHeader("TenDangNhap", "Tên đăng nhập");
            SetHeader("TenQuyen", "Vai trò");
            SetHeader("TrangThaiHienThi", "Trạng thái");
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void SetHeader(string column, string header)
    {
        if (dgvNhanVien.Columns.Contains(column)) dgvNhanVien.Columns[column].HeaderText = header;
    }

    private void DgvNhanVien_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
        _selectedMaNV = Convert.ToInt32(row.Cells["MaNV"].Value);
        _selectedMaTaiKhoan = Convert.ToInt32(row.Cells["MaTaiKhoan"].Value);
        txtHoTen.Text = Convert.ToString(row.Cells["HoTen"].Value);
        txtSoDienThoai.Text = Convert.ToString(row.Cells["SoDienThoai"].Value);
        txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
        txtTenDangNhap.Text = Convert.ToString(row.Cells["TenDangNhap"].Value);
        txtMatKhau.Clear();
        cboQuyen.SelectedValue = Convert.ToInt32(row.Cells["MaQuyen"].Value);
        chkTrangThai.Checked = Convert.ToBoolean(row.Cells["TrangThai"].Value);
        _editMode = EditMode.View;
        SetEditorEnabled(false);
        lblMessage.Text = string.Empty;
    }

    private void BeginAdd()
    {
        _selectedMaNV = 0;
        _selectedMaTaiKhoan = 0;
        _editMode = EditMode.Add;
        ClearFields();
        chkTrangThai.Checked = true;
        SetEditorEnabled(true);
        txtTenDangNhap.Enabled = true;
        txtMatKhau.Enabled = true;
        dgvNhanVien.ClearSelection();
        txtHoTen.Focus();
    }

    private void BeginEdit()
    {
        if (_selectedMaNV == 0)
        {
            MessageBox.Show("Vui lòng chọn nhân viên cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        _editMode = EditMode.Edit;
        SetEditorEnabled(true);
        txtMatKhau.PlaceholderText = "Để trống nếu không đổi mật khẩu";
        txtTenDangNhap.Enabled = true;
    }

    private void SaveEmployee()
    {
        try
        {
            NhanVienDTO employee = ReadEmployeeFields();
            if (_editMode == EditMode.Add)
            {
                _nhanVienBLL.InsertNhanVien(employee);
                MessageBox.Show("Đã thêm nhân viên và tài khoản.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (_editMode == EditMode.Edit)
            {
                employee.MaNV = _selectedMaNV;
                employee.MaTaiKhoan = _selectedMaTaiKhoan;
                if (!_nhanVienBLL.UpdateNhanVien(employee))
                {
                    throw new InvalidOperationException("Không tìm thấy nhân viên hoặc tài khoản cần cập nhật.");
                }
                MessageBox.Show("Đã cập nhật thông tin nhân viên.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
            RefreshData();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private NhanVienDTO ReadEmployeeFields() => new()
    {
        HoTen = txtHoTen.Text.Trim(),
        SoDienThoai = txtSoDienThoai.Text.Trim(),
        Email = txtEmail.Text.Trim(),
        TenDangNhap = txtTenDangNhap.Text.Trim(),
        MatKhau = txtMatKhau.Text,
        MaQuyen = cboQuyen.SelectedValue is null ? 0 : Convert.ToInt32(cboQuyen.SelectedValue),
        TrangThai = chkTrangThai.Checked
    };

    private void ToggleSelectedStatus()
    {
        if (_selectedMaNV == 0)
        {
            MessageBox.Show("Vui lòng chọn nhân viên cần khóa hoặc mở khóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        try
        {
            int newStatus = chkTrangThai.Checked ? 0 : 1;
            if (_nhanVienBLL.DoiTrangThai(_selectedMaNV, newStatus))
            {
                RefreshData();
                MessageBox.Show(newStatus == 0 ? "Đã khóa tài khoản." : "Đã mở khóa tài khoản.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void RefreshData()
    {
        LoadEmployees();
        ResetEditor();
    }

    private void ResetEditor()
    {
        _editMode = EditMode.View;
        _selectedMaNV = 0;
        _selectedMaTaiKhoan = 0;
        ClearFields();
        SetEditorEnabled(false);
        lblMessage.Text = string.Empty;
        dgvNhanVien.ClearSelection();
    }

    private void ClearFields()
    {
        txtHoTen.Clear();
        txtSoDienThoai.Clear();
        txtEmail.Clear();
        txtTenDangNhap.Clear();
        txtMatKhau.Clear();
        if (cboQuyen.Items.Count > 0) cboQuyen.SelectedIndex = 0;
        chkTrangThai.Checked = false;
    }

    private void SetEditorEnabled(bool enabled)
    {
        txtHoTen.Enabled = enabled;
        txtSoDienThoai.Enabled = enabled;
        txtEmail.Enabled = enabled;
        txtTenDangNhap.Enabled = enabled;
        txtMatKhau.Enabled = enabled;
        cboQuyen.Enabled = enabled;
        chkTrangThai.Enabled = enabled;
        btnLuu.Enabled = enabled;
        btnThem.Enabled = !enabled;
        btnSua.Enabled = !enabled && _selectedMaNV > 0;
        btnKhoa.Enabled = !enabled && _selectedMaNV > 0;
        btnHuy.Enabled = enabled || _selectedMaNV > 0;
    }

    private void ShowError(Exception ex)
    {
        string message = ex is SqlException ? "Không thể truy cập cơ sở dữ liệu. Kiểm tra SQL Server và cấu hình kết nối." : ex.Message;
        lblMessage.Text = message;
        if (Visible) MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

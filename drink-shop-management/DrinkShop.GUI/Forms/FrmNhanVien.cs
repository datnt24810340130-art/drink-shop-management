using System.Data;
using DrinkShop.BLL;
using DrinkShop.DTO;
using Microsoft.Data.SqlClient;

namespace DrinkShop.GUI.Forms;

public partial class FrmNhanVien : Form
{
    private enum EditMode { View, Add, Edit }

    private readonly NhanVienBLL _nhanVienBLL = new();
    private EditMode _editMode;
    private int _selectedMaNV;
    private int _selectedMaTaiKhoan;

    public FrmNhanVien()
    {
        InitializeComponent();
    }

    private void btnThem_Click(object? sender, EventArgs e) => BeginAdd();

    private void btnSua_Click(object? sender, EventArgs e) => BeginEdit();

    private void btnKhoa_Click(object? sender, EventArgs e) => ToggleSelectedStatus();

    private void btnLuu_Click(object? sender, EventArgs e) => SaveEmployee();

    private void btnHuy_Click(object? sender, EventArgs e) => ResetEditor();

    private void btnLamMoi_Click(object? sender, EventArgs e) => RefreshData();

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

    private void txtTimKiem_TextChanged(object? sender, EventArgs e)
    {
        LoadEmployees();
    }

    private void SetHeader(string column, string header)
    {
        if (dgvNhanVien.Columns.Contains(column)) dgvNhanVien.Columns[column].HeaderText = header;
    }

    private void DgvNhanVien_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;
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

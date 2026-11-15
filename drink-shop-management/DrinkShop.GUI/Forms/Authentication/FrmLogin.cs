using DrinkShop.BLL;
using DrinkShop.GUI.Helpers;
using Microsoft.Data.SqlClient;

namespace DrinkShop.GUI.Forms;

public partial class FrmLogin : Form
{
    private readonly TaiKhoanBLL _taiKhoanBLL = new();

    public FrmLogin()
    {
        InitializeComponent();
    }

    private void FrmLogin_Shown(object? sender, EventArgs e)
    {
        txtUsername.Focus();
    }

    private void Card_Paint(object? sender, PaintEventArgs e)
    {
        using var pen = new Pen(Color.FromArgb(70, 88, 104));
        e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
    }

    private void ChkShowPassword_CheckedChanged(object? sender, EventArgs e)
    {
        txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
    }

    private void BtnExit_Click(object? sender, EventArgs e)
    {
        Application.Exit();
    }

    private void BtnLogin_Click(object? sender, EventArgs e)
    {
        lblError.Text = string.Empty;
        btnLogin.Enabled = false;
        try
        {
            var account = _taiKhoanBLL.DangNhap(txtUsername.Text, txtPassword.Text, out string errorMessage);
            if (account is null)
            {
                lblError.Text = errorMessage;
                return;
            }

            UserSession.Start(account);
            Hide();
            using var mainForm = new FrmMain();
            mainForm.ShowDialog(this);
            UserSession.Clear();
            Close();
        }
        catch (SqlException)
        {
            lblError.Text = "Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra SQL Server và cấu hình.";
        }
        catch (InvalidOperationException ex)
        {
            lblError.Text = ex.Message;
        }
        finally
        {
            btnLogin.Enabled = true;
        }
    }
}

using DrinkShop.BLL;
using DrinkShop.GUI.Helpers;
using Microsoft.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace DrinkShop.GUI.Forms;

public sealed class FrmLogin : Form
{
    private readonly TaiKhoanBLL _taiKhoanBLL = new();
    private readonly TextBox txtUsername = new();
    private readonly TextBox txtPassword = new();
    private readonly CheckBox chkShowPassword = new();
    private readonly Button btnLogin = new();
    private readonly Button btnExit = new();
    private readonly Label lblError = new();

    public FrmLogin()
    {
        InitializeUi();
    }

    private void InitializeUi()
    {
        Text = "Drink Shop | Đăng nhập";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        ClientSize = new Size(480, 560);
        BackColor = Color.FromArgb(30, 39, 44);
        Font = new Font("Segoe UI", 10F);
        AcceptButton = btnLogin;
        CancelButton = btnExit;

        var card = new Panel
        {
            Size = new Size(370, 460),
            Location = new Point(55, 50),
            BackColor = Color.FromArgb(44, 62, 80),
            Padding = new Padding(30)
        };
        card.Paint += (_, e) =>
        {
            using var pen = new Pen(Color.FromArgb(70, 88, 104));
            e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
        };

        var lblBrand = new Label
        {
            Text = "DRINK SHOP",
            Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(82, 36)
        };
        var lblSubtitle = new Label
        {
            Text = "Đăng nhập để tiếp tục",
            ForeColor = Color.FromArgb(190, 202, 210),
            AutoSize = true,
            Location = new Point(94, 78)
        };
        var lblUsername = CreateLabel("Tên đăng nhập", 26, 132);
        ConfigureInput(txtUsername, 26, 158, "Nhập tên đăng nhập");
        var lblPassword = CreateLabel("Mật khẩu", 26, 218);
        ConfigureInput(txtPassword, 26, 244, "Nhập mật khẩu");
        txtPassword.UseSystemPasswordChar = true;

        chkShowPassword.Text = "Hiển thị mật khẩu";
        chkShowPassword.AutoSize = true;
        chkShowPassword.ForeColor = Color.FromArgb(220, 228, 233);
        chkShowPassword.Location = new Point(26, 290);
        chkShowPassword.CheckedChanged += (_, _) => txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;

        lblError.AutoSize = false;
        lblError.ForeColor = Color.FromArgb(255, 142, 142);
        lblError.Location = new Point(26, 319);
        lblError.Size = new Size(290, 34);
        lblError.TextAlign = ContentAlignment.MiddleLeft;

        ConfigureButton(btnLogin, "ĐĂNG NHẬP", new Point(26, 365), Color.FromArgb(26, 188, 156));
        btnLogin.Click += BtnLogin_Click;
        ConfigureButton(btnExit, "THOÁT", new Point(26, 414), Color.FromArgb(65, 81, 94));
        btnExit.Click += (_, _) => Application.Exit();

        card.Controls.AddRange([lblBrand, lblSubtitle, lblUsername, txtUsername, lblPassword, txtPassword, chkShowPassword, lblError, btnLogin, btnExit]);
        Controls.Add(card);
        Shown += (_, _) => txtUsername.Focus();
    }

    private static Label CreateLabel(string text, int x, int y) => new()
    {
        Text = text,
        Location = new Point(x, y),
        AutoSize = true,
        ForeColor = Color.White,
        Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold)
    };

    private static void ConfigureInput(TextBox textBox, int x, int y, string placeholder)
    {
        textBox.Location = new Point(x, y);
        textBox.Size = new Size(290, 34);
        textBox.BorderStyle = BorderStyle.FixedSingle;
        textBox.BackColor = Color.FromArgb(34, 48, 59);
        textBox.ForeColor = Color.White;
        textBox.Font = new Font("Segoe UI", 10F);
        textBox.PlaceholderText = placeholder;
    }

    private static void ConfigureButton(Button button, string text, Point location, Color color)
    {
        button.Text = text;
        button.Location = location;
        button.Size = new Size(290, 40);
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = color;
        button.ForeColor = Color.White;
        button.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
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

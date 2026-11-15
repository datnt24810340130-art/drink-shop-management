#nullable disable

namespace DrinkShop.GUI.Forms;

partial class FrmLogin
{
    private System.ComponentModel.IContainer components = null;
    private Panel card;
    private Label lblBrand;
    private Label lblSubtitle;
    private Label lblUsername;
    private TextBox txtUsername;
    private Label lblPassword;
    private TextBox txtPassword;
    private CheckBox chkShowPassword;
    private Label lblError;
    private Button btnLogin;
    private Button btnExit;

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
        card = new Panel();
        lblBrand = new Label();
        lblSubtitle = new Label();
        lblUsername = new Label();
        txtUsername = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        chkShowPassword = new CheckBox();
        lblError = new Label();
        btnLogin = new Button();
        btnExit = new Button();
        card.SuspendLayout();
        SuspendLayout();
        // 
        // card
        // 
        card.BackColor = Color.FromArgb(44, 62, 80);
        card.Controls.Add(lblBrand);
        card.Controls.Add(lblSubtitle);
        card.Controls.Add(lblUsername);
        card.Controls.Add(txtUsername);
        card.Controls.Add(lblPassword);
        card.Controls.Add(txtPassword);
        card.Controls.Add(chkShowPassword);
        card.Controls.Add(lblError);
        card.Controls.Add(btnLogin);
        card.Controls.Add(btnExit);
        card.Location = new Point(55, 50);
        card.Name = "card";
        card.Padding = new Padding(30);
        card.Size = new Size(370, 460);
        card.TabIndex = 0;
        card.Paint += Card_Paint;
        // 
        // lblBrand
        // 
        lblBrand.AutoSize = true;
        lblBrand.Font = new Font("Segoe UI Semibold", 21F, FontStyle.Bold);
        lblBrand.ForeColor = Color.White;
        lblBrand.Location = new Point(82, 36);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(183, 38);
        lblBrand.TabIndex = 0;
        lblBrand.Text = "DRINK SHOP";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 10F);
        lblSubtitle.ForeColor = Color.FromArgb(190, 202, 210);
        lblSubtitle.Location = new Point(94, 78);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(144, 19);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Đăng nhập để tiếp tục";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblUsername.ForeColor = Color.White;
        lblUsername.Location = new Point(26, 132);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(99, 17);
        lblUsername.TabIndex = 2;
        lblUsername.Text = "Tên đăng nhập";
        // 
        // txtUsername
        // 
        txtUsername.BackColor = Color.FromArgb(34, 48, 59);
        txtUsername.BorderStyle = BorderStyle.FixedSingle;
        txtUsername.Font = new Font("Segoe UI", 10F);
        txtUsername.ForeColor = Color.White;
        txtUsername.Location = new Point(26, 158);
        txtUsername.Name = "txtUsername";
        txtUsername.PlaceholderText = "Nhập tên đăng nhập";
        txtUsername.Size = new Size(290, 25);
        txtUsername.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        lblPassword.ForeColor = Color.White;
        lblPassword.Location = new Point(26, 218);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(66, 17);
        lblPassword.TabIndex = 4;
        lblPassword.Text = "Mật khẩu";
        // 
        // txtPassword
        // 
        txtPassword.BackColor = Color.FromArgb(34, 48, 59);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.ForeColor = Color.White;
        txtPassword.Location = new Point(26, 244);
        txtPassword.Name = "txtPassword";
        txtPassword.PlaceholderText = "Nhập mật khẩu";
        txtPassword.Size = new Size(290, 25);
        txtPassword.TabIndex = 5;
        txtPassword.UseSystemPasswordChar = true;
        // 
        // chkShowPassword
        // 
        chkShowPassword.AutoSize = true;
        chkShowPassword.Font = new Font("Segoe UI", 10F);
        chkShowPassword.ForeColor = Color.FromArgb(220, 228, 233);
        chkShowPassword.Location = new Point(26, 290);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new Size(138, 23);
        chkShowPassword.TabIndex = 6;
        chkShowPassword.Text = "Hiển thị mật khẩu";
        chkShowPassword.UseVisualStyleBackColor = true;
        chkShowPassword.CheckedChanged += ChkShowPassword_CheckedChanged;
        // 
        // lblError
        // 
        lblError.Font = new Font("Segoe UI", 9.5F);
        lblError.ForeColor = Color.FromArgb(255, 142, 142);
        lblError.Location = new Point(26, 319);
        lblError.Name = "lblError";
        lblError.Size = new Size(290, 34);
        lblError.TabIndex = 7;
        lblError.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // btnLogin
        // 
        btnLogin.BackColor = Color.FromArgb(26, 188, 156);
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(26, 365);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(290, 40);
        btnLogin.TabIndex = 8;
        btnLogin.Text = "ĐĂNG NHẬP";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += BtnLogin_Click;
        // 
        // btnExit
        // 
        btnExit.BackColor = Color.FromArgb(65, 81, 94);
        btnExit.Cursor = Cursors.Hand;
        btnExit.FlatAppearance.BorderSize = 0;
        btnExit.FlatStyle = FlatStyle.Flat;
        btnExit.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
        btnExit.ForeColor = Color.White;
        btnExit.Location = new Point(26, 414);
        btnExit.Name = "btnExit";
        btnExit.Size = new Size(290, 40);
        btnExit.TabIndex = 9;
        btnExit.Text = "THOÁT";
        btnExit.UseVisualStyleBackColor = false;
        btnExit.Click += BtnExit_Click;
        // 
        // FrmLogin
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 39, 44);
        CancelButton = btnExit;
        ClientSize = new Size(480, 560);
        Controls.Add(card);
        Font = new Font("Segoe UI", 10F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Drink Shop | Đăng nhập";
        Shown += FrmLogin_Shown;
        card.ResumeLayout(false);
        card.PerformLayout();
        ResumeLayout(false);
    }
}


#nullable disable

namespace DrinkShop.GUI.Forms;

partial class FrmBanHang
{
    private System.ComponentModel.IContainer components = null;
    private Label lblTitle;
    private Label lblPlaceholder;

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
        lblTitle = new Label();
        lblPlaceholder = new Label();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
        lblTitle.Location = new Point(20, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(960, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Bán hàng POS & Đặt món";
        lblTitle.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblPlaceholder
        // 
        lblPlaceholder.Dock = DockStyle.Top;
        lblPlaceholder.Font = new Font("Segoe UI", 11F);
        lblPlaceholder.ForeColor = Color.FromArgb(100, 112, 121);
        lblPlaceholder.Location = new Point(20, 65);
        lblPlaceholder.Name = "lblPlaceholder";
        lblPlaceholder.Size = new Size(960, 40);
        lblPlaceholder.TabIndex = 1;
        lblPlaceholder.Text = "Khung giao diện bán hàng POS (Phụ trách: Nguyễn Trọng Hiếu). Kéo thả controls tại đây.";
        lblPlaceholder.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // FrmBanHang
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(245, 247, 248);
        ClientSize = new Size(1000, 650);
        Controls.Add(lblPlaceholder);
        Controls.Add(lblTitle);
        Font = new Font("Segoe UI", 9.5F);
        Name = "FrmBanHang";
        Padding = new Padding(20);
        Text = "Bán hàng POS";
        ResumeLayout(false);
    }
}

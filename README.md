# Drink Shop Management System

Phần mềm quản lý quán nước (trà sữa, cà phê) được xây dựng bằng **C# Windows Forms**, nền tảng **.NET** và cơ sở dữ liệu **Microsoft SQL Server**. Dự án phục vụ đồ án môn **Lập trình .NET** - Khoa Công nghệ Thông tin, Trường Đại học Điện Lực (EPU), được phát triển theo nhóm 3 thành viên:
- **Nguyễn Thành Đạt** (Trưởng nhóm / Phụ trách Hệ thống & Kiến trúc)
- **Nguyễn Trọng Hiếu** (Thành viên / Phụ trách Bán hàng POS & Bàn nước)
- **Lê Tuấn Anh** (Thành viên / Phụ trách Quản lý Thực đơn & Báo cáo)

> ⚠️ **Lưu ý quan trọng:** Trước khi bắt đầu code, cả nhóm cần thống nhất phiên bản .NET mục tiêu (.NET 8.0 Windows Desktop), phiên bản SQL Server, tên namespace `DrinkShop` và cấu trúc Solution. Không tự ý thay đổi các quy ước này khi chưa trao đổi và thống nhất với cả nhóm.

---

## 1. Mục tiêu dự án
Xây dựng ứng dụng desktop hỗ trợ các nghiệp vụ quản lý bán hàng cơ bản và chuyên nghiệp cho một quán nước:
- Đăng nhập, phân quyền và quản lý tài khoản nhân viên.
- Quản lý danh mục đồ uống và danh sách sản phẩm (kèm hình ảnh minh họa).
- Quản lý sơ đồ bàn trực quan theo trạng thái phục vụ (*Trống*, *Có khách*, *Đã đặt*).
- Lập order bán hàng tại bàn (POS), hỗ trợ ghi chú định lượng (đường/đá/topping).
- Xử lý chuyển bàn, gộp bàn khi khách đổi chỗ.
- Lập hóa đơn, tính chiết khấu, tính tiền thừa và in phiếu tính tiền.
- Báo cáo doanh thu theo ngày/tháng/năm và thống kê top sản phẩm bán chạy kèm biểu đồ.

Phạm vi ban đầu được thiết kế ở mức vừa phải, chặt chẽ để cả nhóm 3 người có thể hoàn thành, tích hợp và kiểm thử đúng hạn.

---

## 2. Công nghệ sử dụng

| Thành phần | Công nghệ lựa chọn |
| :--- | :--- |
| **Ngôn ngữ** | C# (10.0 / 12.0) |
| **Giao diện** | Windows Forms (WinForms) với phong cách Modern Flat UI |
| **Nền tảng** | .NET 8.0 Windows Desktop (LTS) |
| **Cơ sở dữ liệu** | Microsoft SQL Server 2019 / 2022 / SQL Express |
| **Công cụ quản trị DB** | SQL Server Management Studio (SSMS) |
| **Kết nối DB** | ADO.NET thuần (`Microsoft.Data.SqlClient`), Parameterized Queries |
| **IDE** | Visual Studio 2022 Community (Workload: *.NET desktop development*) |
| **Quản lý mã nguồn** | Git và GitHub |

*Tất cả thành viên bắt buộc dùng cùng phiên bản Visual Studio và .NET phù hợp với Solution để tránh lỗi tương thích khi build.*

---

## 3. Phạm vi chức năng và phân công

### 👤 Thành viên 1: Nguyễn Thành Đạt — Hệ thống & Nền tảng
- `FrmLogin`: Đăng nhập, xác thực tài khoản và lưu phiên làm việc.
- `FrmMain`: Màn hình chính, thanh điều hướng (Sidebar) và cơ chế nhúng Form con vào Content Panel.
- `FrmNhanVien`: Quản lý danh sách nhân viên, tài khoản và phân quyền (Admin / Thu ngân).
- **Trách nhiệm kỹ thuật**: Thiết kế kiến trúc 3 lớp, xây dựng `DatabaseHelper.cs`, quản lý file schema SQL Server, điều phối GitHub repository, thiết lập quy ước code, tích hợp và kiểm thử tổng thể.

### 👤 Thành viên 2: Nguyễn Trọng Hiếu — Bán hàng POS & Bàn nước
- `FrmBan`: Quản lý danh sách và sơ đồ bàn (thêm, sửa, xóa, đổi trạng thái bàn).
- `FrmBanHang` (hoặc `FrmPOS`): Giao diện bán hàng trực quan (sơ đồ bàn đổi màu, menu chọn món nhanh, giỏ hàng, tăng/giảm số lượng, ghi chú đường/đá).
- `FrmHoaDon`: Quản lý danh sách hóa đơn, xem chi tiết hóa đơn cũ, thanh toán và in phiếu tính tiền.
- **Nghiệp vụ phối hợp**: Xử lý chuyển bàn, gộp bàn và áp dụng giao dịch `SqlTransaction` khi thanh toán.

### 👤 Thành viên 3: Lê Tuấn Anh — Thực đơn & Báo cáo Thống kê
- `FrmDanhMuc`: Quản lý danh mục đồ uống (thêm, sửa, xóa, tìm kiếm danh mục).
- `FrmSanPham`: Quản lý sản phẩm đồ uống (thêm, sửa, xóa, upload ảnh món, định dạng giá bán VNĐ).
- `FrmThongKe`: Màn hình Dashboard KPI, thống kê doanh thu theo mốc thời gian, bảng xếp hạng Top 5 đồ uống bán chạy nhất và trực quan hóa bằng biểu đồ Chart.

*Phân công trên là phân công chính. Các thành viên vẫn cần phối hợp chặt chẽ khi chức năng của mình sử dụng dữ liệu do thành viên khác quản lý.*

---

## 4. Danh mục hàng hóa ban đầu
Dự án sử dụng **6 danh mục đồ uống chuẩn thực tế** để dữ liệu demo gọn gàng, đẹp mắt và dễ kiểm thử:

| Mã danh mục | Tên danh mục | Sản phẩm demo tiêu biểu | Đơn giá mẫu |
| :---: | :--- | :--- | :---: |
| **DM01** | Cà phê | Cà phê đen, Cà phê sữa, Bạc xỉu, Espresso | 20.000 - 35.000 đ |
| **DM02** | Trà sữa | Trà sữa truyền thống, Trà sữa Thái xanh, Trà sữa Ô long | 30.000 - 45.000 đ |
| **DM03** | Trà trái cây | Trà đào cam sả, Trà vải lài, Trà dâu tằm | 35.000 - 45.000 đ |
| **DM04** | Đá xay (Freeze) | Freeze trà xanh matcha, Cà phê đá xay, Choco Freeze | 40.000 - 50.000 đ |
| **DM05** | Nước ép & Sinh tố | Nước ép cam tươi, Nước dưa hấu, Sinh tố bơ | 30.000 - 45.000 đ |
| **DM06** | Bánh & Topping | Bánh Tiramisu, Cheesecake, Trân châu đen, Pudding | 10.000 - 35.000 đ |

Có thể bổ sung danh mục sau khi cả nhóm thống nhất. Mỗi sản phẩm thuộc về một danh mục. Một danh mục có thể chứa nhiều sản phẩm.

---

## 5. Cấu trúc Solution và thư mục

### Cấu trúc mục tiêu:
```
DrinkShop/
├── DrinkShop.sln
│
├── DrinkShop.GUI/
│   ├── Forms/
│   │   ├── FrmLogin.cs
│   │   ├── FrmMain.cs
│   │   ├── FrmNhanVien.cs
│   │   ├── FrmDanhMuc.cs
│   │   ├── FrmSanPham.cs
│   │   ├── FrmBan.cs
│   │   ├── FrmBanHang.cs
│   │   ├── FrmHoaDon.cs
│   │   └── FrmThongKe.cs
│   ├── Helpers/
│   │   └── FormHelper.cs              # Hỗ trợ nhúng Form vào Panel nội dung
│   ├── UserControls/                  # Các thẻ hiển thị bàn, món nước
│   ├── Program.cs
│   └── App.config
│
├── DrinkShop.BLL/
│   ├── TaiKhoanBLL.cs
│   ├── NhanVienBLL.cs
│   ├── DanhMucBLL.cs
│   ├── SanPhamBLL.cs
│   ├── BanBLL.cs
│   ├── HoaDonBLL.cs
│   └── ThongKeBLL.cs
│
├── DrinkShop.DAL/
│   ├── Database/
│   │   └── DatabaseHelper.cs          # Quản lý kết nối SQL Server & thực thi câu lệnh
│   ├── TaiKhoanDAL.cs
│   ├── NhanVienDAL.cs
│   ├── DanhMucDAL.cs
│   ├── SanPhamDAL.cs
│   ├── BanDAL.cs
│   ├── HoaDonDAL.cs
│   └── ThongKeDAL.cs
│
├── DrinkShop.DTO/
│   ├── TaiKhoanDTO.cs
│   ├── NhanVienDTO.cs
│   ├── DanhMucDTO.cs
│   ├── SanPhamDTO.cs
│   ├── BanDTO.cs
│   ├── HoaDonDTO.cs
│   ├── ChiTietHoaDonDTO.cs
│   └── ThongKeDTO.cs
│
├── Database/
│   ├── DrinkShopDB.sql                # Script tạo Database, bảng, khóa chính, khóa ngoại
│   └── SampleData.sql                 # Dữ liệu khởi tạo mẫu
│
├── Documents/
│   ├── ERD.png
│   ├── DeCuongBaoCao.docx
│   └── PhanCongCongViec.docx
│
└── README.md
```

*Đây là cấu trúc định hướng; không cần tạo tất cả file rỗng ngay lập tức. Khi tạo project, kiểm tra đúng loại project Windows Forms App và phiên bản .NET mà nhóm đã chốt.*

### Ý nghĩa các tầng:
- **GUI (Presentation)**: Hiển thị Form, nhận thao tác tương tác của người dùng và gọi xuống BLL.
- **BLL (Business Logic)**: Kiểm tra tính hợp lệ của dữ liệu (validate) và xử lý quy tắc nghiệp vụ kinh doanh.
- **DAL (Data Access)**: Thực hiện các câu truy vấn cơ sở dữ liệu SQL Server thông qua ADO.NET.
- **DTO (Data Transfer Object)**: Các lớp đối tượng dùng để chứa và truyền tải dữ liệu giữa các tầng.

### Quan hệ tham chiếu project đề xuất:
```
DrinkShop.GUI  -> DrinkShop.BLL
DrinkShop.GUI  -> DrinkShop.DTO

DrinkShop.BLL  -> DrinkShop.DAL
DrinkShop.BLL  -> DrinkShop.DTO

DrinkShop.DAL  -> DrinkShop.DTO
```

> ⛔ **Quy tắc quan trọng:**
> - Không để GUI truy vấn SQL trực tiếp hoặc tham chiếu trực tiếp đến DAL.
> - Không đặt mật khẩu database trong mã nguồn được đẩy lên GitHub.

---

## 6. Cơ sở dữ liệu dùng chung
Cả nhóm sử dụng một database SQL Server có tên **`DrinkShopDB`** với cùng một schema đã được thống nhất. Không tự tạo schema khác nhau cho từng thành viên.

### Các bảng dự kiến:
1. `Quyen` (MaQuyen, TenQuyen)
2. `TaiKhoan` (MaTaiKhoan, TenDangNhap, MatKhau, MaQuyen, TrangThai)
3. `NhanVien` (MaNV, HoTen, SoDienThoai, Email, MaTaiKhoan)
4. `DanhMuc` (MaDanhMuc, TenDanhMuc, TrangThai)
5. `SanPham` (MaSanPham, TenSanPham, MaDanhMuc, DonGia, HinhAnh, TrangThai)
6. `Ban` (MaBan, TenBan, TrangThai: *Trống / Có khách / Đã đặt*)
7. `HoaDon` (MaHoaDon, MaBan, MaNV, NgayTao, TongTien, GiamGia, TienKhachDua, TienThoi, TrangThai)
8. `ChiTietHoaDon` (MaCTHD, MaHoaDon, MaSanPham, SoLuong, DonGia, ThanhTien, GhiChu)

### Quan hệ nghiệp vụ chính:
- `SanPham` tham chiếu `DanhMuc`.
- `HoaDon` tham chiếu `Ban` và `NhanVien` lập hóa đơn.
- `ChiTietHoaDon` tham chiếu `HoaDon` và `SanPham`.
- `TaiKhoan` tham chiếu `Quyen` và liên kết 1-1 với `NhanVien`.

> **Quy tắc quan trọng:** Thành viên 1 (**Nguyễn Thành Đạt**) được phân công quản lý file schema chính `Database/DrinkShopDB.sql`. Khi cần sửa bảng hoặc cột, phải trao đổi với cả nhóm, cập nhật file SQL và thông báo trước khi các thành viên cập nhật code.

### Tạo database trong SSMS:
Mở SQL Server Management Studio (SSMS) và chạy:
```sql
CREATE DATABASE DrinkShopDB
COLLATE Vietnamese_CI_AS;
GO
USE DrinkShopDB;
GO
```
Sau khi hoàn thiện schema, chạy `Database/DrinkShopDB.sql`, sau đó chạy `Database/SampleData.sql` để tạo dữ liệu mẫu ban đầu.

*Không tự ý chạy script xóa/drop bảng trên database dùng chung. Khi thử nghiệm thao tác xóa hoặc bán hàng, nên dùng dữ liệu test đã thống nhất.*

### Kết nối SQL Server
Ví dụ Connection String minh họa trong `App.config`:
```xml
<connectionStrings>
    <!-- Nếu SQL Server chạy cục bộ trên máy thành viên (Windows Authentication) -->
    <add name="DrinkShopConn" 
         connectionString="Server=localhost;Database=DrinkShopDB;Trusted_Connection=True;TrustServerCertificate=True;" 
         providerName="Microsoft.Data.SqlClient" />

    <!-- Nếu dùng SQL Server Express -->
    <!-- <add name="DrinkShopConn" 
         connectionString="Server=.\SQLEXPRESS;Database=DrinkShopDB;Trusted_Connection=True;TrustServerCertificate=True;" 
         providerName="Microsoft.Data.SqlClient" /> -->

    <!-- Nếu dùng tài khoản SQL Server Authentication (app_user) -->
    <!-- <add name="DrinkShopConn" 
         connectionString="Server=localhost;Database=DrinkShopDB;User Id=app_user;Password=YOUR_PASSWORD;TrustServerCertificate=True;" 
         providerName="Microsoft.Data.SqlClient" /> -->
</connectionStrings>
```
- Nếu dùng máy chủ trong mạng LAN: thay `localhost` bằng IP máy chủ.
- Không commit mật khẩu thật vào Git.

---

## 7. Quy trình nghiệp vụ cần thống nhất

### Gọi món & Lập Order tại bàn
1. Chọn bàn cần phục vụ trên sơ đồ bàn (ví dụ: Bàn 03).
2. Kiểm tra trạng thái bàn:
   - Nếu bàn đang có khách: Tải lại danh sách món đã gọi trước đó.
   - Nếu bàn trống: Khởi tạo đơn mới cho bàn.
3. Chọn danh mục đồ uống và click chọn món.
4. Chọn số lượng và thêm ghi chú định lượng (ví dụ: "70% đường, 50% đá, thêm trân châu").
5. Nhấn **Lưu Order**: Hệ thống lưu thông tin vào `HoaDon` và `ChiTietHoaDon`, đồng thời cập nhật trạng thái bàn sang `'Có khách'`.

### Chuyển bàn và Gộp bàn
- **Chuyển bàn**: Chọn bàn cần chuyển (Bàn A) -> chọn Bàn B (phải đang trống) -> Cập nhật `MaBan = B` trong `HoaDon`, đổi trạng thái Bàn A thành `'Trống'` và Bàn B thành `'Có khách'`.
- **Gộp bàn**: Chuyển các món từ hóa đơn Bàn A sang hóa đơn Bàn B, đóng/hủy hóa đơn cũ của Bàn A và giải phóng Bàn A về trạng thái `'Trống'`.

### Thanh toán & Trả bàn
1. Chọn bàn cần thanh toán, kiểm tra lại danh sách món và tổng tiền món.
2. Nhập phần trăm giảm giá / chiết khấu (nếu có).
3. Hệ thống tự động tính tổng tiền thanh toán.
4. Nhập số tiền khách đưa -> Hệ thống tự động tính số tiền thừa trả khách.
5. Nhấn **Xác nhận thanh toán**:
   - Dùng **`SqlTransaction`** để cập nhật trạng thái hóa đơn sang `'Đã thanh toán'`, cập nhật phương thức thanh toán, và đổi trạng thái bàn tương ứng về `'Trống'` như một giao dịch thống nhất. Nếu phát sinh lỗi thì lập tức `Rollback`.
6. Hiển thị xem trước (Print Preview) và in phiếu hóa đơn thanh toán cho khách hàng.

---

## 8. Quy ước Git và GitHub

### Nhánh Git
```
main
└── develop
    ├── feature/system-management     # Thành viên 1: Đăng nhập, Main, Nhân viên, Core
    ├── feature/pos-sales-billing     # Thành viên 2: Bàn, Bán hàng POS, Hóa đơn
    └── feature/product-menu-report   # Thành viên 3: Danh mục, Sản phẩm, Thống kê
```
- `main`: Phiên bản ổn định nhất, dùng để bàn giao và demo với giảng viên.
- `develop`: Nhánh tích hợp các chức năng của cả nhóm.
- `feature/...`: Nhánh làm việc riêng theo phân công của từng thành viên.

### Lần đầu lấy project về máy
```bash
git clone <GITHUB_REPOSITORY_URL>
cd drink-shop-management
```

### Tạo nhánh cá nhân (Ví dụ Thành viên 2)
```bash
git checkout develop
git pull origin develop
git checkout -b feature/pos-sales-billing
```

### Lưu và đẩy code lên GitHub
```bash
git status
git add .
git commit -m "feat(pos): Hoan thien giao dien dat mon tai ban FrmBanHang"
git push -u origin feature/pos-sales-billing
```
Những lần tiếp theo:
```bash
git add .
git commit -m "fix(pos): Tinh toan chinh xac tien thoi va chiet khau"
git push
```

### Cập nhật code mới từ nhóm
Trước khi bắt đầu phiên làm việc:
```bash
git checkout develop
git pull origin develop
git checkout feature/pos-sales-billing
git merge develop
```
*Nếu phát sinh conflict, cần đọc và giải quyết từng file, kiểm tra build lại trong Visual Studio rồi mới commit.*

### Quy tắc làm việc nhóm trên Git:
- Không bao giờ push code trực tiếp lên `main`.
- Không tự ý merge khi chưa review mã nguồn.
- Không cùng sửa một Form hoặc một file cấu hình nếu chưa trao đổi trước.
- Commit theo từng chức năng nhỏ, thông điệp commit rõ ràng (theo chuẩn `feat:`, `fix:`, `refactor:`).
- Tuyệt đối không commit thư mục build: `bin/`, `obj/`, thư mục `.vs/`, file `*.user`.
- Không commit mật khẩu, chuỗi kết nối chứa thông tin bảo mật.
- Mỗi thành viên phải pull code mới nhất từ `develop` trước khi bắt đầu phiên làm việc.

---

## 9. Quy trình tích hợp Form

1. Thành viên hoàn thiện Form và các lớp BLL/DAL/DTO tương ứng.
2. Tự build và kiểm thử chức năng hoàn chỉnh trên máy cá nhân.
3. Commit và push code lên feature branch cá nhân.
4. Tạo Pull Request (PR) từ nhánh cá nhân vào nhánh `develop`.
5. Người phụ trách tích hợp (Thành viên 1) review thay đổi.
6. Merge PR khi code đã build thành công và không làm hỏng các chức năng hiện có.
7. Cả nhóm pull nhánh `develop` mới về máy và kiểm thử tích hợp.

### Cơ chế mở Form con đồng nhất trên `FrmMain`:
`FrmMain` là Form điều hướng chính. Các Form chức năng được mở từ các nút menu trên Sidebar của `FrmMain` và nhúng trực tiếp vào Panel nội dung (`pnlContent`) bằng helper dùng chung:

```csharp
// File DrinkShop.GUI/Helpers/FormHelper.cs
public static class FormHelper
{
    private static Form currentChildForm = null;

    public static void OpenChildForm(Form childForm, Panel targetPanel)
    {
        if (currentChildForm != null)
        {
            currentChildForm.Close();
            currentChildForm.Dispose();
        }

        currentChildForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;

        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(childForm);
        targetPanel.Tag = childForm;
        childForm.BringToFront();
        childForm.Show();
    }
}
```

---

## 10. Quy ước code

- Dùng **PascalCase** cho class, method, property: `SanPhamBLL`, `GetAllProducts()`, `DonGia`.
- Tên Form bắt đầu bằng **`Frm`**: `FrmLogin`, `FrmSanPham`, `FrmBanHang`.
- Tên lớp tầng nghiệp vụ kết thúc bằng **`BLL`**: `SanPhamBLL`.
- Tên lớp truy cập dữ liệu kết thúc bằng **`DAL`**: `SanPhamDAL`.
- Tên lớp dữ liệu kết thúc bằng **`DTO`**: `SanPhamDTO`.
- Tên bảng và tên cột phải tuân thủ chính xác theo schema database đã thống nhất trong `DrinkShopDB.sql`.
- **Dùng Parameterized Queries 100%**: Tuyệt đối không nối chuỗi trực tiếp từ ô nhập liệu để tạo câu SQL.
- Kiểm tra dữ liệu đầu vào (Validation) chặt chẽ và hiển thị thông báo lỗi thân thiện, dễ hiểu bằng tiếng Việt.
- Đóng/dispose connection, command và reader đúng cách; ưu tiên dùng cấu trúc **`using (...)`**.
- Không để một Form GUI chứa toàn bộ câu lệnh SQL và logic nghiệp vụ.

---

## 11. Checklist trước khi hoàn thành

### ⚙️ Môi trường
- [ ] Cả 3 máy thành viên đã cài đặt Visual Studio 2022 và workload *.NET Desktop Development*.
- [ ] Cả nhóm thống nhất phiên bản `.NET 8.0 Windows Desktop`.
- [ ] SQL Server và SSMS hoạt động ổn định.
- [ ] Clone được repository về máy và mở được `DrinkShop.sln`.
- [ ] Restore NuGet packages thành công.

### 🗄️ Database
- [ ] Có file schema `Database/DrinkShopDB.sql` chuẩn.
- [ ] Có file dữ liệu mẫu `Database/SampleData.sql`.
- [ ] Các khóa chính (PK), khóa ngoại (FK) và kiểu dữ liệu đã được thống nhất.
- [ ] Cả 3 thành viên kết nối được database thành công từ ứng dụng.
- [ ] Không lưu mật khẩu thật trong Git.

### 🎯 Chức năng
- [ ] Đăng nhập đúng/sai thông báo rõ ràng, phân quyền chuẩn (Admin / Thu ngân).
- [ ] CRUD danh mục đồ uống và sản phẩm đồ uống hoạt động chuẩn xác.
- [ ] Tìm kiếm dữ liệu sản phẩm, hóa đơn hoạt động mượt mà.
- [ ] Đổi trạng thái bàn chính xác (*Trống* -> *Có khách* -> *Trống*).
- [ ] Bán hàng POS: Gọi món, tăng/giảm số lượng, ghi chú món, tính tổng tiền, chiết khấu và tiền thừa chuẩn xác.
- [ ] Không cho phép thanh toán đơn hàng khi chưa chọn món.
- [ ] Dữ liệu hóa đơn và chi tiết hóa đơn nhất quán, có thể in lại.
- [ ] Thống kê doanh thu và hiển thị biểu đồ trực quan.

### 🚀 Tích hợp
- [ ] Tất cả Form được mở trơn tru từ `FrmMain` nhúng vào Panel nội dung.
- [ ] Không có lỗi build (0 Error, 0 Warning nghiêm trọng).
- [ ] Không có lỗi kết nối database khi chạy ứng dụng.
- [ ] Kiểm thử luồng bán hàng từ đầu đến cuối thành công.
- [ ] Nhánh `main` chứa phiên bản ổn định nhất sẵn sàng báo cáo.

---

## 12. Hướng dẫn chạy dự án

1. Cài đặt **Visual Studio Community 2022** và workload *.NET desktop development*.
2. Cài đặt **Microsoft SQL Server** (2019/2022 hoặc Express) và **SSMS**.
3. Clone repository về máy:
   ```bash
   git clone <GITHUB_REPOSITORY_URL>
   cd drink-shop-management
   ```
4. Mở file `DrinkShop.sln` bằng Visual Studio.
5. Mở SSMS, kết nối đến SQL Server cục bộ, chạy script `Database/DrinkShopDB.sql`, sau đó chạy `Database/SampleData.sql`.
6. Mở file `DrinkShop.GUI/App.config` và cấu hình lại chuỗi kết nối `DrinkShopConn` cho khớp với SQL Server của bạn.
7. Click chuột phải vào project `DrinkShop.GUI` trong Solution Explorer -> chọn **Set as Startup Project**.
8. Build Solution (`Ctrl + Shift + B`) và nhấn **F5** để khởi chạy ứng dụng.

*Nếu gặp lỗi, kiểm tra lần lượt: SQL Server Service đã Start chưa, tên Server trong App.config có đúng không, NuGet packages đã restore đủ chưa, và Startup Project đã chọn đúng DrinkShop.GUI chưa.*

---

## 13. Nguyên tắc phối hợp của nhóm

1. **Thống nhất thiết kế database trước khi code chức năng**: Mọi chức năng phụ thuộc vào dữ liệu đều phải chờ schema được chốt.
2. **Thống nhất quy ước chung**: Tên bảng, tên cột, namespace `DrinkShop`, tên project và quy ước đặt tên code.
3. **Trách nhiệm toàn diện**: Mỗi thành viên chịu trách nhiệm hoàn thiện cả GUI, BLL, DAL và DTO trong phạm vi chức năng được giao.
4. **Tôn trọng mã nguồn của nhau**: Thành viên phụ trách tích hợp không tự ý thay đổi code của người khác khi chưa trao đổi.
5. **Minh bạch thông tin**: Mọi thay đổi ảnh hưởng đến toàn hệ thống phải được thông báo ngay trong nhóm chat.
6. **Thường xuyên tích hợp và kiểm thử**: Merge code thường xuyên, không đợi đến sát ngày nộp đồ án mới ghép code.

> **Mục tiêu cuối cùng:** Cả nhóm cùng phát triển một ứng dụng **Drink Shop Management System** hoàn chỉnh, thống nhất, dùng chung một schema SQL Server và có thể clone repository về bất kỳ máy tính nào để build và chạy mượt mà theo đúng hướng dẫn trên.

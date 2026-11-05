# DRINK SHOP MANAGEMENT SYSTEM
> **Hệ thống Quản lý Quán nước / Trà sữa / Cafe**  
> Dự án môn học: **Lập trình .NET** - Trường Đại học Điện Lực (EPU)

---

## 👥 THÀNH VIÊN THỰC HIỆN DỰ ÁN
1. **Nguyễn Thành Đạt** (Trưởng nhóm / Lead Developer / System Architect)
2. **Nguyễn Trọng Hiếu** (Core Developer / UI-UX & POS Specialist)
3. **Lê Tuấn Anh** (Core Developer / Business Logic & Reporting Specialist)

---

## 🎯 MA TRẬN TRÁCH NHIỆM (RACI MATRIX)

> **Quy ước chuẩn quốc tế:**
> - **R (Responsible)**: Người trực tiếp thực hiện công việc.
> - **A (Accountable)**: Người chịu trách nhiệm chính, kiểm tra và nghiệm thu sản phẩm.
> - **C (Consulted)**: Người hỗ trợ, cố vấn chuyên môn, phối hợp thực hiện.
> - **I (Informed)**: Người được thông báo tiến độ, kết quả công việc.

| STT | Giai đoạn / Module chức năng | Nguyễn Thành Đạt | Nguyễn Trọng Hiếu | Lê Tuấn Anh |
| :---: | :--- | :---: | :---: | :---: |
| **1** | **Khởi tạo kiến trúc 3 lớp & Database (`DrinkShopDB`)** | **A / R** | C | C |
| **2** | **Xây dựng Data Access Layer (`DatabaseHelper.cs`) & DTOs** | **A / R** | I | I |
| **3** | **Thiết kế UI Khung Master (`FrmMain`, Sidebar điều hướng)** | A | **R** | C |
| **4** | **Phân hệ Đăng nhập, Xác thực & Phân quyền (`FrmLogin`)** | **A / R** | C | I |
| **5** | **Phân hệ Quản lý Danh mục & Sản phẩm (`FrmCategory`, `FrmProduct`)** | A | C | **R** |
| **6** | **Phân hệ Sơ đồ Bàn & Bán hàng POS (`FrmTable`, `FrmPOS`)** | A | **R** | C |
| **7** | **Phân hệ Quản lý Hóa đơn & In ấn (`FrmInvoice`, `PrintPreview`)** | A | **R** | C |
| **8** | **Phân hệ Quản lý Nhân viên & Tài khoản (`FrmEmployee`)** | A | C | **R** |
| **9** | **Phân hệ Báo cáo Doanh thu & Dashboard Chart (`FrmStatistic`, `FrmDashboard`)** | A | C | **R** |
| **10**| **Xử lý ngoại lệ toàn cục, Tối ưu hóa & Kiểm thử tích hợp** | **A / R** | R | R |
| **11**| **Đóng gói phần mềm & Hoàn thiện báo cáo đồ án** | **A** | R | R |

---

## 📌 TỔNG QUAN DỰ ÁN
**Drink Shop Management System** là ứng dụng desktop xây dựng trên nền tảng **C# Windows Forms** kết hợp cơ sở dữ liệu **Microsoft SQL Server**, giao tiếp trực tiếp qua công nghệ **ADO.NET** (thuần parameterized queries / stored procedures, không dùng ORM, không dùng mock data).

### Mục tiêu kỹ thuật & Trải nghiệm
- **Kiến trúc phân lớp chuẩn (3-Layer Architecture)**: Tách bạch rõ ràng giữa Giao diện (Presentation / GUI) - Nghiệp vụ (Business Logic Layer - BLL) - Truy cập dữ liệu (Data Access Layer - DAL) và Đối tượng truyền tải (DTO/Entities).
- **Giao diện người dùng (UI/UX) hiện đại**: Tối ưu màu sắc hiện đại (Flat UI, Dark/Light accents, bo góc, icon trực quan), sơ đồ bàn tương tác trực quan theo màu trạng thái, thẻ sản phẩm trực quan.
- **Tính toàn vẹn dữ liệu**: Ràng buộc toàn vẹn cơ sở dữ liệu (Primary Key, Foreign Key, Check Constraints, Cascading Rules) xử lý chặt chẽ tại SQL Server.
- **Bảo mật & Hiệu năng**: Chống tấn công SQL Injection bằng `SqlParameter`, mã hóa mật khẩu, quản lý kết nối `SqlConnection` tối ưu qua `using` blocks.

---

## 🏗️ KIẾN TRÚC HỆ THỐNG (3-TIER ARCHITECTURE)

```
DrinkShopManagement/
│
├── DrinkShop.DTO/                # Data Transfer Objects (Entity models)
│   ├── RoleDTO.cs
│   ├── UserDTO.cs
│   ├── CategoryDTO.cs
│   ├── ProductDTO.cs
│   ├── TableDTO.cs
│   ├── OrderDTO.cs
│   └── OrderDetailDTO.cs
│
├── DrinkShop.DAL/                # Data Access Layer (ADO.NET)
│   ├── DatabaseHelper.cs         # Mở kết nối, thực thi Command/Reader/Scalar
│   ├── RoleDAL.cs
│   ├── UserDAL.cs
│   ├── CategoryDAL.cs
│   ├── ProductDAL.cs
│   ├── TableDAL.cs
│   ├── OrderDAL.cs
│   └── StatisticDAL.cs
│
├── DrinkShop.BLL/                # Business Logic Layer (Xử lý nghiệp vụ & Validate)
│   ├── AuthBLL.cs
│   ├── UserBLL.cs
│   ├── CategoryBLL.cs
│   ├── ProductBLL.cs
│   ├── TableBLL.cs
│   ├── OrderBLL.cs
│   └── StatisticBLL.cs
│
└── DrinkShop.GUI/                # Presentation Layer (WinForms UI)
    ├── Program.cs
    ├── App.config                # Chuỗi kết nối ConnectionString
    ├── Common/                   # Constants, Session, Helper vẽ UI/Format tiền tệ
    ├── Forms/
    │   ├── FrmLogin.cs           # Màn hình đăng nhập
    │   ├── FrmMain.cs            # Màn hình chính (Dashboard Shell & Sidebar điều hướng)
    │   ├── FrmDashboard.cs       # Thống kê tổng quan thẻ KPI
    │   ├── FrmPOS.cs             # Màn hình bán hàng, chọn bàn, chọn món
    │   ├── FrmProduct.cs         # Quản lý danh sách đồ uống & upload ảnh
    │   ├── FrmCategory.cs        # Quản lý danh mục đồ uống
    │   ├── FrmTable.cs           # Quản lý sơ đồ bàn
    │   ├── FrmInvoice.cs         # Tra cứu & in lại hóa đơn
    │   ├── FrmEmployee.cs        # Quản lý nhân viên & phân quyền
    │   └── FrmStatistic.cs       # Báo cáo doanh thu & biểu đồ
    └── UserControls/             # Các thẻ con tùy biến (Card sản phẩm, nút bàn)
```

---

## 🗄️ THIẾT KẾ CƠ SỞ DỮ LIỆU (DATABASE SCHEMA)

Cơ sở dữ liệu: `DrinkShopDB` trên Microsoft SQL Server.

### Sơ đồ quan hệ thực thể (ERD)

```mermaid
erDiagram
    ROLES ||--o{ USERS : "has"
    USERS ||--o{ ORDERS : "creates"
    TABLES ||--o{ ORDERS : "assigned_to"
    CATEGORIES ||--o{ PRODUCTS : "contains"
    ORDERS ||--o{ ORDER_DETAILS : "includes"
    PRODUCTS ||--o{ ORDER_DETAILS : "ordered_in"

    ROLES {
        int RoleId PK
        nvarchar RoleName
        nvarchar Description
    }

    USERS {
        int UserId PK
        nvarchar Username UK
        nvarchar PasswordHash
        nvarchar FullName
        nvarchar Phone
        nvarchar Email
        int RoleId FK
        bit IsActive
        datetime CreatedAt
    }

    CATEGORIES {
        int CategoryId PK
        nvarchar CategoryName
        bit IsActive
    }

    PRODUCTS {
        int ProductId PK
        nvarchar ProductName
        int CategoryId FK
        decimal Price
        nvarchar ImageUrl
        bit IsActive
    }

    TABLES {
        int TableId PK
        nvarchar TableName
        nvarchar Status "Trống | Có khách | Đã đặt"
        bit IsActive
    }

    ORDERS {
        int OrderId PK
        int TableId FK
        int UserId FK
        datetime OrderDate
        decimal SubTotal
        decimal DiscountPercent
        decimal TotalAmount
        decimal CustomerPay
        decimal ReturnPay
        nvarchar PaymentMethod "Tiền mặt | Chuyển khoản"
        nvarchar Status "Chưa thanh toán | Đã thanh toán | Đã hủy"
    }

    ORDER_DETAILS {
        int OrderDetailId PK
        int OrderId FK
        int ProductId FK
        int Quantity
        decimal UnitPrice
        decimal LineTotal
        nvarchar Note
    }
```

---

## 📅 KẾ HOẠCH TRIỂN KHAI THEO GIAI ĐOẠN (ROADMAP)

> **Nguyên tắc triển khai:** Không làm dồn dập, thực hiện tuần tự từng bước: **Database & Kiến trúc -> UI khung -> Từng chức năng CRUD -> Bán hàng POS -> Báo cáo & Thống kê -> Hoàn thiện đóng gói**. Cung cấp đầy đủ mã nguồn cho từng file, hướng dẫn tạo Form và Test cụ thể sau mỗi giai đoạn.

### 📍 Giai đoạn 1: Khởi tạo Cơ sở dữ liệu & Cấu trúc Solution
- [ ] **1.1.** Cài đặt Database `DrinkShopDB` trên SQL Server với kịch bản script đầy đủ bảng, khóa chính, khóa ngoại, chỉ mục (Index) và dữ liệu mẫu khởi đầu (Tài khoản Admin, Danh mục đồ uống, Bàn mẫu).
- [ ] **1.2.** Khởi tạo Visual Studio Solution theo mô hình 3 lớp (`DrinkShop.DTO`, `DrinkShop.DAL`, `DrinkShop.BLL`, `DrinkShop.GUI`).
- [ ] **1.3.** Cấu hình `App.config` chứa chuỗi kết nối an toàn.
- [ ] **1.4.** Xây dựng lớp `DatabaseHelper.cs` (ADO.NET chuẩn, mở/đóng kết nối tự động, transaction, chống SQL Injection).
- [ ] **Kiểm thử Giai đoạn 1:** Chạy đoạn mã kiểm tra ping kết nối SQL Server thành công và đọc dữ liệu kiểm chứng.

### 📍 Giai đoạn 2: Thiết kế Khung giao diện hiện đại & Đăng nhập
- [ ] **2.1.** Xây dựng phong cách UI chuẩn (Bảng màu hiện đại, Segoe UI, thiết kế bo góc, hiệu ứng hover nút bấm).
- [ ] **2.2.** Thiết kế Form Đăng nhập (`FrmLogin`):
  - Nhập tài khoản, mật khẩu (ẩn/hiện mật khẩu).
  - Kết nối xác thực từ CSDL qua `AuthBLL` -> `UserDAL`.
  - Phân quyền theo vai trò (Quản trị viên / Nhân viên thu ngân) và lưu phiên đăng nhập (`UserSession`).
- [ ] **2.3.** Thiết kế Giao diện Khung chính (`FrmMain`):
  - Sidebar điều hướng (Dashboard, Bán hàng, Sản phẩm, Danh mục, Bàn, Hóa đơn, Nhân viên, Thống kê).
  - Header hiển thị ngày giờ, tên nhân viên đăng nhập, nút đăng xuất, thu nhỏ/tắt ứng dụng.
  - Vùng hiển thị động (`Content Panel`) để nhúng các Form con mượt mà, không bị giật lag.
- [ ] **Kiểm thử Giai đoạn 2:** Đăng nhập với tài khoản Admin và Nhân viên, kiểm tra hiển thị đúng thông tin và điều hướng sidebar trơn tru.

### 📍 Giai đoạn 3: Phân hệ Quản lý Danh mục & Sản phẩm (CRUD)
- [ ] **3.1.** Xây dựng Form Quản lý Danh mục (`FrmCategory`):
  - Xem danh sách DataGridView, Thêm, Sửa, Xóa (cập nhật trạng thái `IsActive = 0`), Tìm kiếm realtime.
- [ ] **3.2.** Xây dựng Form Quản lý Sản phẩm (`FrmProduct`):
  - Hiển thị danh sách đồ uống kèm giá tiền (format tiền tệ VNĐ `#,##0 đ`), danh mục liên kết.
  - Chức năng chọn ảnh minh họa đồ uống (lưu trữ đường dẫn hoặc thư mục `Resources/Images`).
  - Lọc theo danh mục, tìm kiếm theo tên món.
- [ ] **Kiểm thử Giai đoạn 3:** Thêm mới 1 danh mục (ví dụ: "Trà sữa", "Cà phê"), thêm 3 món nước mới, sửa giá và kiểm tra cập nhật chuẩn trong SQL Server.

### 📍 Giai đoạn 4: Phân hệ Bán hàng POS & Quản lý Bàn nước (Trọng tâm)
- [ ] **4.1.** Thiết kế Form Quản lý Bàn (`FrmTable`): Thêm bàn, đổi trạng thái bàn, khu vực.
- [ ] **4.2.** Thiết kế Giao diện POS Bán hàng (`FrmPOS`):
  - Cột 1: Sơ đồ bàn trực quan hiển thị theo màu sắc (Xanh: Trống, Đỏ/Cam: Đang có khách, Vàng: Đã đặt trước).
  - Cột 2: Danh sách món nước hiển thị dạng Grid Card (có hình ảnh, tên món, giá tiền), bấm vào thẻ để thêm vào hóa đơn.
  - Cột 3: Hóa đơn bàn đang chọn: Tăng/giảm số lượng, xóa món, nhập ghi chú (ví dụ: "Ít đường, nhiều đá").
- [ ] **4.3.** Nghiệp vụ tính tiền: Tự động cộng tổng tiền, áp dụng chiết khấu %, tính tiền thừa khi khách trả.
- [ ] **4.4.** Nghiệp vụ Bàn: Chuyển bàn, gộp bàn khi khách đổi chỗ.
- [ ] **4.5.** Chức năng Thanh toán & In hóa đơn: Cập nhật trạng thái đơn, giải phóng bàn về "Trống", xuất preview phiếu tính tiền.
- [ ] **Kiểm thử Giai đoạn 4:** Chọn bàn -> Gọi 2 món -> Tăng giảm số lượng -> Nhập tiền khách trả -> Bấm Thanh toán -> Kiểm tra trạng thái bàn và dữ liệu đơn hàng trong bảng `Orders` & `OrderDetails`.

### 📍 Giai đoạn 5: Phân hệ Quản lý Hóa đơn & Nhân viên
- [ ] **5.1.** Quản lý Lịch sử Hóa đơn (`FrmInvoice`):
  - Tìm kiếm hóa đơn theo khoảng ngày, theo nhân viên tạo, theo trạng thái.
  - Xem chi tiết từng món trong hóa đơn cũ.
  - In lại phiếu tính tiền khi cần.
- [ ] **5.2.** Quản lý Tài khoản Nhân viên (`FrmEmployee`):
  - CRUD nhân viên: Họ tên, SĐT, Email, Tên tài khoản, Mật khẩu, Vai trò (Admin / Thu ngân).
  - Khóa/Mở khóa tài khoản nhân viên.
  - Phân quyền nghiệp vụ (Nhân viên không được xóa hóa đơn hay xem quản lý nhân viên).
- [ ] **Kiểm thử Giai đoạn 5:** Tạo 1 tài khoản nhân viên mới, đăng nhập tài khoản đó kiểm tra quyền hạn có bị giới hạn đúng chuẩn hay không.

### 📍 Giai đoạn 6: Phân hệ Báo cáo Doanh thu & Thống kê
- [ ] **6.1.** Màn hình Dashboard Tổng quan (`FrmDashboard`):
  - Các thẻ KPI: Doanh thu hôm nay, Số đơn hôm nay, Số món đã bán, Bàn đang phục vụ.
- [ ] **6.2.** Màn hình Thống kê Báo cáo (`FrmStatistic`):
  - Báo cáo doanh thu theo ngày / tuần / tháng / năm hoặc khoảng ngày tùy chọn.
  - Danh sách Top 5 đồ uống bán chạy nhất (Best-sellers).
  - Biểu đồ trực quan doanh thu (Chart control).
  - Xuất dữ liệu báo cáo ra file Excel.
- [ ] **Kiểm thử Giai đoạn 6:** Thử nghiệm tạo nhiều đơn hàng và đối soát số liệu biểu đồ hiển thị với câu lệnh `SUM()` trong SQL Server.

### 📍 Giai đoạn 7: Tối ưu hóa, Xử lý lỗi toàn cục & Đóng gói hoàn thiện
- [ ] **7.1.** Bắt lỗi tập trung (Global Exception Handling) tránh crash ứng dụng.
- [ ] **7.2.** Tối ưu trải nghiệm: Thêm phím tắt (F1, F2,... Enter để tìm kiếm), kiểm tra ràng buộc nhập liệu (Validation messages thân thiện bằng tiếng Việt).
- [ ] **7.3.** Đóng gói chương trình và chuẩn bị tài liệu báo cáo đồ án.

---

## 🎨 QUY CHUẨN ĐẶT TÊN CONTROL (NAMING CONVENTIONS)

Để cả 3 thành viên phối hợp code đồng bộ, chuyên nghiệp và chuẩn quốc tế, toàn bộ tên Control tuân thủ nghiêm ngặt tiền tố (Prefix) viết tắt và định danh hoàn toàn bằng **tiếng Anh**:

| Loại Control | Tiền tố (Prefix) | Ví dụ tên Control (Naming Convention) | Ý nghĩa / Mục đích sử dụng |
| :--- | :---: | :--- | :--- |
| **Form** | `Frm` | `FrmLogin`, `FrmMain`, `FrmPOS`, `FrmProduct`, `FrmCategory`, `FrmTable`, `FrmInvoice`, `FrmEmployee`, `FrmStatistic` | Cửa sổ giao diện chức năng |
| **Button** | `btn` | `btnAdd`, `btnEdit`, `btnDelete`, `btnSave`, `btnCancel`, `btnCheckout`, `btnPrint`, `btnSearch`, `btnRefresh` | Nút bấm thao tác |
| **TextBox** | `txt` | `txtUsername`, `txtPassword`, `txtProductName`, `txtUnitPrice`, `txtSearch`, `txtCustomerPay`, `txtPhone`, `txtEmail` | Hộp nhập dữ liệu dạng chuỗi văn bản |
| **ComboBox** | `cbo` | `cboCategory`, `cboTable`, `cboRole`, `cboPaymentMethod`, `cboStatusFilter` | Hộp danh sách thả xuống chọn 1 giá trị |
| **DataGridView** | `dgv` | `dgvProducts`, `dgvCategories`, `dgvTables`, `dgvInvoices`, `dgvOrderDetails`, `dgvEmployees` | Lưới bảng hiển thị danh sách dữ liệu từ CSDL |
| **Label** | `lbl` | `lblTitle`, `lblTotalAmount`, `lblSubTotal`, `lblDiscount`, `lblReturnPay`, `lblEmployeeName`, `lblCurrentDate` | Nhãn hiển thị thông tin tĩnh hoặc động |
| **PictureBox** | `pic` | `picProductImage`, `picLogo`, `picAvatar`, `picPreview` | Khung hiển thị hình ảnh |
| **Panel** | `pnl` | `pnlSidebar`, `pnlHeader`, `pnlContent`, `pnlBillSummary`, `pnlActions` | Khung vùng chứa phân chia bố cục giao diện |
| **FlowLayoutPanel**| `flp` | `flpTableList`, `flpProductList`, `flpCategoryFilter` | Khung vùng chứa sắp xếp thẻ/nút động tự co giãn |
| **DateTimePicker** | `dtp` | `dtpFromDate`, `dtpToDate`, `dtpOrderDate`, `dtpBirthDate` | Bộ chọn ngày giờ |
| **NumericUpDown** | `nud` | `nudQuantity`, `nudDiscountPercent` | Hộp chọn số lượng, tỉ lệ % tăng/giảm |

---

## 🛠️ CÔNG NGHỆ & YÊU CẦU MÔI TRƯỜNG
- **Hệ điều hành**: Windows 10 / 11
- **Công cụ phát triển**: Visual Studio 2022 (với Workload *.NET desktop development*)
- **Ngôn ngữ**: C# (.NET Framework 4.8 hoặc .NET 8.0 Windows Forms)
- **Hệ quản trị CSDL**: Microsoft SQL Server 2019 / 2022 / SQL Server Express
- **Công cụ quản lý DB**: SQL Server Management Studio (SSMS)

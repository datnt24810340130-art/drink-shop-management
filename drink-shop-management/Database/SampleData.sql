USE DrinkShopDB;
GO

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF NOT EXISTS (SELECT 1 FROM dbo.Quyen WHERE TenQuyen = N'Admin')
	INSERT INTO dbo.Quyen(TenQuyen) VALUES (N'Admin');
IF NOT EXISTS (SELECT 1 FROM dbo.Quyen WHERE TenQuyen = N'Cashier')
	INSERT INTO dbo.Quyen(TenQuyen) VALUES (N'Cashier');

DECLARE @AdminRole INT = (SELECT MaQuyen FROM dbo.Quyen WHERE TenQuyen = N'Admin');
DECLARE @CashierRole INT = (SELECT MaQuyen FROM dbo.Quyen WHERE TenQuyen = N'Cashier');

IF NOT EXISTS (SELECT 1 FROM dbo.TaiKhoan WHERE TenDangNhap = 'admin')
	INSERT INTO dbo.TaiKhoan(TenDangNhap, MatKhau, MaQuyen, TrangThai)
	VALUES ('admin', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), 'admin123')), 2), @AdminRole, 1);
IF NOT EXISTS (SELECT 1 FROM dbo.TaiKhoan WHERE TenDangNhap = 'cashier01')
	INSERT INTO dbo.TaiKhoan(TenDangNhap, MatKhau, MaQuyen, TrangThai)
	VALUES ('cashier01', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', CONVERT(VARCHAR(255), '123456')), 2), @CashierRole, 1);

IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaTaiKhoan = (SELECT MaTaiKhoan FROM dbo.TaiKhoan WHERE TenDangNhap = 'admin'))
	INSERT INTO dbo.NhanVien(HoTen, SoDienThoai, Email, MaTaiKhoan)
	SELECT N'Quản trị hệ thống', '0900000001', 'admin@drinkshop.local', MaTaiKhoan FROM dbo.TaiKhoan WHERE TenDangNhap = 'admin';
IF NOT EXISTS (SELECT 1 FROM dbo.NhanVien WHERE MaTaiKhoan = (SELECT MaTaiKhoan FROM dbo.TaiKhoan WHERE TenDangNhap = 'cashier01'))
	INSERT INTO dbo.NhanVien(HoTen, SoDienThoai, Email, MaTaiKhoan)
	SELECT N'Nhân viên thu ngân', '0900000002', 'cashier@drinkshop.local', MaTaiKhoan FROM dbo.TaiKhoan WHERE TenDangNhap = 'cashier01';

INSERT INTO dbo.DanhMuc(TenDanhMuc, TrangThai)
SELECT src.TenDanhMuc, 1
FROM (VALUES (N'Cà phê'), (N'Trà sữa'), (N'Trà trái cây'), (N'Đá xay'), (N'Nước ép & Sinh tố'), (N'Bánh & Topping')) AS src(TenDanhMuc)
WHERE NOT EXISTS (SELECT 1 FROM dbo.DanhMuc d WHERE d.TenDanhMuc = src.TenDanhMuc);

INSERT INTO dbo.Ban(TenBan, TrangThai)
SELECT CONCAT(N'Bàn ', src.SoBan), N'Trống'
FROM (VALUES (1),(2),(3),(4),(5),(6),(7),(8),(9),(10)) AS src(SoBan)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Ban b WHERE b.TenBan = CONCAT(N'Bàn ', src.SoBan));

INSERT INTO dbo.SanPham(TenSanPham, MaDanhMuc, DonGia, HinhAnh, TrangThai)
SELECT src.TenSanPham, d.MaDanhMuc, src.DonGia, NULL, 1
FROM (VALUES
	(N'Cà phê đen', N'Cà phê', 25000),
	(N'Cà phê sữa', N'Cà phê', 29000),
	(N'Bạc xỉu', N'Cà phê', 32000),
	(N'Trà sữa truyền thống', N'Trà sữa', 35000),
	(N'Trà sữa trân châu đường đen', N'Trà sữa', 42000),
	(N'Trà sữa matcha', N'Trà sữa', 39000),
	(N'Trà đào cam sả', N'Trà trái cây', 38000),
	(N'Trà vải', N'Trà trái cây', 35000),
	(N'Trà chanh mật ong', N'Trà trái cây', 30000),
	(N'Cookie đá xay', N'Đá xay', 45000),
	(N'Matcha đá xay', N'Đá xay', 45000),
	(N'Sinh tố bơ', N'Nước ép & Sinh tố', 45000),
	(N'Nước ép cam', N'Nước ép & Sinh tố', 38000),
	(N'Bánh tiramisu', N'Bánh & Topping', 35000),
	(N'Trân châu đen', N'Bánh & Topping', 10000)
) AS src(TenSanPham, TenDanhMuc, DonGia)
INNER JOIN dbo.DanhMuc d ON d.TenDanhMuc = src.TenDanhMuc
WHERE NOT EXISTS (SELECT 1 FROM dbo.SanPham p WHERE p.TenSanPham = src.TenSanPham);

COMMIT TRANSACTION;
GO

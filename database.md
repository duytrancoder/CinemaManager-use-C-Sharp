-- 1. TẠO DATABASE (Nếu chưa có)

IF NOT EXISTS (SELECT \* FROM sys.databases WHERE name = 'QuanLyRapPhim')

BEGIN

&nbsp;   CREATE DATABASE QuanLyRapPhim;

END

GO



USE QuanLyRapPhim;

GO



-- 2. DỌN DẸP DỮ LIỆU CŨ (Xóa bảng theo thứ tự để không lỗi khóa ngoại)

DROP TABLE IF EXISTS Ve;

DROP TABLE IF EXISTS LichChieu;

DROP TABLE IF EXISTS Phim;

DROP TABLE IF EXISTS Phong;

GO



-- 3. TẠO BẢNG PHÒNG

-- Chức năng: Lưu danh sách phòng chiếu (Cinema 01, 02...)

-- Dùng cho ComboBox chọn phòng và chức năng thêm phòng nóng \[+]

CREATE TABLE Phong (

&nbsp;   TenPhong NVARCHAR(50) PRIMARY KEY

);

GO



-- 4. TẠO BẢNG PHIM

-- Chức năng: Lưu trữ thông tin phim

-- Lưu ý: MaPhim là NVARCHAR để cậu tự nhập (VD: P01, 101...)

CREATE TABLE Phim (

&nbsp;   MaPhim NVARCHAR(50) PRIMARY KEY, 

&nbsp;   TenPhim NVARCHAR(100) NOT NULL,

&nbsp;   ThoiLuong INT,          -- Tính bằng phút

&nbsp;   TheLoai NVARCHAR(100),

&nbsp;   DaoDien NVARCHAR(100),

&nbsp;   HinhAnh NVARCHAR(MAX)   -- Lưu đường dẫn file ảnh trên máy tính

);

GO



-- 5. TẠO BẢNG LỊCH CHIẾU

-- Chức năng: Kết nối Phim - Phòng - Thời gian

CREATE TABLE LichChieu (

&nbsp;   MaLich NVARCHAR(50) PRIMARY KEY, -- Cậu tự nhập mã (VD: L01)

&nbsp;   MaPhim NVARCHAR(50) REFERENCES Phim(MaPhim) ON DELETE CASCADE, -- Xóa Phim -> Mất Lịch

&nbsp;   NgayChieu DATE,      -- Lưu ngày (yyyy-MM-dd)

&nbsp;   GioChieu TIME,       -- Lưu giờ (hh:mm:ss)

&nbsp;   TenPhong NVARCHAR(50) REFERENCES Phong(TenPhong) ON DELETE CASCADE, -- Xóa Phòng -> Mất Lịch

&nbsp;   GiaVe DECIMAL(18, 0) -- Giá vé (VNĐ)

);

GO



-- 6. TẠO BẢNG VÉ

-- Chức năng: Lưu các ghế đã bán để tô màu đỏ

CREATE TABLE Ve (

&nbsp;   MaVe INT PRIMARY KEY IDENTITY(1,1), -- Tự tăng (người dùng ko cần nhập)

&nbsp;   MaLich NVARCHAR(50) REFERENCES LichChieu(MaLich) ON DELETE CASCADE, -- Xóa Lịch -> Mất Vé

&nbsp;   SoGhe NVARCHAR(10),  -- Lưu tên ghế (A1, B5...)

&nbsp;   TrangThai NVARCHAR(50) DEFAULT N'Đã bán'

);

GO



-- 7. THÊM DỮ LIỆU MẪU (SEED DATA)



-- Thêm Phòng

INSERT INTO Phong VALUES (N'Cinema 01'), (N'Cinema 02'), (N'Cinema 03');



-- Thêm Phim

INSERT INTO Phim (MaPhim, TenPhim, ThoiLuong, TheLoai, DaoDien, HinhAnh)

VALUES 

(N'P01', N'Mai', 131, N'Tình cảm', N'Trấn Thành', N''),

(N'P02', N'Đào, Phở và Piano', 100, N'Lịch sử', N'Phi Tiến Sơn', N''),

(N'P03', N'Kung Fu Panda 4', 94, N'Hoạt hình', N'Mike Mitchell', N'');



-- Thêm Lịch Chiếu (Lưu ý: Ngày phải >= ngày hiện tại mới hiện trong Form Bán Vé)

-- Giả sử hôm nay là 2026, tớ để lịch xa xa chút

INSERT INTO LichChieu (MaLich, MaPhim, NgayChieu, GioChieu, TenPhong, GiaVe)

VALUES

(N'L01', N'P01', GETDATE(), '18:00:00', N'Cinema 01', 120000),

(N'L02', N'P01', GETDATE(), '20:30:00', N'Cinema 02', 130000),

(N'L03', N'P02', DATEADD(day, 1, GETDATE()), '19:00:00', N'Cinema 01', 100000);



-- Thêm Vé (Giả sử Lịch L01 đã bán vài ghế)

INSERT INTO Ve (MaLich, SoGhe) VALUES (N'L01', N'A1'), (N'L01', N'A2'), (N'L01', N'B5');

GO


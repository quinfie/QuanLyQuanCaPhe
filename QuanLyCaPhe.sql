create database Sugong_Coffee
use Sugong_Coffee
-----------------------------------------------------------CREATE TABLE---------------------------------------------------------------------
CREATE TABLE TAI_KHOAN
(
	TEN_DANG_NHAP NVARCHAR(100) PRIMARY KEY,
	MA_NGUOI_DUNG VARCHAR(10) NOT NULL,
	MAT_KHAU NVARCHAR(12) NOT NULL,
	VAI_TRO INT DEFAULT 0,
	--1:ADMIN
	--0:STAFF
)
-------------------------------------------------------------------------------------------
CREATE TABLE NGUOI_DUNG
(
	MA_NGUOI_DUNG VARCHAR(10) PRIMARY KEY,
	TEN_NGUOI_DUNG NVARCHAR(100) NOT NULL,
	GIOI_TINH NVARCHAR(3),
	NGAY_SINH DATE,
	CCCD VARCHAR(12),
	DIA_CHI NVARCHAR(100),
	SDT VARCHAR(10)
)
-------------------------------------------------------------------------------------------
CREATE TABLE KHACH_HANG
(
	MA_KHACH_HANG VARCHAR(10) PRIMARY KEY,
	TEN_KHACH_HANG NVARCHAR(40),
	GIOI_TINH NVARCHAR(3),
	NGAY_SINH DATE,
	SO_LAN_MUA_HANG INT DEFAULT 0
)
-------------------------------------------------------------------------------------------
CREATE TABLE BAN 
--Thông tin vị trí số bàn xem có người đặt hay không
(
	MA_BAN INT PRIMARY KEY,
	TINH_TRANG_BAN NVARCHAR(100) NOT NULL
)
-------------------------------------------------------------------------------------------
CREATE TABLE DANH_MUC
(
	MA_DANH_MUC INT PRIMARY KEY,
	TEN_DANH_MUC NVARCHAR(30)
)
-------------------------------------------------------------------------------------------
CREATE TABLE THUC_DON
(
	MA_MON INT PRIMARY KEY,
	TEN_MON NVARCHAR(50),
	THANH_PHAN NVARCHAR(100),
	GIA INT,
	HINH_ANH VARCHAR(100),
	MA_DANH_MUC INT, 
	FOREIGN KEY (MA_DANH_MUC) REFERENCES DANH_MUC(MA_DANH_MUC)
)
-------------------------------------------------------------------------------------------
CREATE TABLE HOA_DON
(
	MA_HOA_DON INT PRIMARY KEY,
	MA_KHACH_HANG VARCHAR(10) NOT NULL,
	GIO_VAO DATETIME NOT NULL DEFAULT GETDATE(),
	GIO_RA DATETIME NOT NULL,
	TINH_TRANG_HD NVARCHAR(100) NOT NULL,
	THANH_TIEN REAL,
    MA_BAN INT,
	NGUOI_PHU_TRACH VARCHAR(10) NOT NULL,
	FOREIGN KEY (MA_KHACH_HANG) REFERENCES KHACH_HANG(MA_KHACH_HANG),
	FOREIGN KEY (NGUOI_PHU_TRACH) REFERENCES NGUOI_DUNG(MA_NGUOI_DUNG),
    FOREIGN KEY (MA_BAN) REFERENCES BAN(MA_BAN)
)
-------------------------------------------------------------------------------------------
CREATE TABLE CHI_TIET_HOA_DON
(
	MA_HOA_DON INT NOT NULL,
	MA_MON INT NOT NULL,
	SO_LUONG INT NOT NULL DEFAULT 0,
	PRIMARY KEY (MA_HOA_DON, MA_MON),
	FOREIGN KEY (MA_HOA_DON) REFERENCES HOA_DON(MA_HOA_DON),
	FOREIGN KEY (MA_MON) REFERENCES THUC_DON(MA_MON)
)
--------------------------------------------------------INSERT DATA TO TABLE--------------------------------------------------------------
SET DATEFORMAT DMY
INSERT INTO NGUOI_DUNG (MA_NGUOI_DUNG, TEN_NGUOI_DUNG, GIOI_TINH, NGAY_SINH, CCCD, DIA_CHI, SDT) VALUES 
('ND0001', N'Nguyễn Văn Anh', N'Nam', '15/01/1990', '123456789012', 'Số 1, Đường Lạc Long Quân, Quận 1, TP.HCM', '0954218769'),
('ND0002', N'Trần Thị Bích', N'Nữ', '20/05/1995', '987654321098', 'Số 2, Đường Phổ Hiền, Quận 2, TP.HCM', '0987654321'),
('ND0003', N'Lê Văn Cường', N'Nam', '10/09/1998', '456789012345', 'Số 3, Đường Tôn Đức Thắng, Quận 3, TP.HCM', '0874289651'),
('ND0004', N'Phạm Thị Dung', N'Nữ', '25/03/1997', '321098765432', 'Số 4, Đường Tôn Đảng, Quận 4, TP.HCM', '0987654321'),
('ND0005', N'Hoàng Văn Hùng', N'Nam', '12/06/1998', '678901234567', 'Số 5, Đường Chiến Thắng, Quận 5, TP.HCM', '0579138536');
-------------------------------------------------------------------------------------------
INSERT INTO TAI_KHOAN (TEN_DANG_NHAP, MA_NGUOI_DUNG, MAT_KHAU, VAI_TRO) VALUES 
('user1', 'ND0001', 'password', 0), -- Vai trò 0 là nhân viên (STAFF)
('user2', 'ND0002', 'password', 0),
('admin1', 'ND0003', 'admin', 1), -- Vai trò 1 là admin
('admin2', 'ND0004', 'admin', 1);
-------------------------------------------------------------------------------------------
INSERT INTO DANH_MUC VALUES
('1', 'Coffee'),
('2', 'Tea & Milk Tea'),
('3', 'Smoothie'),
('4', 'Cookies'),
('5', 'Macaron'),
('6', 'Donut')
-------------------------------------------------------------------------------------------
INSERT INTO THUC_DON VALUES
('1', 'Epresso', 'Concentrated coffe in small shot', 45000, 'Epresso.png', '1'),
('2', 'Americano', 'Espresso with hot water', 45000, 'Americano.png', '1'),
('3', 'Flat White', 'Espresso with steamed milk', 45000, 'FlatWhite.png', '1'),
('4', 'Latte', 'A latte is a shot of espresso topped with steamed milk and foam', 45000, 'Latte.png', '1'),
('5', 'Affogato', 'A scoop of ice cream is placed in a small cup, then warm, unsweetened coffee is poured over it', 45000, 'Affogato.png', '1'),
('6', 'Macchiato', 'A macchiato is equal parts espresso and steamed milk', 45000, 'Macchiato.png', '1'),
('7', 'Capucchino', 'A cappuccino is a shot of espresso with steamed milk', 45000, 'Capucchino.png', '1'),
('8', 'Milk Coffee', 'Coffee with hot water and milk then cooled with ice', 45000, 'cps.png', '1'),
--=========================================================================================================================================
('9', 'Black Sugar Milk Tea','The drink has tapioca balls in a brown sugar syrup, black tea, and milk', 65000, 'black sugar bubble milk.png', '2'),
('10', 'Herbal Tea','Made from plants, seeds, dried flowers by pouring boiling water', 30000, 'hbt.png', '2'),
('11', 'Southern Strawberry Iced Sweet Tea', 'Black tea and a simple strawberry syrup', 60000, 'Southern Strawberry Iced Sweet Tea.png', '2'),
('12', 'Peach Tea','Black tea, Mint leaves, Peaches', 45000, 'peach.png', '2'),
('13', 'Matcha Milk Tea','Matcha milk tea is a made from green tea powder, hot water, and milk', 60000, 'matcha latte.png', '2'),
('14', 'Honey Lemon Tea','Lemon juice, honey and hot water', 45000, 'Honey Lemon Tea.png', '2'),
('15', 'Olong Milk Tea','Oolong tea, milk, brown sugar, with black bubble', 45000, 'olong.png', '2'),
--=========================================================================================================================================
('16', 'Apple Banana Smoothie', 'Apple, banana peeled and chopped with orange juice and milk', 45000, 'apple banana.png', '3'),
('17', 'Apple Pie Smoothie', 'Apple, yogout, milk, cinnamon, honey, cream and rolled oats', 60000, 'apple pie.png', '3'),
('18', 'Berry Vanilla Smoothie', 'Frozen mixed berrie, vanilla protein powder, milk and water', 45000, 'berry vanilla.png', '3'),
('19', 'Chocolate Peanut Smoothie', 'Milk, honey, banana sliced and frozen, light creamy peanut butte and cocoa powder', 45000, 'chocolate peanut.png', '3'),
('20', 'Mango Tart Cherry Smoothie', 'Tart cherry juice, frozen mango chunks, and yogurt', 45000, 'mango tart cherry.png', '3'),
('21', 'Mocha Banana Smoothie', 'Bananas, espresso, almond milk, oats, honey and cocoa',50000, 'mocha banana.png', '3'),
('22', 'Pina Colada Smoothie', 'Rum, cream of coconut, pineapple juice and frozen pineapple', 55000, 'pina colada.png', '3'),
('23', 'Pumpkin Pie Smoothie', 'Pumpkin puree, banana, yogurt vanilla, pumpkin pie spice, honey, whipped cream and milk', 60000, 'pumpkin pie.png', '3'),
--=========================================================================================================================================
('24', 'Carrot Cream Cheese Cookies',NULL, 45000, 'carrot cream cheese.png', '4'),
('25', 'Chewy Ginger Molasses Cookies',NULL, 45000, 'Chewy Ginger Molasses Cookies.png', '4'),
('26', 'Choco Chip Cookies',NULL, 45000, 'choc chip cookies.png', '4'),
('27', 'Choco Mint',NULL, 45000, 'choco mint.png', '4'),
('28', 'Chocolate Chip Cookies',NULL, 45000, 'chocolate chip cookies.png', '4'),
('29', 'Chocolate Peanut Butter Cookies',NULL, 45000, 'Chocolate Peanut Butter Cookies.png', '4'),
('30', 'Lemon Cookies',NULL, 45000, 'lemon.png', '4'),
('31', 'Oatmeal Cookies',NULL, 45000, 'oatmeal cookies.png', '4'),
('32', 'Redvelvet Cookies',NULL, 45000, 'redvelvet.png', '4'),
('33', 'Strawberry Cookies',NULL, 45000, 'strawberry.png', '4'),
--=========================================================================================================================================
('34', 'Blueberry Cheesecake Macarons',NULL, 30000, 'Blueberry Cheesecake Macarons.png', '5'),
('35', 'Chocolate Macarons',NULL, 30000, 'Chocolate Macarons.png', '5'),
('36', 'Chocolate Orange Macarons',NULL, 30000, 'Chocolate Orange Macarons.png', '5'),
('37', 'Coconut Macarons',NULL, 30000, 'Coconut macarons.png', '5'),
('38', 'Green Tea Macarons',NULL, 30000, 'green tea macarons.png', '5'),
('39', 'Lavender Macarons',NULL, 30000, 'Lavender Macarons.png', '5'),
('40', 'Oreo Macarons	',NULL, 30000, 'Oreo Macarons.png', '5'),
('41', 'Salted Caramel Macarons',NULL, 30000, 'salted caramel macarons.png', '5'),
('42', 'Strawberry Cheesecake Macaron',NULL, 30000, 'Strawberry Cheesecake Macaron.png', '5'),
--=========================================================================================================================================
('43', 'Baked Orange Donuts with Salted Caramel Glaze',NULL, 30000, 'Baked Orange Donuts with Salted Caramel Glaze.png', '6'),
('44', 'Black Sesame Matcha Doughnuts',NULL, 30000, 'Black Sesame Matcha Doughnuts.png', '6'),
('45', 'Cinnamon Spiced Doughnuts',NULL, 30000, 'Cinnamon Spiced Doughnuts.png', '6'),
('46', 'Glazed Coconut Donuts',NULL, 30000, 'Glazed Coconut Donuts.png', '6'),
('48', 'Red Velvet Donuts',NULL, 30000, 'Red velvet donuts.png', '6'),
('49', 'Triple Chocolate Donuts',NULL, 30000, 'Triple Chocolate Donuts.png', '6'),
('50', 'Turmeric Lemon Coconut Donuts',NULL, 30000, 'Turmeric Lemon Coconut Donuts.png', '6'),
('51', 'Vegan Blueberry Donuts',NULL, 30000, 'Vegan Blueberry Donuts.png', '6'),
('52', 'Vegan Chai Latte Donuts With Maple Glaze',NULL, 30000, 'Vegan chai latte donuts with maple glaze.png', '6')
------------------------------------------------------------------------------------------- ( Chưa insert và xử lý )
INSERT INTO BAN VALUES
(1,N'Trống'),
(2,N'Trống'),
(3,N'Trống'),
(4,N'Đã đặt'),
(5,N'Trống'),
(6,N'Đã đặt'),
(7,N'Đã đặt'),
(8,N'Trống'),
(9,N'Đã đặt'),
(10,N'Đã đặt');
-------------------------------------------------------------------------------------------
SET DATEFORMAT DMY
INSERT INTO KHACH_HANG (MA_KHACH_HANG, TEN_KHACH_HANG, GIOI_TINH, NGAY_SINH, SO_LAN_MUA_HANG)
VALUES
('KH001', N'Nguyễn Văn A', N'Nam', '15-05-1990', 2),
('KH002', N'Trần Thị B', N'Nữ', '22-08-1985', 5),
('KH003', N'Lê Văn C', N'Nam', '10-12-1995', 1),
('KH004', N'Phạm Thị D', N'Nữ', '25-03-1988', 3),
('KH005', N'Hoàng Văn E', N'Nam', '18-07-1992', 4),
('KH006', N'Nguyễn Thị F', N'Nữ', '30-09-1998', 1),
('KH007', N'Trần Văn G', N'Nam', '05-11-1997', 2),
('KH008', N'Lê Thị H', N'Nữ', '12-01-1994', 6),
('KH009', N'Phan Văn I', N'Nam', '20-04-1993', 2),
('KH010', N'Nguyễn Thị K', N'Nữ', '28-06-1996', 3);
-------------------------------------------------------------------------------------------
SET DATEFORMAT DMY
INSERT INTO HOA_DON (MA_HOA_DON, MA_KHACH_HANG, GIO_VAO, GIO_RA, TINH_TRANG_HD, THANH_TIEN, MA_BAN, NGUOI_PHU_TRACH)
VALUES
(1,'KH001', '2023-12-01 12:00:00', '2023-12-01 13:30:00', N'Hoàn thành', 150000, 1, 'ND0001'),
(2,'KH002', '2023-12-02 15:30:00', '2023-12-02 17:00:00', N'Chưa thanh toán', 200000, 2, 'ND0002'),
(3,'KH003', '2023-12-03 18:45:00', '2023-12-03 20:15:00', N'Đang chờ', 120000, 3, 'ND0003'),
(4,'KH004', '2023-12-04 10:00:00', '2023-12-04 11:30:00', N'Hoàn thành', 180000, 4, 'ND0004'),
(5,'KH005', '2023-12-05 14:45:00', '2023-12-05 16:00:00', N'Chưa thanh toán', 220000, 5, 'ND0005'),
(6,'KH006', '2023-12-06 19:30:00', '2023-12-06 21:00:00', N'Đang chờ', 130000, 6, 'ND0001'),
(7,'KH007', '2023-12-07 11:15:00', '2023-12-07 12:45:00', N'Hoàn thành', 160000, 7, 'ND0002'),
(8,'KH008', '2023-12-08 16:30:00', '2023-12-08 18:00:00', N'Chưa thanh toán', 190000, 8, 'ND0003'),
(9,'KH009', '2023-12-09 20:00:00', '2023-12-09 21:30:00', N'Đang chờ', 140000, 9, 'ND0004'),
(10,'KH010', '2023-12-10 13:00:00', '2023-12-10 14:15:00', N'Hoàn thành', 200000, 10, 'ND0005');
-------------------------------------------------------------------------------------------
INSERT INTO CHI_TIET_HOA_DON (MA_HOA_DON, MA_MON, COUNT) VALUES 
(1, 2, 2),
(2, 2, 1),
(3, 3, 3),
(4, 4, 2),
(5, 5, 1),
(6, 6, 3),
(7, 7, 2),
(8, 8, 1),
(9, 9, 3),
(10, 10, 2);
--------------------------------------------------------CONSTRAINT TABLE--------------------------------------------------------------
ALTER TABLE TAI_KHOAN
ADD CONSTRAINT FK_MND FOREIGN KEY (MA_NGUOI_DUNG) REFERENCES NGUOI_DUNG(MA_NGUOI_DUNG)
ALTER TABLE THUC_DON
ADD CONSTRAINT CHK_GIA_POSITIVE
CHECK (GIA >= 0);
ALTER TABLE HOA_DON
ADD CONSTRAINT DF_TINH_TRANG_HD
DEFAULT 'Chưa thanh toán' FOR TINH_TRANG_HD;
ALTER TABLE BAN
ADD CONSTRAINT DF_TINH_TRANG_BAN
DEFAULT 'Trống' FOR TINH_TRANG_BAN;
----------------------------------------------------------------------------
--Cập nhật số lượng của món ăn trong thực đơn sau mỗi lần có sự thay đổi.
CREATE TRIGGER TR_CHI_TIET_HOA_DON_COUNT
ON CHI_TIET_HOA_DON
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE cthd
    SET SO_LUONG = cthd.SO_LUONG + i.SO_LUONG
    FROM CHI_TIET_HOA_DON cthd
    INNER JOIN inserted i ON cthd.MA_MON = i.MA_MON AND cthd.MA_HOA_DON = i.MA_HOA_DON
END;
----------------------------------------------------------------------------
--Cập nhật trạng thái của bàn sau khi có sự thay đổi.
CREATE TRIGGER TR_BAN_TINH_TRANG
ON BAN
AFTER INSERT, UPDATE
AS
BEGIN
    UPDATE BAN
    SET TINH_TRANG_BAN = 'Có người đặt'
    FROM BAN b
    INNER JOIN inserted i ON b.MA_BAN = i.MA_BAN
END;
----------------------------------------------------------------------------
-- trigger tự động tính toán và cập nhật trường "THANH_TIEN" trong bảng HOA_DON
CREATE TRIGGER tr_Calculate_ThanhTien
ON CHI_TIET_HOA_DON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Update THANH_TIEN for affected HOA_DON records after INSERT or UPDATE in CHI_TIET_HOA_DON
    UPDATE HOA_DON
    SET THANH_TIEN = (
        SELECT SUM(ISNULL(TD.GIA, 0) * ISNULL(CTHD.SO_LUONG, 0))
        FROM CHI_TIET_HOA_DON CTHD
        JOIN THUC_DON TD ON CTHD.MA_MON = TD.MA_MON
        WHERE CTHD.MA_HOA_DON = HOA_DON.MA_HOA_DON
    )
    WHERE HOA_DON.MA_HOA_DON IN (SELECT DISTINCT MA_HOA_DON FROM inserted);

    -- Handle DELETE in CHI_TIET_HOA_DON
    UPDATE HOA_DON
    SET THANH_TIEN = (
        SELECT SUM(ISNULL(TD.GIA, 0) * ISNULL(CTHD.SO_LUONG, 0))
        FROM CHI_TIET_HOA_DON CTHD
        JOIN THUC_DON TD ON CTHD.MA_MON = TD.MA_MON
        WHERE CTHD.MA_HOA_DON = HOA_DON.MA_HOA_DON
    )
    WHERE HOA_DON.MA_HOA_DON IN (SELECT DISTINCT MA_HOA_DON FROM deleted);
END;





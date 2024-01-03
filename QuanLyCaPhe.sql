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
CREATE TABLE BAN 
--Thông tin vị trí số bàn xem có người đặt hay không
(
	ID INT IDENTITY PRIMARY KEY,
	MA_BAN INT,
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
	THANH_PHAN NVARCHAR(MAX),
	GIA INT,
	HINH_ANH VARCHAR(100),
	MA_DANH_MUC INT, 
	FOREIGN KEY (MA_DANH_MUC) REFERENCES DANH_MUC(MA_DANH_MUC)
)
-------------------------------------------------------------------------------------------
CREATE TABLE HOA_DON (
    MA_HOA_DON INT IDENTITY PRIMARY KEY,
    THANH_TIEN REAL
);
-------------------------------------------------------------------------------------------
CREATE TABLE CHI_TIET_HOA_DON (
    MA_HOA_DON INT NOT NULL,
    MA_MON INT NOT NULL,
    SO_LUONG INT NOT NULL DEFAULT 0,
    PRIMARY KEY (MA_HOA_DON, MA_MON),
    FOREIGN KEY (MA_HOA_DON) REFERENCES HOA_DON(MA_HOA_DON),
    FOREIGN KEY (MA_MON) REFERENCES THUC_DON(MA_MON)
);
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
('24', 'Carrot Cream Cheese Cookies','Carrot, Cream Cheese, Flour, Sugar, Butter, Egg, Baking Powder, Vanilla Extract, Salt, Cinnamon', 45000, 'Carrot_Cream_Cheese.png', '4'),
('25', 'Chewy Ginger Molasses Cookies','Flour, Molasses, Sugar, Butter, Egg, Baking Soda, Ginger, Cinnamon, Cloves, Salt', 45000, 'Chewy_Ginger_Molasses_Cookies.png', '4'),
('26', 'Choco Chip Cookies','Flour, Chocolate Chips, Butter, Brown Sugar, Sugar, Egg, Vanilla Extract, Baking Soda, Salt', 45000, 'Choc_Chip_Cookies.png', '4'),
('27', 'Choco Mint','Flour, Chocolate Chips, Butter, Sugar, Egg, Mint Extract, Baking Soda, Salt', 45000, 'Choco_Mint.png', '4'),
('28', 'Chocolate Chip Cookies','Flour, Chocolate Chips, Butter, Brown Sugar, Sugar, Egg, Vanilla Extract, Baking Soda, Salt', 45000, 'Chocolate_Chip_Cookies.png', '4'),
('29', 'Chocolate Peanut Butter Cookies','Flour, Chocolate Chips, Peanut Butter, Butter, Sugar, Egg, Baking Soda, Salt', 45000, 'Chocolate_Peanut_Butter_Cookies.png', '4'),
('30', 'Lemon Cookies','Flour, Lemon Zest, Lemon Juice, Butter, Sugar, Egg, Baking Powder, Salt', 45000, 'lemon_cookies.png', '4'),
('31', 'Oatmeal Cookies','Oats, Flour, Butter, Brown Sugar, Sugar, Egg, Vanilla Extract, Baking Soda, Cinnamon, Salt', 45000, 'Oatmeal_Cookies.png', '4'),
('32', 'Redvelvet Cookies','Flour, Cocoa Powder, Red Food Coloring, Butter, Sugar, Egg, Vanilla Extract, Baking Powder, Salt', 45000, 'Redvelvet_Cookies.png', '4'),
('33', 'Strawberry Cookies','Flour, Strawberries, Butter, Sugar, Egg, Baking Powder, Vanilla Extract, Salt', 45000, 'Strawberry_Cookies.png', '4'),
--=========================================================================================================================================
('34', 'Blueberry Cheesecake Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Cream Cheese, Blueberry Jam, Food Coloring', 30000, 'Blueberry_Cheesecake_Macarons.png', '5'),
('35', 'Chocolate Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Cocoa Powder, Dark Chocolate, Butter, Cream', 30000, 'Chocolate_Macarons.png', '5'),
('36', 'Chocolate Orange Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Cocoa Powder, Orange Zest, Dark Chocolate, Butter, Cream', 30000, 'Chocolate_Orange_Macarons.png', '5'),
('37', 'Coconut Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Shredded Coconut, Coconut Extract', 30000, 'Coconut_Macarons.png', '5'),
('38', 'Green Tea Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Matcha Powder', 30000, 'Green_Tea_Macarons.png', '5'),
('39', 'Lavender Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Dried Lavender, Purple Food Coloring', 30000, 'Lavender_Macarons.png', '5'),
('40', 'Oreo Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Oreo Cookies (filling removed)', 30000, 'Oreo_Macarons.png', '5'),
('41', 'Salted Caramel Macarons','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Caramel Sauce, Sea Salt', 30000, 'Salted_Caramel_Macarons.png', '5'),
('42', 'Strawberry Cheesecake Macaron','Almond Flour, Powdered Sugar, Egg Whites, Granulated Sugar, Cream Cheese, Strawberry Jam, Food Coloring', 30000, 'Strawberry_Cheesecake_Macaron.png', '5'),
--=========================================================================================================================================
('43', 'Baked Orange Donuts with Salted Caramel Glaze','Flour, Baking Powder, Salt, Nutmeg, Orange Zest, Sugar, Butter, Egg, Milk, Vanilla Extract, Salted Caramel Sauce', 30000, 'Baked_Orange_Donuts_with_Salted_Caramel_Glaze.png', '6'),
('44', 'Black Sesame Matcha Doughnuts','Flour, Baking Powder, Salt, Black Sesame Seeds, Matcha Powder, Sugar, Butter, Egg, Milk, Vanilla Extract', 30000, 'Black_Sesame_Matcha_Doughnuts.png', '6'),
('45', 'Cinnamon Spiced Doughnuts','Flour, Baking Powder, Baking Soda, Cinnamon, Nutmeg, Sugar, Butter, Egg, Milk, Vanilla Extract', 30000, 'Cinnamon_Spiced_Doughnuts.png', '6'),
('46', 'Glazed Coconut Donuts','Flour, Baking Powder, Salt, Coconut Milk, Shredded Coconut, Sugar, Butter, Egg, Vanilla Extract, Powdered Sugar', 30000, 'Glazed_Coconut_Donuts.png', '6'),
('48', 'Red Velvet Donuts','Flour, Cocoa Powder, Baking Powder, Salt, Buttermilk, Red Food Coloring, Sugar, Butter, Egg, Vanilla Extract, Cream Cheese Frosting', 30000, 'Red_Velvet_Donuts.png', '6'),
('49', 'Triple Chocolate Donuts','Flour, Cocoa Powder, Baking Powder, Salt, Sugar, Butter, Egg, Milk, Vanilla Extract, Chocolate Chips, Chocolate Glaze', 30000, 'Triple_Chocolate_Donuts.png', '6'),
('50', 'Turmeric Lemon Coconut Donuts','Flour, Baking Powder, Salt, Turmeric, Lemon Zest, Coconut Milk, Sugar, Butter, Egg, Vanilla Extract, Shredded Coconut', 30000, 'Turmeric_Lemon_Coconut_Donuts.png', '6'),
('51', 'Vegan Blueberry Donuts','Flour, Baking Powder, Baking Soda, Salt, Vegan Milk, Apple Cider Vinegar, Sugar, Vegetable Oil, Vanilla Extract, Blueberries (fresh or frozen)', 30000, 'Vegan_Blueberry_Donuts.png', '6'),
('52', 'Vegan Chai Latte Donuts With Maple Glaze','Flour, Baking Powder, Baking Soda, Salt, Chai Spice Blend, Vegan Milk, Apple Cider Vinegar, Sugar, Vegetable Oil, Maple Glaze', 30000, 'Vegan_Chai_Latte_Donuts_With_Maple_Glaze.png', '6');
select * from THUC_DON
delete THUC_DON
------------------------------------------------------------------------------------------- 
INSERT INTO BAN VALUES
(1,N'Trống'),
(2,N'Trống'),
(3,N'Trống'),
(4,N'Trống'),
(5,N'Trống'),
(6,N'Trống'),
(7,N'Trống'),
(8,N'Trống'),
(9,N'Trống'),
(10,N'Trống'),
(11,N'Trống'),
(12,N'Trống'),
(13,N'Trống'),
(14,N'Trống'),
(15,N'Trống'),
(16,N'Trống'),
(17,N'Trống'),
(18,N'Trống'),
(19,N'Trống'),
(20,N'Trống'),
(21,N'Trống'),
(22,N'Trống'),
(23,N'Trống'),
(24,N'Trống');
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
CREATE TRIGGER trg_AfterChange_ChiTietHoaDon
ON CHI_TIET_HOA_DON
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    DECLARE @MaHoaDon INT;

    IF (SELECT COUNT(*) FROM inserted) > 0
    BEGIN
        -- Lấy MA_HOA_DON từ bản ghi được thêm hoặc cập nhật
        SELECT @MaHoaDon = MA_HOA_DON
        FROM inserted;
    END
    ELSE
    BEGIN
        -- Lấy MA_HOA_DON từ bản ghi bị xóa
        SELECT @MaHoaDon = MA_HOA_DON
        FROM deleted;
    END

    -- Cập nhật THANH_TIEN trong bảng HOA_DON dựa trên các bản ghi mới hoặc cũ
    UPDATE HOA_DON
    SET THANH_TIEN = (
        SELECT SUM(chi_tiet.SO_LUONG * thuc_don.GIA) 
        FROM CHI_TIET_HOA_DON chi_tiet
        INNER JOIN THUC_DON thuc_don ON chi_tiet.MA_MON = thuc_don.MA_MON
        WHERE chi_tiet.MA_HOA_DON = @MaHoaDon
    )
    WHERE MA_HOA_DON = @MaHoaDon;
END;
----------------------------------------------------------------------------
CREATE PROC GET_TABLE_LIST
AS SELECT * FROM BAN
GO
EXEC GET_TABLE_LIST
--------------------------------------------------------Test Data--------------------------------------------------------------
select * from BAN
select * from HOA_DON
select * from CHI_TIET_HOA_DON

delete CHI_TIET_HOA_DON
delete HOA_DON
DBCC CHECKIDENT('HOA_DON', RESEED, 0)
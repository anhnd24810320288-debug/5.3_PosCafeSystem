USE CafePOSDB;

INSERT INTO BanAn (TenBan, TrangThai)
SELECT x.TenBan, 'Trống'
FROM (
    SELECT 'Bàn 01' AS TenBan UNION ALL
    SELECT 'Bàn 02' UNION ALL
    SELECT 'Bàn 03' UNION ALL
    SELECT 'Bàn 04' UNION ALL
    SELECT 'Bàn 05' UNION ALL
    SELECT 'Bàn 06' UNION ALL
    SELECT 'Bàn 07' UNION ALL
    SELECT 'Bàn 08' UNION ALL
    SELECT 'Bàn 09' UNION ALL
    SELECT 'Bàn 10' UNION ALL
    SELECT 'Bàn 11' UNION ALL
    SELECT 'Bàn 12'
) x
WHERE NOT EXISTS (
    SELECT 1 FROM BanAn b WHERE b.TenBan = x.TenBan
);

INSERT INTO DanhMuc (TenDanhMuc)
SELECT 'Cà phê'
WHERE NOT EXISTS (
    SELECT 1 FROM DanhMuc WHERE TenDanhMuc = 'Cà phê'
);

INSERT INTO DanhMuc (TenDanhMuc)
SELECT 'Trà sữa'
WHERE NOT EXISTS (
    SELECT 1 FROM DanhMuc WHERE TenDanhMuc = 'Trà sữa'
);

INSERT INTO DanhMuc (TenDanhMuc)
SELECT 'Đồ ăn nhẹ'
WHERE NOT EXISTS (
    SELECT 1 FROM DanhMuc WHERE TenDanhMuc = 'Đồ ăn nhẹ'
);

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Cà phê đen', MaDanhMuc, 20000
FROM DanhMuc
WHERE TenDanhMuc = 'Cà phê'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Cà phê đen');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Cà phê sữa', MaDanhMuc, 25000
FROM DanhMuc
WHERE TenDanhMuc = 'Cà phê'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Cà phê sữa');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Bạc xỉu', MaDanhMuc, 30000
FROM DanhMuc
WHERE TenDanhMuc = 'Cà phê'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Bạc xỉu');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Trà sữa truyền thống', MaDanhMuc, 35000
FROM DanhMuc
WHERE TenDanhMuc = 'Trà sữa'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Trà sữa truyền thống');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Trà sữa matcha', MaDanhMuc, 40000
FROM DanhMuc
WHERE TenDanhMuc = 'Trà sữa'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Trà sữa matcha');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Bánh mì', MaDanhMuc, 20000
FROM DanhMuc
WHERE TenDanhMuc = 'Đồ ăn nhẹ'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Bánh mì');

INSERT INTO MonAn (TenMon, MaDanhMuc, DonGia)
SELECT 'Khoai tây chiên', MaDanhMuc, 30000
FROM DanhMuc
WHERE TenDanhMuc = 'Đồ ăn nhẹ'
AND NOT EXISTS (SELECT 1 FROM MonAn WHERE TenMon = 'Khoai tây chiên');

USE CafePOSDB;

SELECT * FROM BanAn;
SELECT * FROM DanhMuc;
SELECT * FROM MonAn;
SELECT * FROM HoaDon;
SELECT * FROM ChiTietHoaDon;
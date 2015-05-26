# Mô hình CSDL thiết kế bằng Enterprise Architect v7.5 #

![http://cc02-xemdiemthidh.googlecode.com/files/CSDL.png](http://cc02-xemdiemthidh.googlecode.com/files/CSDL.png)


# Mô tả #

**Table Truong**
  * **MaTruong**: Mã Trường dự thi, kiểu dữ liệu: nvarchar(3), khóa chính.
  * TenTruong: Tên trường dự thi, kiểu dữ liệu: nvarchar(50).


**Table Nganh**
  * **Id**: Id ngành học, kiểu dữ liệu: int - tăng tự động, khóa chính.
  * _MaTruong_: Mã Trường, kiểu dữ liệu: nvarchar(3), khóa ngoại, cho biết ngành này thuộc trường gì.
  * TenNganh: Tên Ngành học, kiểu dữ liệu: nvarchar(50).



**Table ThiSinh**
  * **Id**: Id thí sinh, kiểu dữ liệu: int - tăng tự động, khóa chính.
  * _IdNganh_: Id Ngành học, kiểu dữ liệu: int, khóa ngoại, cho biết thí sinh chọn ngành gì, thuộc trường nào.
  * HoTen: Họ tên thí sinh, kiểu dữ liệu: nvarchar(50).
  * NgaySinh: Ngày sinh của thí sinh, kiểu dữ liệu: smalldatetime.
  * QueQuan: Quê quán, kiểu dữ liệu: nvarchar(50).
  * GioiTinh: Giới tính của thí sinh, kiểu dữ liệu: bit.
  * Diem1: Cho biết điểm thi môn thứ nhất, kiểu dữ liệu: float.
  * Diem2: Cho biết điểm thi môn thứ hai, kiểu dữ liệu: float.
  * Diem3: Cho biết điểm thi môn thứ ba, kiểu dữ liệu: float.
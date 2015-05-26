Các bạn tải file Example Server và Client về trong mục Downloads


Hướng dẫn build:

- Mở Project Server bằng Visual Studio, bấm Ctrl - F5 để chạy

- Mở Project Client bằng Visual Studio, trong phần Service Reference ở cửa sổ Solution Explorer, chuột phải vào ServiceReference1, chọn Configure Service Reference, sửa lại đường link của Server trong mục Address, bấm OK, sau đó build và chạy.


Chương trình bên Client sẽ demo gọi method GetAHuman() ở phía Server và lấy về giá trị.
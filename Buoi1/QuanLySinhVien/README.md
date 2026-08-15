# 🎓 Student Management System (Quản Lý Sinh Viên)

## 📌 1. Mục tiêu dự án
* Xây dựng hệ thống quản lý sinh viên hoàn chỉnh với đầy đủ các nghiệp vụ CRUD, lọc, tìm kiếm và thống kê.
* Rèn luyện tư duy lập trình hướng đối tượng (OOP) và áp dụng các nguyên tắc thiết kế phân tách trách nhiệm (Separation of Concerns).
* Chuẩn hóa logic kiểm tra hợp lệ dữ liệu (Validation) và xử lý ngoại lệ (Exception Handling) ở tầng Core trước khi tích hợp vào ASP.NET Core Web API.
* Làm chủ kỹ thuật truy vấn, lọc và biến đổi dữ liệu nâng cao trên tập hợp bằng LINQ.

---

## 🛠 2. Công nghệ & Kỹ thuật sử dụng
* **Ngôn ngữ:** C# (.NET 8)
* **Mô hình kiến trúc:** Phân tách tầng (Presentation Layer / Controller giả lập - Service Layer - Model / Domain Layer)
* **Kỹ thuật C# chuyên sâu:**
  * **LINQ (Language Integrated Query):** `Where`, `OrderBy`, `OrderByDescending`, `Average`, `Max`, `FirstOrDefault`, `Any` để xử lý tập hợp `List<T>`.
  * **Data Validation & Protection:** Regular Expressions (`Regex`) kiểm tra email, `DateOnly` / `DateTime` so sánh thời gian thực với `DateTime.Today`.
  * **Kiểu dữ liệu nâng cao:** `Enum` định danh trạng thái và giới tính, `Switch Expression` để ánh xạ dữ liệu hiển thị.
  * **Memory & Exception Safety:** Ép kiểu an toàn với mẫu `TryParse` và từ khóa `out`, ném ngoại lệ tường minh (`ArgumentException`, `ArgumentOutOfRangeException`, `KeyNotFoundException`, `InvalidOperationException`).

---

## 🚀 3. Danh sách chức năng hệ thống

### A. Nhóm Quản lý & Cập nhật (CRUD)
1. **Thêm sinh viên:** Nhập thông tin sinh viên từ bàn phím, tự động kiểm tra trùng lặp mã sinh viên (`Any`) và validate định dạng dữ liệu đầu vào.
2. **Hiển thị danh sách:** Liệt kê toàn bộ sinh viên kèm thông tin chi tiết được ánh xạ thân thiện.
3. **Cập nhật sinh viên:** Tìm kiếm theo mã và cập nhật thông tin mới qua phương thức domain update; báo lỗi nếu không tồn tại.
4. **Xóa sinh viên:** Tìm kiếm theo mã và xóa an toàn khỏi danh sách lưu trữ.

### B. Nhóm Tìm kiếm & Lọc (Search & Filter)
5. **Tìm sinh viên theo mã:** Tìm chính xác thông tin sinh viên theo mã định danh duy nhất.
6. **Tìm gần đúng theo họ tên:** Tìm kiếm chuỗi tương đối theo tên không phân biệt hoa thường (`Contains` & `ToLower`).
7. **Lọc sinh viên giỏi:** Hiển thị danh sách các sinh viên có điểm trung bình từ `8.0` trở lên.

### C. Nhóm Sắp xếp (Sorting)
8. **Sắp xếp theo họ tên:** Sắp xếp danh sách sinh viên theo thứ tự bảng chữ cái alphabet (`OrderBy`).
9. **Sắp xếp theo điểm trung bình:** Sắp xếp thứ bậc sinh viên theo điểm từ thấp đến cao hoặc từ cao xuống thấp.

### D. Nhóm Thống kê & Báo cáo (Aggregation & Reporting)
10. **Tìm thủ khoa:** Lấy danh sách các sinh viên có điểm trung bình cao nhất hệ thống (`Max` + `Where`).
11. **Tính điểm trung bình toàn trường:** Tính trung bình cộng điểm số của tất cả sinh viên trong hệ thống (`Average`).
12. **Thống kê theo ngành học:** Phân nhóm và đếm số lượng sinh viên theo từng ngành (`GroupBy`).
13. **Thống kê theo trạng thái:** Tổng hợp số lượng sinh viên theo các trạng thái học tập (Đang học, Bảo lưu, Đã tốt nghiệp).

using QuanLySinhVien.Enums;
using QuanLySinhVien.Models;
using QuanLySinhVien.Validator;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.Services
{
    internal class StudentService
    {
        private List<Student> danhSachSinhVien = new List<Student>();
        private StudentValidator studentValidator = new();
        public List<Student> DanhSachSinhVien{
            get
            {
                return danhSachSinhVien;
            }
            set
            {
                danhSachSinhVien = value;
            }
        }
        public bool ThemSinhVien(Student svMoi)
        {
            if (!studentValidator.IsValidStudent(svMoi))
            {
                Console.WriteLine("Thong tin sinh vien khong hop le!");
                return false;
            }
            bool kiemTra = danhSachSinhVien.Any(sv => sv.MaSinhVien.Equals(svMoi.MaSinhVien));
            if (!kiemTra)
            {
                danhSachSinhVien.Add(svMoi);
                return true;
            }
            else
            {
                Console.WriteLine("Ma sinh vien da ton tai!");
                return false; 
            }
        }
        public bool CapNhatThongTin(string maSinhVien, Student thongTinSinhVien)
        {
            if (!studentValidator.IsValidStudent(thongTinSinhVien))
            {
                Console.WriteLine("Thong tin sinh vien khong hop le!");
                return false;
            }
            Student? sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
            if (sinhVien != null)
            {
                sinhVien.Update(thongTinSinhVien);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool XoaSinhVien(string maSinhVien)
        {

            Student? sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
            if (sinhVien != null)
            {
                danhSachSinhVien.Remove(sinhVien);
                return true;
            }
            return false;
        }
        public Student TimSinhVienTheoMa(string maSinhVien)
        {
            return danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);

        }
        public List<Student> TimSinhVienTheoTen(string text) 
        {
            text = text.ToLower();
            List<Student> danhSach = danhSachSinhVien.Where(sv => sv.HoTen.ToLower().Contains(text)).ToList();
            return danhSach;
        }
        public List<Student> SapXepTheoTen()
        {
            List<Student> danhSach = danhSachSinhVien.OrderBy(sv => sv.GetTen()).ToList();
            return danhSach;
        }
        public List<Student> SapXepTheoDiem()
        {
            List<Student> danhSach = danhSachSinhVien.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
            return danhSach;
        }
        public List<Student> DanhSachSinhVienTheoDiem(float diem)
        {
            List<Student> danhSach = danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= diem).ToList();
            return danhSach;
        }
        public float DiemCaoNhat()
        {
            return danhSachSinhVien.Max(sv => sv.DiemTrungBinh);
        }
        public float DiemTrungBinh()
        {
            return danhSachSinhVien.Average(sv => sv.DiemTrungBinh);
        }
        public int SoLuongSinhVien()
        {
            return danhSachSinhVien.Count();
        }
        public Dictionary<string,List<Student>> ThongKeSinhVienTheoNganh()
        {
            Dictionary<string, List<Student>> dictionary = new Dictionary<string, List<Student>>();
            foreach (Student sv in danhSachSinhVien)
            {
                if (!dictionary.ContainsKey(sv.NganhHoc))
                {
                    dictionary.Add(sv.NganhHoc, new List<Student>());
                }
                dictionary[sv.NganhHoc].Add(sv);
            }
            return dictionary;

            //return danhSachSinhVien.GroupBy(sv => sv.NganhHoc).ToDictionary(group => group.Key, group
            //    => group.ToList());
            
        }
        public Dictionary<TrangThaiHocTap, List<Student>> ThongKeSinhVienTheoTrangThai()
        {
            Dictionary<TrangThaiHocTap, List<Student>> dictionary = new Dictionary<TrangThaiHocTap, List<Student>>();
            foreach (Student sv in danhSachSinhVien)
            {
                if (!dictionary.ContainsKey(sv.TrangThaiHocTap))
                {
                    dictionary.Add(sv.TrangThaiHocTap, new List<Student>());
                }
                dictionary[sv.TrangThaiHocTap].Add(sv);
            }
            return dictionary;
        }
        public void LoadData()
        {
            danhSachSinhVien.Add(new Student(
                "SV001",
                "Nguyen Van An",
                new DateOnly(2003, 5, 14),
                GioiTinh.Nam,
                "an.nguyen@email.com",
                "0901234567",
                "Cong nghe thong tin",
                8.4f,
                TrangThaiHocTap.DangHoc
            ));

            danhSachSinhVien.Add(new Student(
                "SV002",
                "Tran Thi Mai",
                new DateOnly(2004, 11, 20),
                GioiTinh.Nu,
                "mai.tran@email.com",
                "0912345678",
                "Khoa hoc may tinh",
                9.1f,
                TrangThaiHocTap.DangHoc
            ));

            danhSachSinhVien.Add(new Student(
                "SV003",
                "Le Hoang Long",
                new DateOnly(2002, 3, 8),
                GioiTinh.Nam,
                null,
                "0987654321",
                "He thong thong tin",
                6.5f,
                TrangThaiHocTap.BaoLuu
            ));

            danhSachSinhVien.Add(new Student(
                "SV004",
                "Pham Huong Giang",
                new DateOnly(2001, 9, 25),
                GioiTinh.Nu,
                "giang.pham@email.com",
                "0934567890",
                "Ky thuat phan mem",
                7.8f,
                TrangThaiHocTap.DaTotNghiep
            ));

            danhSachSinhVien.Add(new Student(
                "SV005",
                "Do Minh Tri",
                new DateOnly(2003, 12, 2),
                GioiTinh.Nam,
                "tri.do@email.com",
                "0978123456",
                "An toan thong tin",
                4.2f,
                TrangThaiHocTap.BoHoc
            ));

            danhSachSinhVien.Add(new Student(
                "SV006",
                "Vu Khanh Linh",
                new DateOnly(2004, 7, 19),
                GioiTinh.Nu,
                null,
                "0965432187",
                "Thuong mai dien tu",
                8.8f,
                TrangThaiHocTap.DangHoc
            ));

            // Cac sinh vien co trung ho / ten
            danhSachSinhVien.Add(new Student(
                "SV007",
                "Nguyen Thi Mai", // Trung ho voi SV001, trung ten voi SV002
                new DateOnly(2003, 8, 12),
                GioiTinh.Nu,
                "mai.nguyen@email.com",
                "0911223344",
                "Khoa hoc may tinh",
                8.1f,
                TrangThaiHocTap.DangHoc
            ));

            danhSachSinhVien.Add(new Student(
                "SV008",
                "Tran Hoang An", // Trung ho voi SV002, trung ten voi SV001
                new DateOnly(2004, 2, 28),
                GioiTinh.Nam,
                "an.tran@email.com",
                "0922334455",
                "Ky thuat phan mem",
                7.5f,
                TrangThaiHocTap.DangHoc
            ));

            danhSachSinhVien.Add(new Student(
                "SV009",
                "Le Thao Linh", // Trung ho voi SV003, trung ten voi SV006
                new DateOnly(2002, 10, 15),
                GioiTinh.Nu,
                null,
                "0933445566",
                "Thuong mai dien tu",
                6.9f,
                TrangThaiHocTap.BaoLuu
            ));

            danhSachSinhVien.Add(new Student(
                "SV010",
                "Pham Van Long", // Trung ho voi SV004, trung ten voi SV003
                new DateOnly(2003, 4, 30),
                GioiTinh.Nam,
                "long.pham@email.com",
                "0944556677",
                "An toan thong tin",
                5.0f,
                TrangThaiHocTap.BoHoc
            ));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien
{
    internal class SinhVien
    {
        public String MaSinhVien { get; set; }

        private String _hoTen;
        public String HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ho ten khong duoc de trong!");
                }
                _hoTen = value;
            }
        }
        public String NgaySinh { get; set; }
        public String GioiTinh { get; set; }

        private String? _email;
        public String? Email
        {
            get { return _email; }
            set
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!string.IsNullOrWhiteSpace(value) && !Regex.IsMatch(value, emailPattern))
                {
                    throw new ArgumentException("Email khong dung dinh dang");
                }
                _email = value;
            }
        }
        public String SoDienThoai { get; set; }
        public String NganhHoc { get; set; }

        private float _diemTrungBinh;
        public float DiemTrungBinh
        {
            get { return _diemTrungBinh; }
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("Diem khong hop le!");
                }
                _diemTrungBinh = value;
            }
        }

        public String TrangThaiHocTap { get; set; }

    }
}

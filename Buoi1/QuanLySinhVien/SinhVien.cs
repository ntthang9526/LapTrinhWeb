using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    internal class SinhVien
    {
        public String MaSinhVien { get; set; }
        public String HoTen { get; set; }
        public String NgaySinh { get; set; }
        public String GioiTinh { get; set; }
        public String Email { get; set; }
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
                    Console.WriteLine("Diem khong hop le!");
                    return;
                }
                _diemTrungBinh = value;
            }
        }

        public String TrangThaiHocTap { get; set; }

    }
}

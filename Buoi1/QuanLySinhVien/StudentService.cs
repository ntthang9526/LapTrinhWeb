using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    internal class StudentService
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        public void ThemSinhVien(SinhVien svMoi)
        {
            bool kiemTra = danhSachSinhVien.Any(sv => sv.MaSinhVien.Equals(svMoi.MaSinhVien));
            if (!kiemTra)
            {
                danhSachSinhVien.Add(svMoi);
            }
            else
            {
                throw new InvalidOperationException("Ma sinh vien da ton tai!");
            }
        }
        public void CapNhatThongTin(string maSinhVien, SinhVien thongTinSinhVien)
        {
            SinhVien? sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
            if (sinhVien != null)
            {
                sinhVien.Update(thongTinSinhVien);
                return;
            }
            else
            {
                throw new KeyNotFoundException("Sinh vien khong ton tai!");
            }
        }
        public void XoaSinhVien(string maSinhVien)
        {

            SinhVien? sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
            if (sinhVien != null)
            {
                danhSachSinhVien.Remove(sinhVien);
                return;
            }
            else throw new KeyNotFoundException("Sinh vien khong ton tai!");
        }
        public SinhVien TimSinhVienTheoMa(string maSinhVien)
        {
            SinhVien? sinhVien = danhSachSinhVien.FirstOrDefault(sv => sv.MaSinhVien == maSinhVien);
            if (sinhVien != null)
            {
                return sinhVien;
            }
            throw new KeyNotFoundException("Khong tim thay sinh vien");

        }
        public List<SinhVien> TimSinhVienTheoTen(string text) 
        {
            text = text.ToLower();
            List<SinhVien> danhSach = danhSachSinhVien.Where(sv => sv.HoTen.ToLower().Contains(text)).ToList();
            return danhSach;
        }
        public List<SinhVien> SapXepTheoTen()
        {
            List<SinhVien> danhSach = danhSachSinhVien.OrderBy(sv => sv.GetTen()).ToList();
            return danhSach;
        }
        public List<SinhVien> SapXepTheoDiem()
        {
            List<SinhVien> danhSach = danhSachSinhVien.OrderByDescending(sv => sv.DiemTrungBinh).ToList();
            return danhSach;
        }
        public List<SinhVien> DanhSachSinhVienTheoDiem(float diem)
        {
            List<SinhVien> danhSach = danhSachSinhVien.Where(sv => sv.DiemTrungBinh >= diem).ToList();
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
        public Dictionary<string,List<SinhVien>> ThongKeSinhVienTheoNganh()
        {
            Dictionary<string, List<SinhVien>> dictionary = new Dictionary<string, List<SinhVien>>();
            foreach (SinhVien sv in danhSachSinhVien)
            {
                if (!dictionary.ContainsKey(sv.NganhHoc))
                {
                    dictionary.Add(sv.NganhHoc, new List<SinhVien>());
                }
                dictionary[sv.NganhHoc].Add(sv);
            }
            return dictionary;

            //return danhSachSinhVien.GroupBy(sv => sv.NganhHoc).ToDictionary(group => group.Key, group
            //    => group.ToList());
            
        }
        public Dictionary<string, List<SinhVien>> ThongKeSinhVienTheoTrangThai()
        {
            Dictionary<string, List<SinhVien>> dictionary = new Dictionary<string, List<SinhVien>>();
            foreach (SinhVien sv in danhSachSinhVien)
            {
                if (!dictionary.ContainsKey(sv.TrangThaiHocTap))
                {
                    dictionary.Add(sv.TrangThaiHocTap, new List<SinhVien>());
                }
                dictionary[sv.TrangThaiHocTap].Add(sv);
            }
            return dictionary;
        }
    }
}

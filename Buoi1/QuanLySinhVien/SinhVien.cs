using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien
{
    internal class SinhVien
    {
        public string MaSinhVien { get; set; }

        private string _hoTen;
        public string HoTen
        {
            get { return _hoTen; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ho ten khong duoc de trong!");
                }
                else if (value.Any(char.IsDigit)){
                    throw new ArgumentException("Họ tên không được có chữ số!");
                } ;
                string[] text = value.Split();
                value = "";
                foreach (string word in text)
                {
                    if (string.IsNullOrEmpty(word)) continue;
                    value += word[..1].ToUpper() + word[1..].ToLower() + " ";
                }
                _hoTen = value.Trim();
            }
        }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }

        private string? _email;
        public string? Email
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
        public string SoDienThoai { get; set; }
        public string NganhHoc { get; set; }

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

        public string TrangThaiHocTap { get; set; }

        public SinhVien(string maSinhVien, string hoTen, string ngaySinh, string gioiTinh, string? email, string soDienThoai, string nganhHoc, float diemTrungBinh, string trangThaiHocTap)
        {
            this.MaSinhVien = maSinhVien;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.Email = email;
            this.SoDienThoai = soDienThoai;
            this.NganhHoc = nganhHoc;
            this.DiemTrungBinh = diemTrungBinh;
            this.TrangThaiHocTap = trangThaiHocTap;
        }
        public void Update(SinhVien sv)
        {
            this.HoTen = sv.HoTen;
            this.NgaySinh = sv.NgaySinh;
            this.GioiTinh = sv.GioiTinh;
            this.Email = sv.Email;
            this.SoDienThoai = sv.SoDienThoai;
            this.NganhHoc = sv.NganhHoc;
            this.DiemTrungBinh = sv.DiemTrungBinh;
            this.TrangThaiHocTap = sv.TrangThaiHocTap;
        }
        public string GetTen()
        {
            string[] texts = _hoTen.Split();
            return texts[^1];
        }
    }
}

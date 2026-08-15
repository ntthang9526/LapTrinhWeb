using QuanLySinhVien.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien.Models
{
    internal class Student
    {
        public string MaSinhVien { get; set; }
        public string HoTen { get; set; }
        public DateOnly NgaySinh { get; set; }
        public GioiTinh GioiTinh { get; set; }

        public string? Email { get; set; }
        public string SoDienThoai { get; set; }
        public string NganhHoc { get; set; }

        public float DiemTrungBinh { get; set; }

        public TrangThaiHocTap TrangThaiHocTap { get; set; }

        public Student()
        {
            this.MaSinhVien = string.Empty;
            this.HoTen = string.Empty;
            this.Email = string.Empty;
            this.SoDienThoai = string.Empty;
            this.NganhHoc = string.Empty;
        }
        public Student(string maSinhVien, string hoTen, DateOnly ngaySinh, GioiTinh gioiTinh, string? email, string soDienThoai, string nganhHoc, float diemTrungBinh, TrangThaiHocTap trangThaiHocTap)
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
        public void Update(Student sv)
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
            string[] texts = this.HoTen.Split();
            return texts[^1];
        }
    }
}

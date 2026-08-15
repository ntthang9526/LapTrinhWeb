using QuanLySinhVien.Enums;
using QuanLySinhVien.InputHelpers;
using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.View
{
    internal class StudentConsoleView
    {
        private string formatColumn = "| {0,-5}| {1,-20} | {2,-10} | {3,-5} | {4,-20} | {5,-13} | {6,-20} | {7,-10} | {8,-15} |";
        public void HienThiTieuDe()
        {
            Console.WriteLine(formatColumn, "Ma SV", "Ho Ten", "Ngay Sinh", "GT", "Email", "SDT", "Nganh Hoc", "Diem TB", "TT Hoc Tap");
        }
        public void HienThiDanhSach(List<Student> danhSach)
        {
            if (danhSach == null)
            {
                Console.WriteLine("Danh sach rong");
                return;
            }
            HienThiTieuDe();
            foreach (Student sv in danhSach)
            {
                Console.WriteLine(formatColumn, sv.MaSinhVien, sv.HoTen, $"{ sv.NgaySinh:dd/MM/yyyy}", LayGioiTinh(sv.GioiTinh), sv.Email,
                                                sv.SoDienThoai, sv.NganhHoc, sv.DiemTrungBinh, LayTTHocTap(sv.TrangThaiHocTap));
            }
        }
        public void HienThiThongTin(Student sv)
        {
            if (sv != null)
            {
                HienThiTieuDe();
                Console.WriteLine(formatColumn, sv.MaSinhVien, sv.HoTen, $"{sv.NgaySinh:dd/MM/yyyy}", LayGioiTinh(sv.GioiTinh), sv.Email,
                                                sv.SoDienThoai, sv.NganhHoc, sv.DiemTrungBinh, LayTTHocTap(sv.TrangThaiHocTap));
            }
        }
        public Student NhapThongTin(string studentID, bool isAdd = true)
        {
            Student student = new Student();
            Console.Write(isAdd ? "" :
                                      "==========CAP NHAT THONG TIN==========\nMa sinh vien: " + studentID + "\n");
            student.MaSinhVien = studentID;
            student.HoTen = InputHelper.ReadFullName("Nhap ho ten: ");
            student.NgaySinh = InputHelper.ReadDob("Nhap ngay sinh (dd/MM/yyyy): ");
            student.GioiTinh = InputHelper.ReadGioiTinh();
            student.Email = InputHelper.ReadEmail("Nhap email: ");
            student.SoDienThoai = InputHelper.ReadPhoneNumber("Nhap so dien thoai: ");
            student.NganhHoc = InputHelper.ReadNonEmptyString("Nhap nganh hoc: ");
            student.DiemTrungBinh = InputHelper.ReadFloat("Nhap diem trung binh: ",0,10);
            student.TrangThaiHocTap = InputHelper.ReadTrangThaiHocTap();
            return student;
        }
        public void ThongKeSinhVien(string info, Dictionary<string,List<Student>> danhSach)
        {
            string format = "|{0,-30}| {1,-15}|";
            Console.WriteLine(format, info, "SL Sinh Vien");
            foreach(string txt in danhSach.Keys)
            {
                Console.WriteLine(format, txt, danhSach[txt].Count);
            }
        }
        public void ThongKeSinhVien(string info, Dictionary<TrangThaiHocTap, List<Student>> danhSach)
        {
            string format = "|{0,-30}| {1,-15}|";
            Console.WriteLine(format, info, "SL Sinh Vien");
            foreach (TrangThaiHocTap txt in danhSach.Keys)
            {
                Console.WriteLine(format, txt, danhSach[txt].Count);
            }
        }
        private string LayGioiTinh(GioiTinh gender)
        {
            return gender switch
            {
                GioiTinh.Nam => "Nam",
                GioiTinh.Nu => "Nu",
                GioiTinh.Khac => "Khac",
                _ => "Khong xac dinh"
            };
        }
        private string LayTTHocTap(TrangThaiHocTap status)
        {
            return status switch
            {
                TrangThaiHocTap.BoHoc => "Bo hoc",
                TrangThaiHocTap.DangHoc => "Dang hoc",
                TrangThaiHocTap.BaoLuu => "Bao luu",
                TrangThaiHocTap.DaTotNghiep => "Da tot nghiep",
                _ => "Khong xac dinh"
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using QuanLySinhVien.InputHelpers;
using QuanLySinhVien.Models;
using QuanLySinhVien.Services;
using QuanLySinhVien.View;

namespace QuanLySinhVien.Manager
{
    internal class MenuManager
    {
        private StudentService _service;
        private StudentConsoleView _view;
        public MenuManager(StudentService studentService, StudentConsoleView studentConsoleView)
        {
            this._service = studentService;
            this._view = studentConsoleView;
        }
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                HienThiMenu();
                int choice = InputHelper.ReadInt("Vui long nhap lua chon cua ban: ");
                if (choice < 0 || choice > 13)
                {
                    Console.WriteLine("Lua chon khong hop le! Vui long chon lai");
                    continue;
                }
                switch (choice){
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Tam biet!");
                        return;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("==========NHAP THONG TIN SINH VIEN==========");
                        string studentID = InputHelper.ReadNonEmptyString("Nhap ma sinh vien: ").ToUpper();
                        Student student = _view.NhapThongTin(studentID, true);
                        if (_service.ThemSinhVien(student)){
                            Console.WriteLine("Them thanh cong!");
                            if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: ")))
                            {
                                continue;
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            string option = InputHelper.ReadOption("Sinh vien da ton tai, ban co muon cap nhat thong tin? (Y/N): ");
                            if (option == "Y")
                            {
                                if (_service.CapNhatThongTin(student.MaSinhVien, student))
                                {
                                    Console.WriteLine("Cap nhat thanh cong!");
                                    continue;
                                }
                                else
                                {
                                    Console.WriteLine("Loi!!!");
                                    return;
                                }
                            }
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("==========DANH SACH SINH VIEN==========");
                        _view.HienThiDanhSach(_service.DanhSachSinhVien);
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: ")))
                        {
                            continue;
                        }
                        else
                        {
                            return;
                        }
                    case 3:
                        Console.Clear();
                        string ID = InputHelper.ReadNonEmptyString("Nhap ma sinh vien can tim: ").ToUpper();
                        Student? sv = _service.TimSinhVienTheoMa(ID);
                        if (sv != null)
                        {
                            _view.HienThiThongTin(sv);
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien!");
                        }

                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;
                    case 4:
                        Console.Clear();
                        string text = InputHelper.ReadFullName("Nhap ho ten can tim: ");
                        List<Student> danhSach = _service.TimSinhVienTheoTen(text);
                        if (danhSach != null)
                        {
                            _view.HienThiDanhSach(danhSach);
                        }
                        else
                        {
                            Console.WriteLine("Khong tim thay sinh vien!");
                        }

                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;
                    case 5:
                        Console.Clear();
                        string studentID5 = InputHelper.ReadNonEmptyString("Nhap ma sinh vien can cap nhat: ").ToUpper();
                        Student? student5 = _service.TimSinhVienTheoMa(studentID5);
                        if (student5 != null)
                        {
                            if (CheckYNOption(InputHelper.ReadOption("Sinh vien da ton tai, ban co muon cap nhat? (Y/N): ")))
                            {
                                if (_service.CapNhatThongTin(studentID5, _view.NhapThongTin(studentID5, false))) Console.WriteLine("Cap nhat thanh cong!");
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (CheckYNOption(InputHelper.ReadOption("Sinh vien khong ton tai, ban co muon them moi? (Y/N): ")))
                            {
                                if (_service.ThemSinhVien(_view.NhapThongTin(studentID5, true))) Console.WriteLine("Them thanh cong");
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;
                    case 6:
                        Console.Clear();
                        string studentID6 = InputHelper.ReadNonEmptyString("Nhap ma sinh vien can xoa: ").ToUpper();
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co chac chan muon xoa? Y/N: ")))
                        {
                            if (_service.XoaSinhVien(studentID6))
                            {
                                Console.WriteLine("Xoa thanh cong!");
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sinh vien!");
                            }
                        }

                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 7:
                        Console.Clear();
                        Console.WriteLine("==========DANH SACH SAP XEP THEO TEN==========");
                        List<Student> danhSachSapXepTheoTen = _service.SapXepTheoTen();
                        _view.HienThiDanhSach(danhSachSapXepTheoTen);
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 8:
                        Console.Clear();
                        Console.WriteLine("==========DANH SACH SAP XEP THEO DIEM TRUNG BINH==========");
                        List<Student> danhSachSapXepTheoDiem = _service.SapXepTheoDiem();
                        _view.HienThiDanhSach(danhSachSapXepTheoDiem);
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 9:
                        Console.Clear();
                        Console.WriteLine("==========DANH SACH SINH VIEN CO DIEM TREN 8=========");
                        List<Student> danhSachTren8 = _service.DanhSachSinhVienTheoDiem(8);
                        _view.HienThiDanhSach(danhSachTren8);
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 10:
                        Console.Clear();
                        Console.WriteLine("==========DANH SACH SINH VIEN DIEM CAO NHAT=========");
                        List<Student> danhSachDiemCaoNhat = _service.DanhSachSinhVienTheoDiem(_service.DiemCaoNhat());
                        _view.HienThiDanhSach(danhSachDiemCaoNhat);
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 11:
                        Console.Clear();
                        Console.WriteLine("==========DIEM TRUNG BINH==========");
                        Console.WriteLine("So luong sinh vien: " + _service.SoLuongSinhVien());
                        Console.WriteLine("Diem trung binh toan bo sinh vien: " + _service.DiemTrungBinh());
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                    case 12:
                        Console.Clear();
                        Console.WriteLine("==========THONG KE SINH VIEN THEO NGANH==========");
                        _view.ThongKeSinhVien("Nganh hoc", _service.ThongKeSinhVienTheoNganh());
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;
                    case 13:
                        Console.Clear();
                        Console.WriteLine("==========THONG KE SINH VIEN THEO NGANH==========");
                        _view.ThongKeSinhVien("Trang thai", _service.ThongKeSinhVienTheoTrangThai());
                        if (CheckYNOption(InputHelper.ReadOption("\n\nBan co muon tiep tuc su dung? Y/N: "))) continue;
                        else return;

                }
                
            }
        }
        public void HienThiMenu()
        {
            Console.WriteLine("======= MENU QUAN LY SINH VIEN =======");
            Console.WriteLine("1. Them sinh vien\n" +
                                "2. Hien thi sinh vien\n" +
                                "3. Tim sinh vien theo ma\n" +
                                "4. Tim gan dung theo ho ten sinh vien\n" +
                                "5. Cap nhat sinh vien\n" +
                                "6. Xoa sinh vien\n" +
                                "7. Sap xep theo ho ten\n" +
                                "8. Sap xep theo diem trung binh\n" +
                                "9. Hien thi sinh vien co diem tu 8 tro len\n" +
                                "10. Hien thi sinh vien co diem cao nhat\n" +
                                "11. Tinh diem trung binh toan bo sinh vien\n" +
                                "12. Thong ke sinh vien theo nganh\n" +
                                "13. Thong ke sinh vien theo trang thai\n" +
                                "0. Ket thuc");
            Console.WriteLine("=======================================\n");
        }
        public bool CheckYNOption(string option)
        {
            option.ToUpper();
            if (option == "Y" || option == "y")
            {
                return true;
            }
            return false;
        }
    }
}

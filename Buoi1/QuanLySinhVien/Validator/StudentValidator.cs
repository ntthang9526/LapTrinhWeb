using QuanLySinhVien.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien.Validator
{
    internal class StudentValidator
    {
        public bool IsValidStudent(Student student)
        {
            if (student == null)
            {
                Console.WriteLine("Sinh vien khong hop le!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(student.MaSinhVien))
            {
                Console.WriteLine("Ma sinh vien khong duoc de trong!");
                return false;
            }
            if (!IsValidName(student.HoTen))
            {
                return false;
            }
            if (!IsValidDob(student.NgaySinh))
            {
                return false;
            }
            if (!IsValidEmail(student.Email)) return false;

            if (!IsValidPhoneNumber(student.SoDienThoai)) return false;

            if (!IsValidGPA(student.DiemTrungBinh))
            {
                Console.WriteLine("Diem trung binh khong hop le!");
                return false;
            }

            return true;
        }
        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Ho ten khong duoc de trong!");
                return false;
            }
            else if (name.Any(char.IsDigit))
            {
                Console.WriteLine("Ho ten khong the co chu so!");
                return false;
            }
            return true;
        }
        private bool IsValidDob(DateOnly dob)
        {
            if (dob > DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Ngay sinh khong the lon hon ngay hien tai!");
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string? email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$";
            if (string.IsNullOrEmpty(email)) return true;
            if (Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Email khong dung dinh dang!");
                return false;
            }
        }
        private bool IsValidPhoneNumber(string pNumber)    

        {
            if (Regex.IsMatch(pNumber, @"^\d{9,11}$"))
            {
                return true;
            }
            Console.WriteLine("So dien thoai khong hop le!");
            return false;
        }
        private bool IsValidGPA(float gpa)
        {
            return (gpa < 0 || gpa > 10) ? false : true;
        }
    }
}

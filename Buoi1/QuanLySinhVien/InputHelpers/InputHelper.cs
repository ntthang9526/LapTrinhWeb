using QuanLySinhVien.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLySinhVien.InputHelpers
{
    internal static class InputHelper
    {
        public static string ReadNonEmptyString(string txt)
        {
            while (true)
            {
                Console.Write(txt);
                string? input = Console.ReadLine()?.Trim();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }
                Console.WriteLine("Du lieu khong duoc de trong!");
            }
        }
        public static string ReadFullName(string txt)
        {
            while (true)
            {
                string input = ReadNonEmptyString(txt);
                if (input.Any(char.IsDigit))
                {
                    Console.WriteLine("Ho ten khong duoc co chu so!");
                    continue;
                }
                string[] texts = input.Split();
                input = "";
                foreach (string word in texts)
                {
                    if (string.IsNullOrEmpty(word)) continue;
                    input += word[..1].ToUpper() + word[1..].ToLower() + " ";
                }
                return input.Trim();
            }
        }
        public static DateOnly ReadDob(string txt)
        {
            while (true)
            {
                string datePattern = @"^(0[1-9]|[12]\d|3[01])[\/\-\.](0[1-9]|1[0-2])[\/\-.]\d{4}$";
                string dateString = ReadNonEmptyString(txt);
                if (Regex.IsMatch(dateString, datePattern))
                {
                    string[] formats = { "dd/MM/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "ddMMyyyy" };
                    if (DateTime.TryParseExact(dateString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                    {
                        return DateOnly.FromDateTime(date);
                    }
                    else
                    {
                        Console.WriteLine("Ngay thang khong hop le!");
                        continue;
                    }
                }
                Console.WriteLine("Dinh dang khong hop le!");
            }
        }
        public static string ReadEmail(string txt)
        {
            while (true)
            {
                Console.Write(txt);
                string? email = Console.ReadLine();
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,4}$";
                if (string.IsNullOrWhiteSpace(email))
                {
                    return "";
                }

                if (email != null && Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
                {
                    return email.ToLower();
                }
                Console.WriteLine("Email khong dung dinh dang!");
            }
        }
        public static string ReadPhoneNumber(string txt)
        {
            while (true)
            {
                string phoneNumber = ReadNonEmptyString(txt);

                if (Regex.IsMatch(phoneNumber, @"^\d{9,11}$"))
                {
                    return phoneNumber;
                }

                Console.WriteLine("So dien thoai khong hop le!");
            }
        }
        public static int ReadInt(string txt)
        {
            while (true)
            {
                string input = ReadNonEmptyString(txt);
                if (int.TryParse(input,  out int res))
                {
                    return res;
                }
                Console.WriteLine("Gia tri khong hop le");
            }
        }

        public static float ReadFloat(string txt)
        {
            while (true)
            {
                string input = ReadNonEmptyString(txt);
                if (float.TryParse(input, out float res))
                {
                    return res;
                }
                Console.WriteLine("Gia tri khong hop le!");
            }
        }
        public static float ReadFloat(string txt, float min, float max)
        {
            while (true)
            {
                string input = ReadNonEmptyString(txt);
                if (float.TryParse(input, out float res))
                {
                    if (res < min || res > max)
                    {
                        Console.WriteLine("Gia tri khong hop le!");
                        continue;
                    }
                    return res;
                }
                Console.WriteLine("Gia tri khong hop le!");
            }
        }
        public static string ReadOption(string txt)
        {
            while (true)
            {
                string input = ReadNonEmptyString(txt).ToUpper();
                if (input == "Y" || input == "N")
                {
                    return input.ToUpper();
                }
                Console.WriteLine("Lua chon khong hop le! Vui long chon Y/N ");
            }
        }
        public static GioiTinh ReadGioiTinh()
        {
            Console.WriteLine();
            Console.WriteLine("Chọn giới tính:");
            Console.WriteLine("1. Nam");
            Console.WriteLine("2. Nữ");
            Console.WriteLine("3. Khác");

            int choice = ReadInt("Lựa chọn: ");

            return choice switch
            {
                1 => GioiTinh.Nam,
                2 => GioiTinh.Nu,
                3 => GioiTinh.Khac,
                _ => GioiTinh.Khac
            };
        }
        public static TrangThaiHocTap ReadTrangThaiHocTap()
        {
            Console.WriteLine();
            Console.WriteLine("Chọn trạng thái:");
            Console.WriteLine("1. Đang học");
            Console.WriteLine("2. Bảo lưu");
            Console.WriteLine("3. Đã tốt nghiệp");
            Console.WriteLine("0. Thôi học");

            int choice = ReadInt("Lựa chọn: ");

            return choice switch
            {
                1 => TrangThaiHocTap.DangHoc,
                2 => TrangThaiHocTap.BaoLuu,
                3 => TrangThaiHocTap.DaTotNghiep,
                0 => TrangThaiHocTap.BoHoc,
                _ => TrangThaiHocTap.DangHoc
            };
        }
    }
}

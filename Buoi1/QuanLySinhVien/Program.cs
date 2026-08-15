using QuanLySinhVien.Enums;
using QuanLySinhVien.Manager;
using QuanLySinhVien.Services;
using QuanLySinhVien.View;
using System.Text;
public partial class Program
{
    private static void Main(string[] args)
    {
        StudentService studentService = new();
        studentService.LoadData();
        StudentConsoleView studentConsoleView = new();
        MenuManager menuManager = new(studentService, studentConsoleView);

        menuManager.Run();
    }    
}
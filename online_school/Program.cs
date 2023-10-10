using online_school.Models;
using online_school.Services;
using online_school.Views;
using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {

        // Admin student = new Admin("A8", " Admin8", "test8@mail.com", "qwer1324");
        //ServiceAdmin admin = new ServiceAdmin();
        //admin.AddAdmin(student);
        //admin.RemoveAdmin("A1");
        //admin.ShowAdmin();

        ViewAdmin view = new ViewAdmin();
        view.Play();

       // ServiceEnrolment admin = new ServiceEnrolment();
        //Console.Write(admin.frequencyEnrolmentsMin());
        
    }
}
using online_school.Models;
using online_school.Services;
using online_school.Views;
using System.ComponentModel.Design;

internal class Program
{
    private static void Main(string[] args)
    {

       //Student student = new Student("Flavius", " Dancasiu", 20, "1B2A", "qwer1324");
        ViewUser user = new ViewUser();
        user.Play();
        //ServiceCourse curs = new ServiceCourse();
        //ServiceEnrolment enro = new ServiceEnrolment();
       
        //Console.WriteLine(curs.pointsSum(enro.coursesPoints(student)));
    }
}
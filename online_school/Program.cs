using online_school.Models;
using online_school.Services;
using online_school.Views;
using System.ComponentModel.Design;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        //Teacher teacher1 = new Teacher("1A", "prof1@mail.com", "aaa", "Daniel Ionescu", 30);
        //ServiceCourse course = new ServiceCourse();
        //ServiceEnrolment enrolment = new ServiceEnrolment();
        //ServiceStudent student = new ServiceStudent();
        //List<String> idStudent = new List<String>();
       // idStudent.Add("D1F3");
        //idStudent.Add("1A2B");

        //enrolment.GetIdOfStudents("1");
       // foreach(var i in student.GetStudentNameByEnrolmentId(idStudent))
            //Console.WriteLine(i);
        //Console.WriteLine(enrolment.NumberOfStudents("2"));
        //String course1 = "Biology";
        //String id = "2B";
        //foreach (var i in enrolment.GetIdOfStudents("1"))
        //{
        //    Console.WriteLine(i);
        //}
        ViewTeacher view = new ViewTeacher();
        view.Play();
    }
}
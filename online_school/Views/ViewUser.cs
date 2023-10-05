using online_school.Models;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Views
{
    internal class ViewUser
    {
        private ServiceCourse _serviceCourse;
        private ServiceEnrolment _serviceEnrolment;
        private ServiceStudent _serviceStudent;


        private Student student1 = new Student("Flavius", "Dancasiu", 20, "D1F3", "qwer1324", "test@mail.com");

        public string randomID()
        {
            Random random = new Random();
            return random.Next(100, 999).ToString();
            
        }
        public void EnrollToCourse(Student student1)
        {
            ServiceEnrolment enrolment = new ServiceEnrolment();
            

          
            Console.WriteLine("Introduceti numele cursului  la care doriti sa va inscrieti");
            String courseName = Console.ReadLine();


            //Cautam cursul, gasim numele cursului, convertim numele in id
            
            Course course = this._serviceCourse.FindCourseByName(courseName);
            if (_serviceCourse.FindCourseByName(courseName) != null)
            {
                String studentId = student1.GetId();
                String courseId = course.GetId();
                String id = randomID();

                Enrolment enro = new Enrolment(id, studentId, courseId);
                this._serviceEnrolment.AddEnrolment(enro);

                Console.WriteLine("V-ati inscris la cursul de " + courseName + " !");
            }
            else
                Console.WriteLine("Cursul dorit este inexistent.");      
        }
        public void CancelToCourse(Student student1)
        {
            ServiceEnrolment enrolment = new ServiceEnrolment();

            Console.WriteLine("Introduceti numele cursului  la care doriti sa va dezabonati.");
            String courseName = Console.ReadLine();

            //Cautam cursul, gasim numele cursului, convertim numele in id

            Course course = this._serviceCourse.FindCourseByName(courseName);
            if (_serviceCourse.FindCourseByName(courseName) != null)
            {
                String studentId = student1.GetId();
                String courseId = course.GetId();

                this._serviceEnrolment.RemoveEnrolmentByStudIdCourseId(studentId, courseId);

                Console.WriteLine("V-ati dezabonat de la cursul de " + courseName + " !");
            }
            else
                Console.WriteLine("Cursul dorit este inexistent.");
        }
        public void subscription(Student student1)
        {     
            _serviceEnrolment.userSubscriptions(student1.GetId());
        }
        public void showPoints()
        {
            Console.WriteLine("Punctajul total: " + this._serviceCourse.pointsSum(_serviceEnrolment.coursesPoints(student1)));
        }
        public void showSubscriptions()
        {

            List<string> list = this._serviceCourse.subscriptions(_serviceEnrolment.userSubscriptions(student1.GetId()));
          
            for (int i=0;i<list.Count; i++)
            {

                Console.WriteLine(list[i]);
            }
        }


        

        public ViewUser()
        {
            this._serviceCourse = new ServiceCourse();
            this._serviceEnrolment = new ServiceEnrolment();
            this._serviceStudent = new ServiceStudent();
        }
        public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a afisa cursurile.");
            Console.WriteLine("Apasati tasta 2 pentru a va inscrie la un curs.");
            Console.WriteLine("Apasati tasta 3 pentru a va dezabona de la curs. ");
            Console.WriteLine("Apasati tasta 4 pentru a afla la cate materii sunteti inscris.");
            Console.WriteLine("Apasati tasta 5 pentru a afisa materiile la care sunteti inscris.");
            Console.WriteLine("Apasati tasta 6 pentru a vedea punctajul total al materiilor dvs.");
            Console.WriteLine("Apasati tasta 7 pentru a va schimba parola");
            
        }
        public void Play()
        {

            bool running = true;

            int alegere = 0;

            string numeCurs;

            while (running)
            {
                Meniu();

                alegere = Int32.Parse(Console.ReadLine());


                switch (alegere)
                {
                    case 1:
                        this._serviceCourse.ShowCourses();
                        break;
                    case 2:
                        this.EnrollToCourse(student1);
                        break;
                    case 3:
                        this.CancelToCourse(student1);                   
                        break;
                    case 4:
                        Console.WriteLine(this._serviceEnrolment.coursesCounter(student1));
                        break;
                    case 5:
                        this.showSubscriptions();
                        break;
                    case 6:
                        this.showPoints();
                        break;
                    case 7:
                        _serviceStudent.ChangePassword(student1);                    
                        break;
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }




        
    }


   
}

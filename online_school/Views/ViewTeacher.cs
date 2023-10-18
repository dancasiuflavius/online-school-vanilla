using online_school.Services;
using online_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Views
{
    public class ViewTeacher
    {
        private ServiceCourse _serviceCourse;
        private ServiceEnrolment _serviceEnrolment;
        private ServiceStudent _serviceStudent;

        private Teacher teacher1 = new Teacher("1A", "prof1@mail.com", "aaa", "Daniel Ionescu", 30);

        public ViewTeacher()
        {
            _serviceCourse = new ServiceCourse();
            _serviceEnrolment = new ServiceEnrolment();
            _serviceStudent = new ServiceStudent();
        }



        public void UpdateCourse(Teacher teacher1)
        {
            String _numeMaterie = "";
            Console.WriteLine("Introduceti numele cursului pe care doriti sa il editati.");
            _numeMaterie = Console.ReadLine();
            try
            {
                if (this._serviceCourse.IsCourseTeachedBy(_numeMaterie,this.teacher1.GetId()))
                {                         
                    String _newCourseName = "";
                    String _courseDescription = "";
                    int _points = 0;
                    int _duration = 0;             
                        Console.WriteLine("Introduceti numele nou al cursului: ");
                        _newCourseName = Console.ReadLine();

                        Console.WriteLine("Introduceti descrierea cursului: ");
                        _courseDescription = Console.ReadLine();

                        Console.WriteLine("Introduceti punctele alocate cursului: ");

                        _points = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("Introduceti durata cursului (Nr. Saptamani) : ");

                        _duration = Int32.Parse(Console.ReadLine());

                        this._serviceCourse.UpdateCourseByTeacher(_numeMaterie,_newCourseName, _courseDescription, _points, _duration);

                }                
                else
                     Console.WriteLine("Nu puteti edita un curs care nu va apartine.");



            }
                catch (Exception ex)
                {
                    Console.WriteLine("Something went wrong...");
            }

        }
        public void StudentNumber(Teacher teacher1)
        {
            String ceva = "";
            String _numeMaterie = "";
            Console.WriteLine("Introduceti numele cursului la care doriti sa aflati numarul de studenti.");
            _numeMaterie = Console.ReadLine();
            try
            {
                if (this._serviceCourse.IsCourseTeachedBy(_numeMaterie, this.teacher1.GetId()))
                {
                    ceva = this._serviceCourse.GetCourseIdByTeacher(teacher1.GetId());
                    Console.WriteLine("La cursul de " + _numeMaterie + " sunt inscrisi " + this._serviceEnrolment.NumberOfStudents(ceva) + " studenti");
                }
                else
                {
                    Console.WriteLine("Nu puteti afla detalii despre un curs care nu va apartine.");
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }
        public void StudentsName(Teacher teacher1)
        {
            String ceva = "";
            String _numeMaterie = "";
            
            

            Console.WriteLine("Introduceti numele cursului la care doriti sa aflati studenti inscrisi.");
            _numeMaterie = Console.ReadLine();
            try
            {
                
                if (this._serviceCourse.IsCourseTeachedBy(_numeMaterie, this.teacher1.GetId()))
                {
                    
                    String id = this.teacher1.GetId();
                    List<String> idStudenti = new List<String>();
                    List<String> numeStudenti = new List<String>();
                    idStudenti= this._serviceEnrolment.GetIdOfStudents(id);
                    
                    this._serviceStudent.GetStudentNameByEnrolmentId(this._serviceEnrolment.GetIdOfStudents(id));

                    foreach (var i in this._serviceStudent.GetStudentNameByEnrolmentId(this._serviceEnrolment.GetIdOfStudents(id)))
                        Console.WriteLine(i.ToString());




                }
                else
                {
                    Console.WriteLine("Nu puteti afla detalii despre un curs care nu va apartine.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }


            public void Meniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru a edita informatii despre cursul dvs.");
            Console.WriteLine("Apasati tasta 2 pentru a afisa cati elevi sunt inscrisi la materia dvs.");
            Console.WriteLine("Apasati tasta 3 pentru a afista lista studentiilor inscrisi la materia dvs.");
            

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
                        UpdateCourse(teacher1);
                        break;
                    case 2:
                        StudentNumber(teacher1);
                        
                        break;
                    case 3:

                        StudentsName(teacher1);
                        
                        break;
                    
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }
    }
}

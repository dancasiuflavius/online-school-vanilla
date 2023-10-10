using online_school.Models;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Views
{
    internal class ViewAdmin
    {
        private ServiceCourse _serviceCourse;
        private ServiceEnrolment _serviceEnrolment;
        private ServiceStudent _serviceStudent;
        private Admin admin = new Admin("A3","admin3","test3@mail.com","3333");
        //READ WRITE  COURSE ENROLMENT STUDENT


        public ViewAdmin()
        {
            _serviceCourse = new ServiceCourse();
            _serviceEnrolment = new ServiceEnrolment();
            _serviceStudent = new ServiceStudent();
        }
        public void RemoveStudent()
        {
            String id = "";
            Console.WriteLine("Introduceti ID-ul studentului: ");
            id = Console.ReadLine();
            if (this._serviceStudent.RemoveStudent(id) == true)
                Console.WriteLine("Student eliminat cu succes!");
            else
                Console.WriteLine("Nu puteti elimina un student inexistent.");
            
        }
        public void UpdateStudent()
        {
            
            try
            {
                String ID = "";
                String _surname = "";
                String _name = "";
                int _age = 0;
                String _newID = "";
                String _mail = "";
                String _password = "";

                Console.WriteLine("Introduceti ID-ul studentului: ");
                ID = Console.ReadLine();

                Console.WriteLine("Introduceti numele nou al studentului: ");
                _surname = Console.ReadLine();

                Console.WriteLine("Introduceti prenumele nou al studentului: ");
                _name = Console.ReadLine();

                Console.WriteLine("Introduceti numele varsta noua a studentului: ");

                _age = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti ID-ul nou al studentului: ");
                _newID = Console.ReadLine();

                Console.WriteLine("Introduceti email-ul nou al studentului: ");
                _mail = Console.ReadLine();

                Console.WriteLine("Introduceti parola noua a studentului: ");
                _password = Console.ReadLine();

                this._serviceStudent.UpdateStudent(ID, _surname, _name, _age, _newID,_mail, _password);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }           
        }
        public void RemoveEnrolment()
        {
            String id = "";
            Console.WriteLine("Introduceti ID-ul enrolment-ului: ");
            id = Console.ReadLine();
            if(this._serviceEnrolment.RemoveEnrolment(id) ==  true)
                Console.WriteLine("Enrolment eliminat cu succes!");
            else
                Console.WriteLine("Nu puteti elimina un enrolment inexistent.");

        }
        public void UpdateEnrolment()
        {
            try
            {
                String ID = "";
                String _newID = "";
                String _idElev = "";
                String _idCurs = "";
               
                


                Console.WriteLine("Introduceti ID-ul enrolment-ului: ");
                ID = Console.ReadLine();

                Console.WriteLine("Introduceti ID-ul nou al enrolment-ului: ");
                _newID = Console.ReadLine();

                Console.WriteLine("Introduceti ID-ul nou al studentului: ");
                _idElev = Console.ReadLine();

                Console.WriteLine("Introduceti ID-ul nou al cursului: ");
                _idCurs = Console.ReadLine();

                

                this._serviceEnrolment.UpdateEnrolment(ID, _newID, _idElev, _idCurs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }
        public void RemoveCourse()
        {
            String id = "";
            Console.WriteLine("Introduceti ID-ul enrolment-ului: ");
            id = Console.ReadLine();
            if (this._serviceCourse.RemoveCourse(id) == true)
                Console.WriteLine("Curs eliminat cu succes!");
            else
                Console.WriteLine("Nu puteti elimina un curs inexistent.");
        }
        public void UpdateCourse()
        {
            try
            {
                String ID = "";
                String _courseName = "";
                String _courseDescription = "";
                int _points = 0;
                int _duration = 0;
                String _newID = "";


                Console.WriteLine("Introduceti ID-ul cursului: ");
                ID = Console.ReadLine();

                Console.WriteLine("Introduceti numele nou al cursului: ");
                _courseName = Console.ReadLine();

                Console.WriteLine("Introduceti descrierea cursului: ");
                _courseDescription = Console.ReadLine();

                Console.WriteLine("Introduceti punctele alocate cursului: ");

                _points = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti durata cursului (Nr. Saptamani) : ");

                _duration = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Introduceti ID-ul nou al cursului: ");
                _newID = Console.ReadLine();



                this._serviceCourse.UpdateCourse(ID, _courseName, _courseDescription, _points, _duration, _newID);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }
        public void StudentMostEnrolments()
        {
                       
             //Returneaza ID-ul studentului cu cele mai multe inregistrari la cursuri  
            Console.WriteLine(_serviceEnrolment.frequencyEnrolmentsMax());
        }
        public void StudentLessEnrolments()
        {
            Console.WriteLine(_serviceEnrolment.frequencyEnrolmentsMin()); 
            
        }

        public void Meniu()
        {
            
            Console.WriteLine("Apasati tasta 1 pentru a sterge un student din lista.");
            Console.WriteLine("Apasati tasta 2 pentru a modifica datele unui elev.");
            Console.WriteLine("Apasati tasta 3 pentru a sterge un enrolment.");
            Console.WriteLine("Apasati tasta 4 pentru a modifica un enrolment.");
            Console.WriteLine("Apasati tasta 5 pentru a sterge datele unui curs");
            Console.WriteLine("Apasati tasta 6 pentru a modifica un curs.");
            Console.WriteLine("Apasati tasta 7 pentru a afisa ID-ul studentului inscris la cele mai multe cursuri.");
            Console.WriteLine("Apasati tasta 8 pentru a afisa ID-ul studentului inscris la cele mai putine cursuri.");
        }
        public void Play()
        {

            bool running = true;

            int alegere = 0;

            

            while (running)
            {
                Meniu();

                alegere = Int32.Parse(Console.ReadLine());


                switch (alegere)
                {
                    case 1:
                        this.RemoveStudent();
                        break;
                    case 2:
                        this.UpdateStudent();
                        break;
                    case 3:
                        this.RemoveEnrolment();
                        
                        break;
                    case 4:
                        this.UpdateEnrolment();
                        
                        break;
                    case 5:
                        this.RemoveCourse();
                        break;
                    case 6:
                        this.UpdateCourse();
                        break;
                    case 7:
                        this.StudentMostEnrolments();
                        break;
                    case 8:
                        this.StudentLessEnrolments();
                        break;
                    default:
                        Console.WriteLine("Comanda invalida");
                        break;
                }
            }
        }
    }
}

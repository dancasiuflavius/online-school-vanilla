using online_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    public class ServiceStudent
    {
        private List<Student> _studentList;
        private String _filePath;

        public ServiceStudent()
        {
            _studentList = new List<Student>();
            _filePath = GetDirectory();

            this.ReadStudent();
        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            
            string dataFolderPath = Path.Combine(currentDirectory, "Data");
          
            string filePath = Path.Combine(dataFolderPath, "students.txt");
            
            return filePath;
        }
        public void ReadStudent()
        {
            try
            {

                string filePath = GetDirectory();

                // Create a StreamReader to read from the file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // Read and process the file line by line
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        _studentList.Add(new Student(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        //public void WriteStudent(Student student)
        //{
        //    string filePath = GetDirectory();

        //    using(StreamWriter writer = new StreamWriter(filePath))
        //    {
        //       string line;
        //       if(!File.Exists(filePath))
        //       {
        //            File.WriteAllText(filePath, student);
        //       }
        //    }
        //}
        public void ShowStudents()
        {
            for (int i = 0; i < _studentList.Count; i++)
                Console.WriteLine(_studentList[i].GetStudentDescription());
        }

        public bool FindStudentByID(Student student)
        {
            for (int i = 0; i < _studentList.Count(); i++)
            {
                if (student.GetId().Equals(_studentList[i].GetId()))
                    return true;
            }
                
            return false;
        }
       
        public void AddStudent(Student student)
        {
            if (FindStudentByID(student) == true)
                Console.WriteLine("Studentul se afla deja in lista");
            else
                _studentList.Add(student);
            
        }
        public bool RemoveStudent(String id)
        {
            for (int i = 0; i < _studentList.Count; i++)
            {
                if (_studentList[i].GetId().Equals(id))
                {
                    _studentList.RemoveAt(i);

                    return true;
                }
           
            }

            return false;
                                                     
        }
        public void UpdateStudent(String id, String surname, String name, int age, String newId, String mail, String password)
        {
            for (int i = 0; i < _studentList.Count; i++)
            {
                if (_studentList[i].GetId().Equals(id))
                {

                    _studentList[i].SetSurname(surname);
                    _studentList[i].SetName(name);
                    _studentList[i].SetAge(age);
                    _studentList[i].SetId(newId);
                    _studentList[i].SetEmail(mail);
                    _studentList[i].SetPassword(password);
                }
            }
        }
        public void ChangePassword(Student student)
        {
            String oldPw = "";
            String newPw = "";
            Console.WriteLine("Introduceti parola veche.");
            oldPw = Console.ReadLine();
            if (student.GetPassword().Equals(oldPw))
            {
                Console.WriteLine("Introduceti parola noua.");
                newPw = Console.ReadLine();
                student.SetPassword(newPw);
                
                UpdateStudent(student.GetId(), student.GetSurname(), student.GetName(), student.GetAge(), student.GetId(), student.GetEmail(), student.GetPassword());
                Console.WriteLine("Parola schimbata cu succes.");
            }
            else
                Console.WriteLine("Parolele nu corespund. Incercati din nou...");
            
              
        }

       public List<String> GetStudentList(List<String> list)
       {
            List<String> aux = new List<String>();
            
            for (int i = 0; i < _studentList.Count(); i++)

                for (int j = 0; j < list.Count(); j++)

                    if (_studentList[i].GetId().Equals(list[j]))
                    {                       
                        aux.RemoveAt(i);
                    }
            return aux;
       }

    }
}

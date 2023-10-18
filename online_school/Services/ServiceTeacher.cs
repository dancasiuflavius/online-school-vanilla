using online_school.Models;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    internal class ServiceTeacher
    {
        private List<Teacher> _teacherList;
        private string _filePath;
        public ServiceTeacher()
        {
            _teacherList = new List<Teacher>();
            _filePath = GetDirectory();

            this.ReadTeacher();
        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolderPath = Path.Combine(currentDirectory, "Data");
            string filePath = Path.Combine(dataFolderPath, "teachers.txt");
            return filePath;
        }
        public void ReadTeacher()
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
                        _teacherList.Add(new Teacher(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowTeachers()
        {
            for (int i = 0; i < _teacherList.Count(); i++)
                Console.WriteLine(_teacherList[i].GetTeacherDescription());
        }
        public bool FindTeacherByID(Teacher teacher)
        {
            for (int i = 0; i < _teacherList.Count(); i++)
            {
                if (teacher.GetId().Equals(_teacherList[i].GetId()))
                    return true;
            }

            return false;
        }
        public void AddTeacher(Teacher teacher)
        {
            if (FindTeacherByID(teacher) == true)
                Console.WriteLine("Studentul se afla deja in lista");
            else
                _teacherList.Add(teacher);

        }
        public bool RemoveTeacher(String id)
        {
            for (int i = 0; i < _teacherList.Count; i++)
            {
                if (_teacherList[i].GetId().Equals(id))
                {
                    _teacherList.RemoveAt(i);

                    return true;
                }

            }
            return false;
        }
        public void UpdateTeacher(String id, String mail, String password, String name, int age, String newId)
        {
            for (int i = 0; i < _teacherList.Count; i++)
            {
                if (_teacherList[i].GetId().Equals(id))
                {
                    _teacherList[i].SetId(newId);
                    _teacherList[i].SetEmail(mail);
                    _teacherList[i].SetPassword(password);
                    _teacherList[i].SetName(name);
                    _teacherList[i].SetAge(age);  
                }
            }
        }

    }
}

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
        public void ShowStudents()
        {
            for (int i = 0; i < _studentList.Count; i++)
                Console.WriteLine(_studentList[i].GetStudentDescription());
        }

    }
}

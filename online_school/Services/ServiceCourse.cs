using System;
using online_school.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    public class ServiceCourse
    {
        private List<Course> _courseList;
        private String _filePath;

        public ServiceCourse()
        {
            _courseList = new List<Course>();
            _filePath = GetDirectory();

            this.ReadCourse();
        }

        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolderPath = Path.Combine(currentDirectory, "Data");
            string filePath = Path.Combine(dataFolderPath, "courses.txt");
            return filePath;
        }
        public void ReadCourse()
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
                        _courseList.Add(new Course(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowCourses()
        {
            for (int i = 0; i < _courseList.Count(); i++)
                Console.WriteLine(_courseList[i].GetCourseDescription());
        }

    }
}

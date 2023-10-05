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

        //Get pt lista in alta clasa
        // public List<Course> CourseList { get { return _courseList; } }


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


        //~~~CRUD~~~
        #region
        public bool FindCourseByID(Course course)
        {
            for (int i = 0; i < _courseList.Count(); i++)
            {
                if (course.GetId().Equals(_courseList[i].GetId()))
                    return true;
            }

            return false;
        }

        public Course FindCourseByName(String course)
        {
            for (int i = 0; i < _courseList.Count(); i++)
            {
                if (_courseList[i].GetCourseName().Equals(course))
                    return _courseList[i];
            }

            return null;
        }
        public void AddCourse(Course course)
        {
            if (FindCourseByID(course) == true)
                Console.WriteLine("Cursul exista deja");
            else
                _courseList.Add(course);

        }
        public bool RemoveCourse(String id)
        {
            for (int i = 0; i < _courseList.Count; i++)
            {
                if (_courseList[i].GetId().Equals(id))
                {
                    _courseList.RemoveAt(i);
                    return true;
                }
               
            }
            return false;
        }
        public void UpdateCourse(String id, String courseName, String courseDescription, int points, int duration, String newId)
        {
            for (int i = 0; i < _courseList.Count; i++)
            {
                if (_courseList[i].GetId().Equals(id))
                {

                    _courseList[i].SetCourseName(courseName);
                    _courseList[i].SetCourseInformation(courseDescription);
                    _courseList[i].SetPoints(points);
                    _courseList[i].SetDuration(duration);
                    _courseList[i].SetId(newId);
                }
            }
        }
        #endregion

        //~~~Functionalities~~~

        //public String convertIDtoName(String studentId)
        //{
        //    String[] aux = new String[100];
        //    int t = 0;
        //    enro.userSubscriptions(studentId);


        //}
        public int pointsSum(List<String> idCursuri)
        {
            int suma = 0;
          
            

            
            for (int i = 0;i< _courseList.Count();i++)         
            
                for(int j = 0;j< idCursuri.Count();j++)
                
                if (_courseList[i].GetId().Equals(idCursuri[j]))
                {
                    
                    suma = suma + _courseList[i].GetPoints();
                }
                     
            
                
            return suma;
        }
        public List<String> subscriptions(List<String> cursuri)
        {

            List<String> aux = new List<String>();
            String auxiliar;

            for (int i = 0; i < _courseList.Count(); i++)

                for (int j = 0; j < cursuri.Count(); j++)

                    if (_courseList[i].GetId().Equals(cursuri[j]))
                    {
                        auxiliar = _courseList[i].GetCourseName();
                        aux.Add(auxiliar);
                       
                    }
            return aux;
        }
        
    }
}

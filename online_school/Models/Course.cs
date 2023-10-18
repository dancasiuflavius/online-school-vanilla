using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace online_school.Models
{
    public class Course
    {
        private string _id;
        private string _courseName;
        private string _courseInformation;
        private int _points;
        private int _duration;
        private string _teacherID;

        public Course()
        {

        }
        public Course(string id, string courseName, string courseInformation, int points, int duration, string teacherID)
        {
            _id = id;
            _courseName = courseName;
            _courseInformation = courseInformation;
            _points = points;
            _duration = duration;
            _teacherID = teacherID;
        }

        public Course(string proprietati)
        {
            string[] atribute = proprietati.Split(',');
            _id = atribute[0];
            _courseName = atribute[1];
            _courseInformation = atribute[2];
            _points = int.Parse(atribute[3]);
            _duration = int.Parse(atribute[4]);
            _teacherID = atribute[5];
        }

        public String GetCourseDescription()
        {
            String text = "";
            text += "ID curs: " + _id + "\n";
            text += "Nume curs: " + _courseName + "\n";
            text += "Mini-descriere curs: " + _courseInformation + "\n";
            text += "Puncte alocate curs: " + _points + "\n";
            text += "Durata curs: " + _duration + " saptamani" + "\n";
            text += "ID Profesor: " + _teacherID;
            Console.WriteLine();

            return text;
        }
        public string GetId()
        {
            return _id;
        }
        public void SetId(string id)
        {
            _id = id;
        }
        public string GetCourseName()
        {
            return _courseName;
        }
        public void SetCourseName(string courseName)
        {
            this._courseName = courseName;
        }
        public string GetCourseInformation()
        {
            return _courseInformation;
        }
        public void SetCourseInformation(string courseInformation)
        {
            this._courseInformation = courseInformation;
        }
        public int GetPoints()
        {
            return _points;
        }
        public void SetPoints(int points)
        {
            this._points = points;
        }
        public int GetDuration()
        {
            return _duration;
        }
        public void SetDuration(int duration)
        {
            this._duration = duration;
        }
        public string GetTeacherID()
        {
            return _teacherID;
        }
        public void SetTeacherID(String teacherID)
        {
            this._teacherID = teacherID;
        }
    }
}

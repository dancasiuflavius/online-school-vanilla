﻿using online_school.Models;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    public class ServiceEnrolment
    {
        private List<Enrolment> _enrolmentList;

        private string _filePath;

        public ServiceCourse curs = new ServiceCourse();

        

        

        public ServiceEnrolment()
        {
            _enrolmentList = new List<Enrolment>();
            _filePath = GetDirectory();

            this.ReadEnrolment();
        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataFolderPath = Path.Combine(currentDirectory, "Data");
            string filePath = Path.Combine(dataFolderPath, "enrolments.txt");
            return filePath;
        }
        public void ReadEnrolment()
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
                        _enrolmentList.Add(new Enrolment(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        //CRUD
        #region
        public void ShowEnrolments()
        {
            for (int i = 0; i < _enrolmentList.Count(); i++)
                Console.WriteLine(_enrolmentList[i].GetEnrolmentDescription());
        }
        public bool FindEnrolmentByID(Enrolment enrolment)
        {
            for (int i = 0; i < _enrolmentList.Count(); i++)
            {
                if (enrolment.GetId().Equals(_enrolmentList[i].GetId()))
                    return true;
            }
            return false;
        }
        public void AddEnrolment(Enrolment enrolment)
        {
            if (FindEnrolmentByID(enrolment) == true)
                Console.WriteLine("Enrolmentul se afla deja in lista");
            else
                _enrolmentList.Add(enrolment);

        }
        public void RemoveEnrolment(String id)
        {
            for (int i = 0; i < _enrolmentList.Count; i++)
            {
                if (_enrolmentList[i].GetId().Equals(id))
                {
                    _enrolmentList.RemoveAt(i);
                }
                else
                    Console.WriteLine("Nu puteti elimina un enrolment inexistent");
                break;
            }
        }
        public void RemoveEnrolmentByStudIdCourseId(String studentId, String courseId)
        {
            int flag = 0;
            for(int i = 0; i<_enrolmentList.Count; i++)
            {
                if (_enrolmentList[i].GetIdElev().Equals(studentId) && _enrolmentList[i].GetIdCurs().Equals(courseId))
                {
                    _enrolmentList.RemoveAt(i);
                    flag = 1;
                }
                                       
            }
            if (flag == 0)
                Console.WriteLine("Nu puteti elimina un enrolment inexistent");
                
        }
        public void UpdateEnrolment(String id, String newID, String idElev, String idCurs )
        {
            for (int i = 0; i < _enrolmentList.Count; i++)
            {
                if (_enrolmentList[i].GetId().Equals(id))
                {

                    _enrolmentList[i].SetId(newID);
                    _enrolmentList[i].SetIdElev(idElev);
                    _enrolmentList[i].SetIdCurs(idCurs);
                }
            }
        }
        #endregion
        //Functionalities
        public int coursesCounter(Student student)
        {
            int ct = 0;
            for (int i = 0; i < _enrolmentList.Count; i++)
                if (student.GetId().Equals(_enrolmentList[i].GetIdElev()))
                    ct++;
            return ct;

        }
        public String[] userSubscriptions(String studentId)
        {
            String[] aux = new String[100];
            String auxiliar;
            int t = 0;
            for (int i = 0; i < _enrolmentList.Count; i++)
                if (_enrolmentList[i].GetIdElev().Equals(studentId))
                {
                    auxiliar = _enrolmentList[i].GetIdCurs();

                    aux[t] = auxiliar;

                    t++;

                }
            return aux;

        }
        
        public String[] coursesPoints(Student student)
        {
            String[] aux = new String[100];
            String auxiliar;
            int t = 0;
            
            for (int i = 0; i < _enrolmentList.Count; i++)
                if (_enrolmentList[i].GetIdElev().Equals(student.GetId()))
                {
                    auxiliar = _enrolmentList[i].GetIdCurs();
                    
                    aux[t] = auxiliar;
                    
                    t++;
                  
                }
            
                return aux;

        }

    }
}

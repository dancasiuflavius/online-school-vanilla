using online_school.Models;
using online_school.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    public class ServiceEnrolment
    {
        private List<Enrolment> _enrolmentList;

        private string _filePath;
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
        public bool RemoveEnrolment(String id)
        {
            for (int i = 0; i < _enrolmentList.Count; i++)
            {
                if (_enrolmentList[i].GetId().Equals(id))
                {
                    _enrolmentList.RemoveAt(i);
                    return true;
                }
                
            }
            return false;
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
        public List<String> userSubscriptions(String studentId)
        {
            List<String> aux = new List<String>();
            string convertor = "";
            
            int t = 0;
            for (int i = 0; i < _enrolmentList.Count; i++)
                if (_enrolmentList[i].GetIdElev().Equals(studentId))
                {
                    convertor =_enrolmentList[i].GetIdCurs() ;
                    aux.Add(convertor);

                }
            return aux;

        }       
        public List<String> coursesPoints(Student student)
        {
            List<String> aux = new List<String>();
            String auxiliar;
            int t = 0;
            
            for (int i = 0; i < _enrolmentList.Count; i++)
                if (_enrolmentList[i].GetIdElev().Equals(student.GetId()))
                {
                    auxiliar = _enrolmentList[i].GetIdCurs();
                    
                    aux.Add(auxiliar);
                                                 
                }
            
                return aux;

        }
        public String frequencyEnrolmentsMax()
        {
            String[] vector = new String[100];
            String mostFrqElement = "";
            int[] frecventa = new int[100];
            int ct = 0;
            int maxim = -999;


            for (int i = 0; i < _enrolmentList.Count; i++)
            {
                vector[i] = _enrolmentList[i].GetIdElev();
                frecventa[i] = -1;
            }
               
            int n = _enrolmentList.Count;
            for (int i = 0; i < n; i++)
            {
                ct = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (vector[i] == vector[j])
                    {
                        ct++;
                        frecventa[j] = 0;
                    }
                }
                if (frecventa[i] != 0)
                {
                    frecventa[i] = ct;
                }
                if (maxim < ct)
                {
                    maxim = ct;
                    mostFrqElement = vector[i];
                }
                   
            }
            return mostFrqElement;
                               
        }
        public String frequencyEnrolmentsMin()
        {
            String[] vector = new String[100];
            String lessFrqElement = "";
            int[] frecventa = new int[100];
            int ct = 0;
            int minim = 99999;


            for (int i = 0; i < _enrolmentList.Count; i++)
            {
                vector[i] = _enrolmentList[i].GetIdElev();
                frecventa[i] = -1;
            }

            int n = _enrolmentList.Count;
            for (int i = 0; i < n; i++)
            {
                ct = 1;
                for (int j = i + 1; j < n; j++)
                {
                    
                    if (vector[i] == vector[j])
                    {
                        ct++;
                        frecventa[j] = 0;
                    }
                }
                if (frecventa[i] != 0)
                {
                    frecventa[i] = ct;
                }
                if (minim > ct)
                {
                   
                    minim = ct;
                    lessFrqElement = vector[i];
                }

            }
            return lessFrqElement;

        }


    }
}

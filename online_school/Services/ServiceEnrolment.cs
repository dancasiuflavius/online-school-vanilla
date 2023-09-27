using online_school.Models;
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
        public void ShowEnrolments()
        {
            for (int i = 0; i < _enrolmentList.Count(); i++)
                Console.WriteLine(_enrolmentList[i].GetEnrolmentDescription());
        }

    }
}

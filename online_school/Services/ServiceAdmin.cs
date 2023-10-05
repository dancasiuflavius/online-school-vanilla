using online_school.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Services
{
    internal class ServiceAdmin
    {
        private List<Admin> _adminList;
        private String _filePath;

        public ServiceAdmin()
        {
            _adminList = new List<Admin>();
            _filePath = GetDirectory();

            ReadAdmin();
        }
        public string GetDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            string dataFolderPath = Path.Combine(currentDirectory, "Data");

            string filePath = Path.Combine(dataFolderPath, "admins.txt");

            return filePath;
        }
        public void ReadAdmin()
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
                        _adminList.Add(new Admin(line));
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        public void ShowAdmin()
        {
            for (int i = 0; i < _adminList.Count; i++)
                Console.WriteLine(_adminList[i].GetAdminDescription());
        }
        public bool FindAdminByID(Admin admin)
        {
            for (int i = 0; i < _adminList.Count(); i++)
            {
                if (admin.GetId().Equals(_adminList[i].GetId()))
                    return true;
            }

            return false;
        }
        public void AddAdmin(Admin admin)
        {
            if (FindAdminByID(admin) == true)
                Console.WriteLine("Adminul se afla deja in lista");
            else
                _adminList.Add(admin);

        }
        public void RemoveAdmin(String id)
        {
            for (int i = 0; i < _adminList.Count; i++)
            {
                if (_adminList[i].GetId().Equals(id))
                {
                    _adminList.RemoveAt(i);
                }
                else
                    Console.WriteLine("Nu puteti elimina un admin inexistent");
                break;
            }

        }
        public void UpdateAdmin(String id, String name, String email, String password, String newEmail)
        {
            for (int i = 0; i < _adminList.Count; i++)
            {
                if (_adminList[i].GetId().Equals(id))
                {
                    _adminList[i].SetId(id);
                    _adminList[i].SetName(name);
                    _adminList[i].SetMail(newEmail);
                    _adminList[i].SetPassword(password);
                  
                }
            }
        }
       
    }
}

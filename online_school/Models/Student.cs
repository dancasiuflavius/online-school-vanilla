using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Models
{
    public class Student
    {
        private string _surname;
        private string _name;
        private int _age;
        private string _id;
        private string _password;
        private string _type;
        private string _email;

        public Student()
        {

        }
        public Student(string surname, string name, int age, string id, string password, string email)
        {
            this._type = "student";
            _surname = surname;
            _name = name;
            _age = age;
            _id = id;
            _password = password;
            _email = email;

        }
        public Student(string proprietati)
        {
            this._type = "student";
            string[] atribute = proprietati.Split(',');

            _surname = atribute[0];
            _name = atribute[1];
            _age = int.Parse(atribute[2]);
            _id = atribute[3];
            _password = atribute[4];
            //_email = atribute[5];
        }
        public String GetStudentDescription()
        {
            String text = "";
            text += "Nume: " + _surname + "\n";
            text += "Prenume: " + _name + "\n";
            text += "Varsta: " + _age + "\n";
            text += "ID: " + _id + "\n";
            text += "Email: " + _email + "\n";
            text += "Password: " + _password + "\n";

            return text;
        }
        public string GetSurname()
        {
            return _surname;
        }
        public void SetSurname(string surname)
        {
            _surname = surname;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public int GetAge()
        {
            return _age;
        }
        public void SetAge(int age)
        {
            _age = age;
        }
        public string GetId()
        {
            return _id;
        }
        public void SetId(string id)
        {
            _id = id;
        }
        public string GetPassword()
        {
            return _password;
        }
        public void SetPassword(string password)
        {
            _password = password;
        }
        public string GetType()
        {
            return _type;
        }
        public void SetType(String type)
        {
            _type = type;
        }
        public string GetEmail()
        {
            return _email;
        }
        public void SetEmail(string email)
        {
            _email = email;
        }
    }
}

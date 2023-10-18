using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Models
{
    public class Teacher
    {
        private string _name;
        private int _age;
        private string _id;
        private string _type;
        private string _password;
        private string _email;

        public Teacher()
        {

        }
        public Teacher(string id, string email, string parola, string name, int age)
        {
            this._type = "profesor";
            this._id = id;
            this._email = email;
            this._password = parola;
            this._name = name;
            this._age = age;        
        }
        public Teacher(string proprietati)
        {
            this._type = "student";
            string[] atribute = proprietati.Split(',');

            _id = atribute[0];
            _email = atribute[1];
            _password = atribute[2];
            _name = atribute[3];
            _age = int.Parse(atribute[4]);
            
        }

        public String GetTeacherDescription()
        {
            String text = "";
            text += "ID: " + _id + "\n";
            text += "Email: " + _email + "\n";
            text += "Password: " + _password + "\n";
            text += "Nume: " + _name + "\n";
            text += "Varsta: " + _age + "\n";           

            return text;
        }

        public string GetId()
        {
            return _id;
        }
        public void SetId(string id)
        {
            this._id = id;
        }
        public string GetEmail()
        {
            return _email;
        }
        public void SetEmail(string email)
        {
            this._email = email;
        }
        public string GetPassword()
        {
            return _password;
        }
        public void SetPassword(string password)
        {
            this._password = password;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetName(string name)
        {
            this._name = name;
        }
        public int GetAge()
        {
            return _age;
        }
        public void SetAge(int age)
        {
            this._age = age;
        }
    }
}

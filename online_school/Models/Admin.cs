using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Models
{
    internal class Admin
    {
        public String _name;
        public String _email;
        public String _password;
        public String _id;
        public String _type;


        public Admin(String id, String name, String email, String password)
        {
            this._type = "admin";
            _id = id;
            _name = name;
            _email = email;
            _password = password;
            
        }
        public Admin(String proprietati)
        {
            this._type = "admin";
            string[] atribute = proprietati.Split(',');

            _id = atribute[0];
            _name = atribute[1];
            _email = atribute[2];
            _password = atribute[3];
                  
        }
        public String GetAdminDescription()
        {
            String text = "";
            text += "ID: " + _id + "\n";
            text += "Nume: " + _name + "\n";
            text += "Email: " + _email + "\n";
            text += "Parola: " + _password + "\n";       
            

            return text;
        }
        public string GetName()
        {
            return this._name;
        }
        public void SetName(String name)
        {
            this._name = name;
        }
        public string GetMail()
        {
            return this._email;
        }
        public void SetMail(String email)
        {
            this._email = email;
        }
        public string GetPassword()
        {
            return this._password;
        }
        public void SetPassword(string password)
        {
            this._password = password;
        }
        public string GetId()
        {
            return this._id;
        }
        public void SetId(string id)
        {
            this._id = id;
        }

    }
}

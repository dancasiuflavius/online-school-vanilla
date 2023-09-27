using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_school.Models
{
    internal class Enrolment
    {
        private String _id;
        private String _idElev;
        private String _idCurs;
        

        public Enrolment()
        {

        }
        public Enrolment(String id,  String idElev, String idCurs)
        {
            _id = id;
            _idElev = idElev;
            _idCurs = idCurs;
            
        }
        public Enrolment(string proprietati)
        {
            string[] atribute = proprietati.Split(',');

            _id = atribute[0];
            _idElev = atribute[1];
            _idCurs = atribute[2];
            
        }
        public String GetEnrolmentDescription()
        {
            String text = "";
            text += "ID Enrolment: " + _id + "\n";
            text += "ID Student: " + _idElev + "\n";
            text += "ID Course: " + _idCurs + "\n";


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
        public string GetIdCurs()
        {
            return _idCurs;
        }
        public void SetIdCurs(string idCurs)
        {
            _idCurs = idCurs;
        }
        public string GetIdElev()
        {
            return _idElev;
        }
        public void SetIdElev(string idElev)
        {
            _idElev = idElev;
        }


    }
}

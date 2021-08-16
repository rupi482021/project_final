using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Content_Upload_Model.Models.DAL;

namespace Content_Upload_Model.Models
{
    public class Profile
    {
        
        string mail;
        string password;
        string role;//ליאור הוסיפה

        public Profile() { }

        public Profile(string mail, string password, string role)
        {
            Mail = mail;
            Password = password;
            Role = role;
        }

        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }

        public string Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertProfile(this);
        }
    }
}
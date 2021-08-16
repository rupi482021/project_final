using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Kaatsu.Models
{
    public class customer
    {
        int id;
        string email;
        string password;
        string firstName;
        string surName;
        string gender;
        string birthdate;
        string role;
        string photo;
        DateTime registrationDate;
        int categoryType;
        int height;
        double weight;
        string sportType;
        bool activeLastYear;
        bool trainKaatsu;
        bool sportInj;
        bool accident;
        bool metadises;
        string lastLogIn;
        recommendedTrainingProgram TrainingProgram;
        List <recommendedTrainingProgram> recommendedTrainingPrograms;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string SurName { get => surName; set => surName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Birthdate { get => birthdate; set => birthdate = value; }
        public string Role { get => role; set => role = value; }
        public string Photo { get => photo; set => photo = value; }
        public DateTime RegistrationDate { get => registrationDate; set => registrationDate = value; }
        public int CategoryType { get => categoryType; set => categoryType = value; }
        public int Height { get => height; set => height = value; }
        public double Weight { get => weight; set => weight = value; }
        public string SportType { get => sportType; set => sportType = value; }
        public bool ActiveLastYear { get => activeLastYear; set => activeLastYear = value; }
        public bool TrainKaatsu { get => trainKaatsu; set => trainKaatsu = value; }
        public bool SportInj { get => sportInj; set => sportInj = value; }
        public bool Accident { get => accident; set => accident = value; }
        public bool Metadises { get => metadises; set => metadises = value; }
        public string LastLogIn { get => lastLogIn; set => lastLogIn = value; }
        public recommendedTrainingProgram TrainingProgram1 { get => TrainingProgram; set => TrainingProgram = value; }
        public List<recommendedTrainingProgram> RecommendedTrainingPrograms { get => recommendedTrainingPrograms; set => recommendedTrainingPrograms = value; }

        public customer(string email, string password)
        {

            Email = email;
            Password = password;
        }



        public customer(int id)
        {
            Id = id;
            DBServices dbs = new DBServices();
            RecommendedTrainingPrograms = dbs.getRTP(id);
        }

        public customer() { }

        public customer(customer customer)
        {
            Id = customer.Id;
            Email = customer.Email;
            Password = customer.Password;
            FirstName = customer.FirstName;
            SurName = customer.SurName;
            Gender = customer.Gender;
            Birthdate = customer.Birthdate;
            CategoryType = customer.CategoryType;
            Height = customer.Height;
            Weight = customer.Weight;
            SportType = customer.SportType;
            ActiveLastYear = customer.ActiveLastYear;
            TrainKaatsu = customer.TrainKaatsu;
            SportInj = customer.SportInj;
            Accident = customer.Accident;
            Metadises = customer.Metadises;
        }

        public customer(int id, string email, string password, string firstName, string surName, string gender, string birthdate, string role, string photo, DateTime registrationDate, int categoryType, int height, double weight, string sportType, bool activeLastYear, bool trainKaatsu, bool sportInj, bool accident, bool metadises, string lastLogIn, recommendedTrainingProgram trainingProgram1, List<recommendedTrainingProgram> recommendedTrainingPrograms)
        {
            Id = id;
            Email = email;
            Password = password;
            FirstName = firstName;
            SurName = surName;
            Gender = gender;
            Birthdate = birthdate;
            Role = role;
            Photo = photo;
            RegistrationDate = registrationDate;
            CategoryType = categoryType;
            Height = height;
            Weight = weight;
            SportType = sportType;
            ActiveLastYear = activeLastYear;
            TrainKaatsu = trainKaatsu;
            SportInj = sportInj;
            Accident = accident;
            Metadises = metadises;
            LastLogIn = lastLogIn;
            TrainingProgram1 = trainingProgram1;
            RecommendedTrainingPrograms = recommendedTrainingPrograms;
        }

        public customer Check()
        {
            DBServices dbs = new DBServices();
             return dbs.checkUser(this);
        }

        public List<recommendedTrainingProgram> getNewRecommendedTrainingProgram() 
        {
          
            DBServices dbs = new DBServices();
            return RecommendedTrainingPrograms = dbs.getRTP(this.Id);
        }

        public List<recommendedTrainingProgram> getNewRecommendedTrainingProgramAR(int customerId, int userAnswer)
        {

            DBServices dbs = new DBServices();
            return RecommendedTrainingPrograms = dbs.getNewRecommendedTrainingProgramAR(customerId, userAnswer);
        }

        public List<recommendedTrainingProgram> getRecommendedTrainingProgram()
        {
            return RecommendedTrainingPrograms;
        }

        public customer Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.addNewCustomer(this);
        }

        public List<recommendedTrainingProgram> updateCustomerDet()
        {

            DBServices dbs = new DBServices();
            dbs.updateCustomerDet(this);
            return getNewRecommendedTrainingProgram();

        }
        //public List<recommendedTrainingProgram> updateTP(int customerId, int userAnswer)
        //{

        //    DBServices dbs = new DBServices();
        //    dbs.updateCustomerDet(customerId,userAnswer);
        //    return getNewRecommendedTrainingProgram();

        //}

        public recommendedTrainingProgram postTrainingP (recommendedTrainingProgram tPC, int id)
        {
            TrainingProgram1 = new recommendedTrainingProgram(tPC);
            DBServices dbs = new DBServices();
            TrainingProgram1.VideoList = dbs.postTPC(TrainingProgram1, id);
            return TrainingProgram1;
        }

        public void SendMailToUser()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("kaatsuIsrael1@gmail.com");
                mail.To.Add(this.Email);
                mail.Subject = "Message from Kaatsu Israel";
                mail.Body = "היי"+" "+this.FirstName+" " +this.SurName +","+ Environment.NewLine + "לא התחברת למערכת מתאריך"+ " " + this.LastLogIn + ", מקווים שאת חשה בטוב!"+Environment.NewLine +"לכל שאלה/ בעיה או התייעצות מוזמנת לפנות אלינו במייל ל kaatsuIsrael@gmail.com ונחזור אליך בהקדם!" + Environment.NewLine + Environment.NewLine +"קאטסו ישראל"  /*+ this.*/;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("kaatsuIsrael1@gmail.com", "kaatsuIsrael1741LLATY852");
                SmtpServer.EnableSsl = true;
                //SmtpClient smtp = new SmtpClient();
                //if (smtp.EnableSsl == true)
                //    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                //smtp.Send(mail);


                SmtpServer.Send(mail);
            }


            catch (Exception ex)
            {
                throw (ex);
            }

            // ליאור למטה
        }

        public List<customer> getcustomer()
        {
            DBServices dbs = new DBServices();
            List<customer> customerList = dbs.getcustomer();
            return customerList;
        }

        public List<customer> GetUserReport()//lior
        {
            DBServices dbs = new DBServices();
            List<customer> customerList = dbs.GetUserReport();
            return customerList;
        }


        public List<int> GetUsersNotActice()//lior
        {
            DBServices dbs = new DBServices();
            List<int> customerList = dbs.GetUsersNotActice();
            return customerList;
        }

        public List<DateTime> GetUsersDateActice()//lior
        {
            DBServices dbs = new DBServices();
            List<DateTime> customerList = dbs.GetUsersDateActice();
            return customerList;
        }

    }
}
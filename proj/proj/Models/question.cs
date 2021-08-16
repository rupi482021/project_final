using Content_Upload_Model.Controllers;
using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaatsu.Models
{
    public class Question
    {

        private int id;
        private int userId;
        private int managerId;
        private string questionText;
        private string answer;
        private bool status;
        private DateTime created;
        private DateTime answerDate;


        public Question(int id, int userId, int managerId, string questionText, string answer, bool status)
        {
            Id = id;
            UserId = userId;
            ManagerId = managerId;
            QuestionText = questionText;
            Answer = answer;
            Status = status;
        }

        public Question() { }

        public int Id { get => this.id; set => id = value; }

        public int Update(Question question)
        {
            DBServices db = new DBServices();
            return db.UpdateQuestion(question);
        }

        public int Delete(int id)
        {
            DBServices db = new DBServices();
            return db.DeleteQuestion(id);
        }



        public int UserId { get => this.userId; set => userId = value; }
        public int ManagerId { get => this.managerId; set => managerId = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public string Answer { get => answer; set => answer = value; }
        public bool Status { get => status; set => status = value; }
        public DateTime Created { get => created; set => created = value; }
        public DateTime AnswerDate { get => answerDate; set => answerDate = value; }

        public List<Question> GetAll()
        {
            DBServices db = new DBServices();
            return db.GetAllQuestions();
        }

        public int Create(Question question)
        {
            DBServices db = new DBServices();
            int effected = db.CreateQuestion(question);
            return effected;
        }
    }
}
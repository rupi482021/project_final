using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Training
    {
        int id;
        DateTime date;
        int videoId;
        int customerId;
        bool isCompleted;

        int hour;


        public Training(int _Id, int _videoId, DateTime _date, int _customerId, bool _isCompleted, int _hour)
        {
            id = _Id;
            videoId = _videoId;
            date = _date;
            customerId = _customerId;
            isCompleted = _isCompleted;
            hour = _hour;
        }

        public int Id { get => id; set => id = value; }
        public int VideoId { get => videoId; set => videoId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int CustomerId { get => customerId; set => customerId = value; }
        public bool IsCompleted { get => isCompleted; set => isCompleted = value; }
        public int Hour { get => hour; set => hour = value; }


        internal int TrainingDone(int trainingId)
        {
            DBServices dbs = new DBServices();
            return dbs.TrainingDone(trainingId);
        }

        public int Create(Training training)
        {
            DBServices dbs = new DBServices();
            return dbs.CreateTraining(training);
        }

        public Training() { }
        internal IEnumerable<Training> GetAll(int customerId)
        {
            DBServices dbs = new DBServices();
            return dbs.getAllTrainings(customerId);
        }

        internal int Delete(int id)
        {
            DBServices dbs = new DBServices();
            return dbs.DeleteTraining(id);
        }
    }
}
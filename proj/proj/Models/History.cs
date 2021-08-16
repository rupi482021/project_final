using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaatsu.Models.DAL;

namespace proj.Models
{
    public class History
    {
        int customerUseruserId;
        int videoCode;
        DateTime watchDate;

        public History() { }

        public History(int customerUseruserId, int videoCode, DateTime watchDate)
        {
            CustomerUseruserId = customerUseruserId;
            VideoCode = videoCode;
            WatchDate = watchDate;
        }

        public int CustomerUseruserId { get => customerUseruserId; set => customerUseruserId = value; }
        public int VideoCode { get => videoCode; set => videoCode = value; }
        public DateTime WatchDate { get => watchDate; set => watchDate = value; }

        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertWatchVideo(this);
        }

        public List<int> getHistoryByid(int userId)
        {
            DBServices dbs = new DBServices();
            return dbs.getHistoryByid(userId);
        }

    }
}
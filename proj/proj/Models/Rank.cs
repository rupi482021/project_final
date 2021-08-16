using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Content_Upload_Model.Models.DAL;

namespace FinalProj.Models
{
    public class Rank
    {
        int useruserId;
        int videoCode;
        string rankDate;
        string rankValue;
        bool rankLike;

        public Rank() { }

        public Rank(int useruserId, int videoCode, string rankDate, string rankValue, bool rankLike)
        {
            UseruserId = useruserId;
            VideoCode = videoCode;
            RankDate = rankDate;
            RankValue = rankValue;
            RankLike = rankLike;
        }

        public int UseruserId { get => useruserId; set => useruserId = value; }
        public int VideoCode { get => videoCode; set => videoCode = value; }
        public string RankDate { get => rankDate; set => rankDate = value; }
        public string RankValue { get => rankValue; set => rankValue = value; }
        public bool RankLike { get => rankLike; set => rankLike = value; }

        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertRank(this);
        }

        public List<int> getRankByid(int userId)
        {
            DBServices dbs = new DBServices();
            List<int> RankList = dbs.getRankByid(userId);
            return RankList;
        }
    }
}
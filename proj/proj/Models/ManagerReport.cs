using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proj.Models
{
    public class ManagerReport
    {
        int videoCode ;
        string description;
        string caption;
        string sub;
        int categoryCode;
        string levelType;
        int numOfRate;
        int numOfDislikes;
        int numOfLikes;
        int precOfDislikes;
        int precOfLikes;

        public ManagerReport(int videoCode, string description, string caption, string sub, int categoryCode, string levelType, int numOfRate, int numOfDislikes, int numOfLikes, int precOfDislikes, int precOfLikes)
        {
            VideoCode = videoCode;
            Description = description;
            Caption = caption;
            Sub = sub;
            CategoryCode = categoryCode;
            LevelType = levelType;
            NumOfRate = numOfRate;
            NumOfDislikes = numOfDislikes;
            NumOfLikes = numOfLikes;
            PrecOfDislikes = precOfDislikes;
            PrecOfLikes = precOfLikes;
        }

        public ManagerReport() { }

        public int VideoCode { get => videoCode; set => videoCode = value; }
        public string Description { get => description; set => description = value; }
        public string Caption { get => caption; set => caption = value; }
        public string Sub { get => sub; set => sub = value; }
        public int CategoryCode { get => categoryCode; set => categoryCode = value; }
        public string LevelType { get => levelType; set => levelType = value; }
        public int NumOfRate { get => numOfRate; set => numOfRate = value; }
        public int NumOfDislikes { get => numOfDislikes; set => numOfDislikes = value; }
        public int NumOfLikes { get => numOfLikes; set => numOfLikes = value; }
        public int PrecOfDislikes { get => precOfDislikes; set => precOfDislikes = value; }
        public int PrecOfLikes { get => precOfLikes; set => precOfLikes = value; }

        public List<ManagerReport> getVideoRep()
        {

            DBServices dbs = new DBServices();
            List<ManagerReport> getVideoRepList = dbs.getVideoRepList();
            return getVideoRepList;
        }
    }
}
using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaatsu.Models
{
    public class recommendedTrainingProgram
    {
        int customerId;
        int tcode;
        string tname;
        string instuction;
        string levelType;
        string pic;
        bool isForStrengthening;
        bool isForRehabilitation;
        bool isForImproveSport;
        List<video> videoList;
        
        public recommendedTrainingProgram(){}

       

        public recommendedTrainingProgram (recommendedTrainingProgram trainingP)
        {
            CustomerId = trainingP.customerId;
            Tcode = trainingP.Tcode;
            Tname = trainingP.Tname;
            Instuction = trainingP.Instuction;
            LevelType = trainingP.LevelType;
            Pic = trainingP.Pic;
            IsForStrengthening = trainingP.IsForStrengthening;
            IsForRehabilitation = trainingP.IsForRehabilitation;
            IsForImproveSport = trainingP.IsForImproveSport;
        
        }

        public recommendedTrainingProgram(int customerId, int tcode, string tname, string instuction, string levelType, string pic, bool isForStrengthening, bool isForRehabilitation, bool isForImproveSport, List<video> videoList)
        {
            CustomerId = customerId;
            Tcode = tcode;
            Tname = tname;
            Instuction = instuction;
            LevelType = levelType;
            Pic = pic;
            IsForStrengthening = isForStrengthening;
            IsForRehabilitation = isForRehabilitation;
            IsForImproveSport = isForImproveSport;
            VideoList = videoList;
        }

        public int CustomerId { get => customerId; set => customerId = value; }
        public int Tcode { get => tcode; set => tcode = value; }
        public string Tname { get => tname; set => tname = value; }
        public string Instuction { get => instuction; set => instuction = value; }
        public string LevelType { get => levelType; set => levelType = value; }
        public string Pic { get => pic; set => pic = value; }
        public bool IsForStrengthening { get => isForStrengthening; set => isForStrengthening = value; }
        public bool IsForRehabilitation { get => isForRehabilitation; set => isForRehabilitation = value; }
        public bool IsForImproveSport { get => isForImproveSport; set => isForImproveSport = value; }
        public List<video> VideoList { get => videoList; set => videoList = value; }
    }
}
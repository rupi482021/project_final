using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kaatsu.Models.DAL;

namespace proj.Models
{
    public class WatchedVideos
    {
        private int videoId;
        string description;
        string caption;
        string subtitlepath;
        DateTime watchDate;

        public WatchedVideos() { }

        public WatchedVideos(int videoId, string description, string caption, string subtitlepath, DateTime watchDate)
        {
            VideoId = videoId;
            Description = description;
            Caption = caption;
            Subtitlepath = subtitlepath;
            WatchDate = watchDate;
        }

        public int VideoId { get => videoId; set => videoId = value; }
        public string Description { get => description; set => description = value; }
        public string Caption { get => caption; set => caption = value; }
        public string Subtitlepath { get => subtitlepath; set => subtitlepath = value; }
        public DateTime WatchDate { get => watchDate; set => watchDate = value; }

        public List<WatchedVideos> getVideoByid(int userId)
        {
            DBServices dbs = new DBServices();
            List<WatchedVideos> WatchedVideoList = dbs.getVideoByid(userId);
            return WatchedVideoList;
        }

    }
}
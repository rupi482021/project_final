using Content_Upload_Model.Controllers;
using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kaatsu.Models
{
    public class video
    {

        private int videoId;
        string description;
        string caption;
        string subtitlepath;

        public video(int videoId, string description, string caption, string subtitlepath)
        {
            VideoId = videoId;
            Description = description;
            Caption = caption;
            Subtitlepath = subtitlepath;
        }

        public video() { }

        public int VideoId { get => this.videoId; set => videoId = value; }
        public string Description { get => description; set => description = value; }
        public string Caption { get => caption; set => caption = value; }
        public string Subtitlepath { get => subtitlepath; set => subtitlepath = value; }

        public List<video> GetAllVideos()
        {
            DBServices db = new DBServices();
            return db.getAllVideos();
        }

        public bool AddToFavourits(FavoriteVideoRequest fvr)
        {
            DBServices db = new DBServices();
            int effected = db.addToFavourits(fvr.userId, fvr.videoId);
            return effected == 1;
        }

        public bool RemoveFromFavourits(FavoriteVideoRequest fvr)
        {
            DBServices db = new DBServices();
            int effected = db.RemoveFromFavourits(fvr.userId, fvr.videoId);
            return effected == 1;
        }

        public List<video> GetUserFavouritsVideos(string userId)
        {
            DBServices db = new DBServices();
            List<video> videos = db.getUserFavouritsVideos(userId);
            return videos;
        }

        public List<video> getvideoList(int id)
        {
            DBServices dbs = new DBServices();
            return dbs.getvideoList(id);
        }
    }
}
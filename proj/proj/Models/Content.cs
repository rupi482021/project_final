using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Content_Upload_Model.Models.DAL;

namespace Content_Upload_Model.Models
{
    public class Content
    {
        int videoCode;
        string description;
        string caption;      
        string subtitlepath;
        int categoryCode;
        List<Tag> tagsArray;
       

        public Content() { }

        public Content(int videoCode, string description, string caption, string subtitlepath, int categoryCode, List<Tag> tagsArray)
        {
            VideoCode = videoCode;
            Description = description;
            Caption = caption;
            Subtitlepath = subtitlepath;
            CategoryCode = categoryCode;
            TagsArray = tagsArray;
        }

        public int VideoCode { get => videoCode; set => videoCode = value; }
        public string Description { get => description; set => description = value; }
        public string Caption { get => caption; set => caption = value; }
        public List<Tag> TagsArray { get => tagsArray; set => tagsArray = value; }
        public string Subtitlepath { get => subtitlepath; set => subtitlepath = value; }
        public int CategoryCode { get => categoryCode; set => categoryCode = value; }

        public List<Content> getcontents()
        {
            DBServices dbs = new DBServices();
            List<Content> contentsList = dbs.getContents();

            return contentsList;
        }

        public string Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.InsertContent(this);
        }

        public void UpdateContent(Content content)
        {
            DBServices dbs = new DBServices();
            dbs.updateContent(content);
        }

        public void DeleteContent(int VideoCode)
        {
            DBServices dbs = new DBServices();
            dbs.DeleteContent(VideoCode);
        }
    }


}
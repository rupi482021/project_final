using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Content_Upload_Model.Models.DAL;

namespace Content_Upload_Model.Models
{
    public class Tag
    {
        int tagcode;
        string tagname;

        public Tag(int tagcode, string tagname)
        {
            Tagcode = tagcode;
            Tagname = tagname;
        }

        public int Tagcode { get => tagcode; set => tagcode = value; }
        public string Tagname { get => tagname; set => tagname = value; }

        public Tag() { }

        public List<Tag> gettags()
        {
            DBServices dbs = new DBServices();
            List<Tag> tagList = dbs.gettags();
            return tagList;
        }

        public List<Tag> gettagsByvideo(int videocode)
        {
            DBServices dbs = new DBServices();
            List<Tag> tagList = dbs.gettagsByvideo(videocode);
            return tagList;
        }
    }
}
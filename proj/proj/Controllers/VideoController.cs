using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Content_Upload_Model.Models;
using Kaatsu.Models;
using proj.Models;

namespace Content_Upload_Model.Controllers
{
    public class VideoController : ApiController
    {
        // GET api/video
        public IEnumerable<video> Get()
        {
            video v = new video();
            return v.GetAllVideos();
        }

        // GET api/video/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/video
        public void Create([FromBody]video value)
        {
        }

        [HttpPost]
        [Route("api/Video/Like")]
        public bool Like([FromBody]FavoriteVideoRequest fvr)
        {
            video v = new video();
            return v.AddToFavourits(fvr);
        }

        [HttpPost]
        [Route("api/Video/RemoveFromFavourits")]
        public bool RemoveFromFavourits([FromBody]FavoriteVideoRequest fvr)
        {

            video v = new video();
            return v.RemoveFromFavourits(fvr);
        }

        [HttpPost]
        [Route("api/Video/Favourits/{userId:int}")]
        public List<video> Favourits([FromUri()] int userId)
        {
            video v = new video();
            return v.GetUserFavouritsVideos(userId.ToString());
        }

        //LIOR
        [HttpGet]
        [Route("api/Video/getVideoByid/{userId}")]
        public HttpResponseMessage getVideoByid(int userId)
        {

            try
            {
                WatchedVideos w = new WatchedVideos();
                List<WatchedVideos> WatchedVideoList = w.getVideoByid(userId);
                return Request.CreateResponse(HttpStatusCode.OK, WatchedVideoList);
            }
            catch (Exception ex)
            {
                if (ex.Message == "failed to connect to the server")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }

        }

        // PUT api/video/5
        public void Put(int id, [FromBody]video value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }
    }
    public class FavoriteVideoRequest
    {
        public string videoId { get; set; }
        public string userId { get; set; }
    }
}
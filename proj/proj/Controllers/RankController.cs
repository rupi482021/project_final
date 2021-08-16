using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProj.Models;

namespace FinalProj.Controllers
{
    public class RankController : ApiController
    {
        public int Post([FromBody] Rank r)
        {
            //try
            //{
            int result = r.Insert();
            return result;
            //return Request.CreateResponse(HttpStatusCode.OK, Rname);
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message == "failed to connect to the server")
            //    {
            //        //500
            //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

            //    }
            //    else if (ex.Message == "no content was inserted")
            //    {
            //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            //        //throw (ex);
            //    }
            //    else return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            //}
        }


        //LIOR
        [HttpGet]
        [Route("api/Rank/getRankByid/{userId}")]
        public HttpResponseMessage getRankByid(int userId)
        {

            try
            {
                Rank w = new Rank();
                List<int> RankList = w.getRankByid(userId);
                return Request.CreateResponse(HttpStatusCode.OK, RankList);
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

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
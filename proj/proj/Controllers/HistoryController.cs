using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using proj.Models;

namespace proj.Controllers
{
    public class HistoryController : ApiController
    {

        public HttpResponseMessage Post([FromBody] History h)
        {
            try
            {
                int Vcode = h.Insert();
                return Request.CreateResponse(HttpStatusCode.OK, Vcode);
            }
            catch (Exception ex)
            {
                if (ex.Message == "failed to connect to the server")
                {
                    //500
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);

                }
                else if (ex.Message == "no content was inserted")
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
                    //throw (ex);
                }
                else return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        //LIOR
        [HttpGet]
        [Route("api/History/getHistoryByid/{userId}")]
        public HttpResponseMessage getHistoryByid(int userId)
        {

            try
            {
                History h = new History();
                List<int> WatchedHistoryList = h.getHistoryByid(userId);
                return Request.CreateResponse(HttpStatusCode.OK, WatchedHistoryList);
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

        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}


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
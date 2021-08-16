using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Content_Upload_Model.Models;

namespace Content_Upload_Model.Controllers
{
    public class TagsController : ApiController
    {
        public HttpResponseMessage Get()
        {

            try
            {
                Tag t = new Tag();
                List<Tag> tagList = t.gettags();
                return Request.CreateResponse(HttpStatusCode.OK, tagList);
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



        [HttpGet]
        [Route("api/Tags/getByid/{videocode}")]
        public HttpResponseMessage getByid(int videocode)
        {

            try
            {
                Tag t = new Tag();
                List<Tag> tagList = t.gettagsByvideo(videocode);
                return Request.CreateResponse(HttpStatusCode.OK, tagList);
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

        // GET api/<controller>

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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
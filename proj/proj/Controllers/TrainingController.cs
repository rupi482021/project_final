using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Content_Upload_Model.Models;
using FinalProj.Models;
using Kaatsu.Models;

namespace Content_Upload_Model.Controllers
{
    public class TrainingController : ApiController
    {
        // GET 
        [Route("api/Training/userTrainings/{userId:int}")]
        public IEnumerable<Training> GetUserTrainings([FromUri()] int userId)
        {
            Training v = new Training();
            return v.GetAll(userId);
        }
        [HttpGet]
        [Route("api/Training/TrainingDone/{trainingId:int}")]
        public bool TrainingDone([FromUri()] int trainingId)
        {
            Training v = new Training();
            int rowsEffected = v.TrainingDone(trainingId);
            return rowsEffected == 1;
        }

        // GET api/training/5
        public string Get(int id)
        {
            return null;
        }

        // POST api/training
        public bool Create([FromBody]Training value)
        {
            Training v = new Training();
            //?
            int rowsEffected = v.Create(value);
            return rowsEffected == 1;
        }

        // PUT 
        public void Put(int id, [FromBody]TrainingRequest value)
        {
        }

        
        // DELETE 
        public bool Delete(int id)
        {
            Training v = new Training();
            int rowsEffected = v.Delete(id);
            return rowsEffected == 1;
        }
    }
    public class TrainingRequest
    {
        public string videoId { get; set; }
        public string userId { get; set; }
        public DateTime date { get; set; }
    }
}
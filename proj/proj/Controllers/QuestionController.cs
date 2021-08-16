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
    public class QuestionController : ApiController
    {
        // GET 
        public IEnumerable<Question> Get()
        {
            Question q = new Question();
            return q.GetAll();
        }


        // POST api/question
        public bool Create([FromBody]Question value)
        {
            Question q = new Question();

            int rowsEffected = q.Create(value);
            return rowsEffected == 1;
        }

        // PUT 
        [HttpPost()]
        [Route("api/Question/UpdateQuestion")]
        public bool UpdateQuestion(Question question)
        {
            Question q = new Question();
            int rowsEffected = q.Update(question);
            return rowsEffected == 1;
        }


        [HttpDelete()]
        public bool Delete([FromUri]int id)
        {
            Question q = new Question();
            int rowsEffected = q.Delete(id);
            return rowsEffected == 1;
        }
    }

}
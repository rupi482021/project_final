using Kaatsu.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kaatsu.Controllers
{
    public class DBServiceController : ApiController
    {

        public void Post([FromBody] string check)
        {

            DBServices sentMail = new DBServices();
            //sentMail.sentMail();

        }

    }
}
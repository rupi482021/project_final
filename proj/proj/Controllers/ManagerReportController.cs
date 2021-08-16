using proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace proj.Controllers
{
    public class ManagerReportController : ApiController
    {
        public List<ManagerReport> GET()
        {
            try
            {
                ManagerReport videoRep = new ManagerReport();
                return videoRep.getVideoRep();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}
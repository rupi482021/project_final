using Kaatsu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace Kaatsu.Controllers
{
    public class customerController : ApiController
    {
        public customer GET(string email, string password)
        {
            try
            {
                customer cus = new customer(email, password);
                return cus.Check();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public List<recommendedTrainingProgram> GET(int id)
        {
       
            try
            {
                customer cus = new customer(id);
                return cus.getRecommendedTrainingProgram();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        [Route("api/customer/videoList")]
        public List<video> getVideoList(int id)
        {

            try
            {
                video video = new video();
                return video.getvideoList(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public customer Post([FromBody] customer customer)
        {

            customer insertCust = new customer(customer);
            return insertCust.Insert();

        }

        public List<recommendedTrainingProgram> Put([FromBody] customer upCustomer)
        {
            customer upCus = upCustomer;
            return upCus.updateCustomerDet();
        }

        public List<recommendedTrainingProgram> Put(int customerId, int userAnswer)
        {
            customer cust = new customer();
            return cust.getNewRecommendedTrainingProgramAR(customerId, userAnswer);
        }

        [Route("api/customer/cTP")]
        public recommendedTrainingProgram PostTPC(recommendedTrainingProgram tPC)
        {

            customer Cust = new customer();
            Cust.Id = tPC.CustomerId;
            return Cust.postTrainingP(tPC, Cust.Id);

        }



        // ליאור למטה

        public HttpResponseMessage Get()
        {

            try
            {
                customer c = new customer();
                List<customer> customerList = c.getcustomer();
                return Request.CreateResponse(HttpStatusCode.OK, customerList);
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
        [Route("api/customer/GetUserReport")]
        public HttpResponseMessage GetUserReport()
        {

            try
            {
                customer c = new customer();
                List<customer> customerList = c.GetUserReport();
                return Request.CreateResponse(HttpStatusCode.OK, customerList);
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
        [Route("api/customer/GetUsersNotActice")]
        public HttpResponseMessage GetUsersNotActice()
        {

            try
            {
                customer c = new customer();
                List<int> customerList = c.GetUsersNotActice();
                return Request.CreateResponse(HttpStatusCode.OK, customerList);
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
        [Route("api/customer/GetUsersDateActice")]
        public HttpResponseMessage GetUsersDateActice()
        {

            try
            {
                customer c = new customer();
                List<DateTime> customerList = c.GetUsersDateActice();
                return Request.CreateResponse(HttpStatusCode.OK, customerList);
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
    }


}

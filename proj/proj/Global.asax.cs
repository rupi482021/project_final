using System;using System.Collections.Generic;using System.Linq;using System.Web;using System.Web.Http;using System.Web.Mvc;using System.Web.Optimization;using System.Web.Routing;using System.IO;using System.Timers;using Kaatsu.Models.DAL;using System.Threading;


namespace proj
{
    public class WebApiApplication : System.Web.HttpApplication
    {
            static Thread keepAliveThread = new Thread(KeepAlive);
            protected void Application_Start()
            {
                AreaRegistration.RegisterAllAreas();
                GlobalConfiguration.Configure(WebApiConfig.Register);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                keepAliveThread.Start();
            }

            static void mail()
            {

                DBServices sentMail = new DBServices();
                //sentMail.sentMail();
            }
            static void KeepAlive()
            {

                while (true)
                {
                    try
                    {
                        //mail();
                        Thread.Sleep(1000);

                    }
                    catch (ThreadAbortException)
                    {
                        break;
                    }
                }
            }

        }
}

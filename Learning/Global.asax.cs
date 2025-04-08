using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Timers;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace QC_Check
{

    public class Global : System.Web.HttpApplication
    {

        private static Timer reportTimer;


        protected void Application_Start(object sender, EventArgs e)
        {
         
        }
        
      

        //==================================================================================================================================

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            // You can log the error here if needed (e.g., log to file or DB)

            // Redirect to error page
            Server.Transfer("~/ErrorPage.aspx");
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
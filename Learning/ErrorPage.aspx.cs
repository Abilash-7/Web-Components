using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Learning
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            //if (ex != null)
            //{
            //    errormsg.Text = ex.Message;
            //    //lblStackTrace.Text = ex.StackTrace;
            //}



            if (ex != null)
            {
                // Traverse to the innermost exception
                Exception realEx = ex;
                while (realEx.InnerException != null)
                {
                    realEx = realEx.InnerException;
                }

                // Show full exception info
                errormsg.Text = $"{realEx.GetType()}: {realEx.Message}";
                //lblStackTrace.Text = realEx.StackTrace;
            }

        }
    }
}
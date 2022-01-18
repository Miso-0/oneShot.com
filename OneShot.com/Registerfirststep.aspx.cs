using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class Registerfirststep : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((index)Master).GetFooter.Visible = false;
            ((index)Master).GetTopHeader.Visible = false;
            ((index)Master).GetMiddleHeader.Visible = false;
            error.Visible = false;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Get the Email ,First name , and last name from the user 
            //Check if the user exist in the database
            //if the user exists  , notify them
            //else Redirect to the RegisterStepTwo page for them to enter the rest of their information
            //Use a query string or a session variable to transport to the following pages
            string email = emailaddress.Value;
            if (!client.IsRegistered(email.ToString()))
            {
                Session["EmailAddress"] = emailaddress.Value;
                Response.Redirect("Registersteptwo.aspx");
            }
            else
            {
                error.InnerText = "Email address already registered";
                error.Visible = true;
            }
        }
    }
}
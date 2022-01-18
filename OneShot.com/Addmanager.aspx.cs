using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashPass;

namespace OneShot.com
{
    public partial class Addmanager : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((index)Master).GetFooter.Visible = false;
            ((index)Master).GetTopHeader.Visible = false;
            ((index)Master).GetMiddleHeader.Visible = false;
            ((index)Master).GetMainHeader.Visible = false;
            error.Visible = false;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string dateReg = DateTime.Now.ToString("d");
            string email = emailaddress.Value;
            if (!client.IsRegistered(email))
            {
                if (!client.UserIDRegistered(IdNumber.Value.ToString()))
                {
                    if (re_enter_Password.ToString().Equals(NewPassword.ToString()))
                    {
                        if (client.RegisterUser(IdNumber.Value, FirstName.Value, LastName.Value, emailaddress.Value, contactNumber.Value,"Johannesburg", "Johannesburg CyberKnights OneShot.com", "Manager", Secrecy.HashPassword(NewPassword.Value),dateReg))
                        {
                            Response.Redirect("users.aspx");
                        }
                        else
                        {
                            error.InnerText = "Something went wrong  try again";
                            error.Visible = true;
                        }
                    }
                    else
                    {
                        error.InnerText = "Passwords do not match" + re_enter_Password.Value + " " + NewPassword;
                        error.Visible = true;
                    }
                }
                else
                {
                    error.InnerText = "ID number already registered";
                    error.Visible = true;
                }
            }
            else
            {
                error.InnerText = "This  email address is already registered";
                error.Visible = true;
            }
        }
    }
}
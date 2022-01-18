using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class Registersteptwo : System.Web.UI.Page
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
            //Get the rest of the user input and  also the information on the session variable
            //Transfere the information to the next page

            if (re_enter_Password.ToString().Equals(NewPassword.ToString()))
            {
                if (!client.UserIDRegistered(IdNumber.Value.ToString())){
                    Session["Firstname"] = FirstName.Value;
                    Session["Lastname"] = LastName.Value;
                    Session["ID"] = IdNumber.Value;
                    Session["ContactNumber"] = contactNumber.Value;
                    Session["Password"] = NewPassword.Value;

                    Response.Redirect("Registerlaststep.aspx");
                }
                else
                {
                    error.InnerText = "ID number already registered";
                    error.Visible = true;
                }
            }
            else
            {
                error.InnerText = "Passwords do not match";
                error.Visible = true;
            }
        }
    }
}
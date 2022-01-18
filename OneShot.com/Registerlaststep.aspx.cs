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
    public partial class Registerlaststep : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((index)Master).GetFooter.Visible = false;
            ((index)Master).GetTopHeader.Visible = false;
            ((index)Master).GetMiddleHeader.Visible = false;
            error.Visible = false;
        }

        private bool upadateAddresss()
        {
            bool updated;
            if (Province.Value != "Province")
            { 
                string id = Session["ID"].ToString();
               string  address = stAddress.Value + ", " + complax.Value + ", " + suburb.Value + ", " + city.Value + ", " + Province.Value + ", " + postalcode.Value;
                if (client.UpdateAddress(id,address))
                {
                    updated = true;
                }
                else
                {
                    updated = false;
                    error.InnerText = "Something went wrong , please try again";
                    error.Visible = true;
                }
            }
            else
            {
                updated = false;
                error.InnerText = "Select a province";
                error.Visible = true;
            }
            return updated;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Gather all the user information , user address 
            //and register the user 
            //Redirect to sign in page

            //update address
            if (Request.QueryString["change"] != null)
            {
                if (this.upadateAddresss())
                {
                    Response.Redirect("delivery.aspx");
                }
            }
            else
            {

                string dateReg = DateTime.Now.ToString("d");
                string address;
                string emailaddress = Session["EmailAddress"].ToString();
                string FName = Session["Firstname"].ToString();
                string LName = Session["Lastname"].ToString();
                string ID = Session["ID"].ToString();
                string Contact = Session["ContactNumber"].ToString();
                string password = Session["Password"].ToString();

                if (Province.Value != "Province")
                {
                    address = stAddress.Value + ", " + complax.Value + ", " + suburb.Value + ", " + city.Value + ", " + Province.Value + ", " + postalcode.Value;
                    if (client.RegisterUser(ID, FName, LName, emailaddress, Contact, city.Value, address, "Customer", Secrecy.HashPassword(password), dateReg))
                    {
                        string Month = DateTime.Now.ToString("MMM");
                        client.AddRegisteredUser(Month);
                        Session.RemoveAll();
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        error.InnerText = "Something went wrong , please try again";
                        error.Visible = true;
                    }
                }
                else
                {
                    error.InnerText = "Select a province";
                    error.Visible = true;
                }
            }
        }
    }
}
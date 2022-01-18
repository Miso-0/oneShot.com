using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class account : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
             
                if (Session["Usertype"].ToString().Equals("Customer"))
                {
                    string userID = Session["ID"].ToString();
                    var customer = client.GetUser(userID);
                    FirstName.InnerText = customer.FiratName;
                    LastName.InnerText = customer.LastName;
                    contactNumber.InnerText = customer.UserContact;
                    emailAddress.InnerText = customer.UserEmail;
                    CustomerAddress.InnerText = customer.UserAddress;
                    int tlist = client.GetItemsONcustomerList(Session["ID"].ToString()).Count();
                    listitemsTotal.InnerText = "" + tlist;
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                
            }
        }
    }
}
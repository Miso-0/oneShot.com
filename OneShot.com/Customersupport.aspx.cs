using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class Customersupport : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //  ((index)Master).GetFooter.Visible = false;
            //    ((index)Master).GetTopSection.Visible = false;
            //      ((index)Master).GetMiddleSec.Visible = false;
            if (Session["ID"] != null)
            {
                if (Session["Usertype"].ToString().Equals("Manager"))
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    LoadMessages();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void LoadMessages()
        {
           string displayMessages = "";
            string ID = Session["ID"].ToString();
            var Messages = client.GetMessages(ID);

            foreach(CustomerMessage cm in Messages)
            {
                if (cm.Sender.Equals("Customer"))
                {
                    displayMessages += "<div class='Usertext'><p>"+cm.MessageText + "</p><p style='font-size: 11px; margin-top: 10px;'>" + cm.MessageDate.ToString("g") + "</p></div>";
                }else if (cm.Sender.Equals("Manager"))
                {
                    displayMessages += "<div class='ManagerReply'><p>"+cm.MessageText + "</p><p style='font-size: 11px; margin-top: 10px;'>" + cm.MessageDate.ToString("g") + "</p></div>";
                }
            }
            messages.InnerHtml = displayMessages;
        }
     

        protected void btnsend_ServerClick(object sender, EventArgs e)
        {
            string id = Session["ID"].ToString();
            if (!String.IsNullOrEmpty(UserInputSupport.Value))
            {
                if (client.NewMessage(id, UserInputSupport.Value, "Customer"))
                {
                    Response.Redirect("Customersupport.aspx");
                }
                else
                {
                    Response.Redirect("Customersupport.aspx");
                }
            }
            else
            {
                Response.Redirect("Customersupport.aspx");
            }
        }
    }
}

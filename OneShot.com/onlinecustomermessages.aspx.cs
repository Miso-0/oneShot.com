using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class onlinecustomermessages : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadMessages();
            this.LoadSideNav();
        }

        //Gets messages from the database and displays then to a manager that is loged in
        public void LoadMessages()
        {
            string displayMessages = "";
            //Get encrypted user id and decrypt it
            string id = Request.QueryString["id"];
            var Messages = client.GetMessages(QueryStringModule.Decrypt(id));
            client.UpdateMessageStatus(QueryStringModule.Decrypt(id));
            foreach (CustomerMessage cm in Messages)
            {
                if (cm.Sender.Equals("Customer"))
                {
                    displayMessages += "<div class='Usertext'><p>" + cm.MessageText + "</p><p style='font-size: 11px; margin-top: 10px;'>"+cm.MessageDate.ToString("g")+"</p></div>";
                }
                else if (cm.Sender.Equals("Manager"))
                {
                    displayMessages += "<div class='ManagerReply'><p>" + cm.MessageText + "</p><p style='font-size: 11px; margin-top: 10px;'>" + cm.MessageDate.ToString("g") + "</p></div>";
                }
            }
                   messages.InnerHtml = displayMessages;
        }

        public void LoadSideNav()
        {
            string display = "";
            foreach(CustomerMessage message in client.GetMessagesDisplay())
            {
                display += "<li><a href='onlinecustomermessages.aspx?id=" + message.UserID + "'><span>"+client.GetUser(message.UserID).FiratName+" "+ client.GetUser(message.UserID).LastName+ "</span><span class='material-icons-outlined'>arrow_right</span></a></li>";
            }

            sidenavViewer.InnerHtml = display;
        }



        protected void btnsend_ServerClick(object sender, EventArgs e)
        {
            string id = QueryStringModule.Decrypt(Request.QueryString["id"]);
            if (!String.IsNullOrEmpty(UserInputSupport.Value))
            {
                if (client.NewMessage(id, UserInputSupport.Value, "Manager"))
                {
                    Response.Redirect("onlinecustomermessages.aspx?id=" + QueryStringModule.Encrypt(id));
                }
                else
                {
                    Response.Redirect("onlinecustomermessages.aspx?id=" + QueryStringModule.Encrypt(id));
                }
            }
            else
            {
                Response.Redirect("onlinecustomermessages.aspx?id=" + QueryStringModule.Encrypt(id));
            }
        }
    }
}
using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class onlinesupport : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadMessages();
        }


        private void LoadMessages()
        {
            var allMessages = new List<CustomerMessage>();
            foreach (CustomerMessage massage in client.GetMessagesDisplay())
            {
                foreach (CustomerMessage m in client.GetMessages(massage.UserID))
                {
                    allMessages.Add(m);
                }

          }

        
    
            string display = "";
            int count = 1;
            display += "<table class='admimTable'><tr><th>#No.</th><th>Customer name</th><th>Date sent</th><th>Status</th><th>View</th></tr>";
            foreach(CustomerMessage massage in client.GetMessagesDisplay())
            {
                display += "<tr><td>#"+count+"</td><td>"+client.GetUser(massage.UserID).FiratName+" "+ client.GetUser(massage.UserID).LastName+ "</td><td>"+massage.MessageDate.ToString("g")+"</td><td>";
                if (allMessages.Exists(m => m.MessageStatus.Equals("unread")&&m.Sender.Equals("Customer")&&m.UserID.Equals(massage.UserID))){
                    display += "<span class='material-icons'>done</span>";
                }
                else
                {
                    display += "<span class='material-icons'>done_all</span>";
                }
                display += "</td><td><a href='onlinecustomermessages.aspx?id=" + massage.UserID+"'><span class='material-icons'>visibility</span></a></td></tr>";
                count++;
            }
            loadmessages.InnerHtml= display;
        }
    }
}


/*    

               
                    
                       
                    






            "</table>"  */
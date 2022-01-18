using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class users : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadUsers();
        }

        public void LoadUsers()
        {
            string display = "";
            var users = client.GetUsers();
            display += "<table class='admimTable'><tr><th>#No.</th><th>Full name</th><th>Email address</th><th>Contact No.</th><th>Date registered</th><th>User type</th><th>Actions</th></tr>";
            int count = 1;
            foreach(User user in users)
            {
                display += "<tr><td>#" + count+"</td><td>"+user.FiratName+" "+user.LastName+"</td><td>"+user.UserEmail+"</td><td>"+user.UserContact+"</td><td>"+user.DateRegistered.ToString("d")+"</td><td>"+user.UserType+"</td>";
                if (user.UserType.Equals("Manager"))
                {
                    display += "<td><a href='#'><span class='material-icons'>delete_outline</span></a></td></tr>";
                }
                else
                {
                    display += "<td><span class='material-icons'>fiber_manual_record</span></td></tr>";
                }
              
                count += 1;
            }
            display += "</table>";
            usersdisplay.InnerHtml = display;
        }
    }
}
/*

*/
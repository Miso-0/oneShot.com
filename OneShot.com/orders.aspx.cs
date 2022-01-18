using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class orders : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadOrders();
        }

        private void LoadOrders()
        {
            string display = "";
            var orders = client.GetAllOrders();
            int count = 1;
            display += "<table class='admimTable'><tr><th>#No.</th><th>Customer</th><th>Order ID</th><th>Order Status</th><th>Est delivery time</th><th>Actions</th></tr>";
            foreach(Order order in orders)
            {
                var customer = client.GetUser(order.UserID);
                display += "<tr><td>#"+count+"</td><td>"+customer.FiratName+" "+customer.LastName+"</td><td>"+order.OrderID+"</td><td>"+order.OrderStatus+"</td>";
                display += "<td>"+order.OrderEstDate+ "</td><td><a href='Track.aspx?orderId="+order.OrderID+ "&userid="+QueryStringModule.Encrypt(customer.UserID)+"'><span class='material-icons'>edit</span></a></td></tr>";
                count++;
            }
            display += "</table>";
            showOrders.InnerHtml = display;
        }
    }
}

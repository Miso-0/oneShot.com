using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class myorders : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {


            this.LoadOrders();

              
        }

        private void LoadOrders()
        {
     
            if (Session["ID"] != null)
            {
                string display = "";
                string userid = Session["ID"].ToString();
                var orders = client.GetOrders(userid);
                List<Order> orders1 = new List<Order>();
                foreach (Order order in orders)
                {
                    if (!order.OrderStatus.Equals("Order arrived"))
                    {
                        orders1.Add(order);
                    }
                }
                if (orders1.Count() == 0)
                {
                    emptyOrders.Visible = true;
                }
                else
                {
                    emptyOrders.Visible = false;
                    display += "<table class='my-account-table'><tr><th>ORDER ID</th><th>ITEMS</th><th>AMOUNT PAID</th><th>EST ARRIVAL TIME</th><th>TRACK</th></tr>";

                    foreach (Order order in orders1)
                    {
                           var transaction = client.GetTransaction(order.OrderID);
                           display += "<tr class='item-row-account'><td>" + order.OrderID + "</td><td>" + transaction.NumberOfItems + "</td><td>R" + Math.Round(transaction.TransactionAmount, 2) + "</td>";
                           display += "<td>" + order.OrderEstDate + "</td><td><a href='Track.aspx?orderId=" + order.OrderID + "'><span class='material-icons-outlined'>gps_fixed</span></a></td></tr>";
                    }
                    display += "</table>";
                    showOrders.InnerHtml = display;
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}


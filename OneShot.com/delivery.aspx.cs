using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class delivery : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.proccessOrder();
        }
        public int GetTotalNumOnCart(string userid)
        {
            int count = 0;
            foreach (onCart item in client.GetOnCart(userid))
            {
                count += item.qty;
            }
            return count;
        }


        private void proccessOrder()
        {
            string userID = Session["ID"].ToString();
            numonCart.InnerText = "" + GetTotalNumOnCart(userID);
            var user = client.GetUser(userID);
            username.InnerText = user.FiratName + " " + user.LastName;
            customeraddress.InnerText = user.UserAddress;
            customerEmail.InnerText = user.UserEmail;
            cutomerContact.InnerText = user.UserContact;
            //Estimate time
            string estimatedTime = DateTime.Now.AddHours(1).ToString("g");
            estimatedDeliveryTime.InnerText = estimatedTime;
            double cartTotal = Convert.ToDouble(Session["cartTotal"].ToString());

   
            double delivery = Convert.ToDouble(Session["delivery"].ToString());
            double orderTotalT = cartTotal + delivery;
            TotalOnCart.InnerText = "R" + cartTotal;
            totalDelivery.InnerText = "R" + delivery;
            orderTotal.InnerText = "R" +Math.Round(orderTotalT, 2);

            if (cartTotal >= 250)
            {
                deliverybanner.Visible = false;
            }
        }

        public bool Paid()
        {
            bool paid = false;
            double cartTotal = Convert.ToDouble(Session["cartTotal"].ToString());
            double delivery = Convert.ToDouble(Session["delivery"].ToString());
            double orderTotalT = cartTotal + delivery;
            string userId = Session["ID"].ToString();
            
       
            var ItemsOnCart = client.getItemsonCart(userId);
            string Recipt = "";
            int num = 0;
            foreach (Item item in ItemsOnCart)
            {
                var itemCartReference = client.GetItemOnCart(userId, item.ItemCode);
                var i = client.GetItem(item.ItemCode);
                string line = i.ItemName + "\t" + itemCartReference.qty + "\tR" +Math.Round(itemCartReference.itemTotalPrice,2)+"\n";
                Recipt += line;
                num++;
            }
            string orderDate = DateTime.Now.ToString("g");
            string estimatedTime = DateTime.Now.AddHours(1).ToString("g");

            string orderid = this.GenerateOrderID();
            bool orderadded = client.AddOrder(orderid, userId, orderDate, estimatedTime, "Order confirmed");

            if (orderadded)
            {
                bool transAdded = client.AddTransaction(orderid, orderDate, orderTotalT, Recipt,num);
                if (transAdded)
                {
                    Session["orderID"] = orderid;
                }
            }
          
            foreach (Item item in ItemsOnCart)
            {
                var itemCartReference = client.GetItemOnCart(userId, item.ItemCode);
                int qtyToMinus = itemCartReference.qty;
                if (client.DeleteItem(itemCartReference.ItemCode, userId))
                {
                    if (client.ReduceItemQTY(itemCartReference.ItemCode, qtyToMinus)){
                        paid = true;
                    }
                    else
                    {
                        //Handlle error
                        paid = false;
                    }
                }
                else
                {
                    //handle error
                    paid = false;
                }
            }
            //Record revenu amount
            string month = DateTime.Now.ToString("MMM");
            if (client.AddLineGraphInfor(orderTotalT,month))
            {
                paid = true;
            }
            return paid;
        }

        private string GenerateOrderID()
        {
            string orderID = "";
            Random random = new Random();
            int n = random.Next(10000, 32343423);
            string portentialID = "OD-" + n;
            List<string> ids = new List<string>();

            foreach (Order order in client.GetAllOrders())
            {
                ids.Add(order.OrderID);
            }
            string i="";
            if (!ids.Contains(portentialID))
            {
                i = portentialID;
            }

            if (!i.Equals(""))
            {
                 orderID=i;
            }
            return orderID;
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            if (this.Paid())
            {

                string Month = DateTime.Now.ToString("MMM");
                client.AddOderedUser(Month);

                string orderid = Session["orderID"].ToString();
                Session.Remove("orderID");
                var tran = client.GetTransaction(orderid);
                var order = client.GetOrderByID(orderid);
                var customer = client.GetUser(Session["ID"].ToString());
                string body = "Order id: " + order.OrderID +"Items("+tran.NumberOfItems+")\n"+ "\n Estimated Delivery time: " + order.OrderEstDate+ "\n Delivery Address: " + customer.UserAddress +
                    "\n Items Bought: \n" + tran.TransactionRecipt + "\n";
                helperClass.SendEmail(customer.UserEmail, customer.FiratName + " " + customer.LastName, "Please find your OneShot.com Order Recipt below", body);
                Response.Redirect("Track.aspx?orderId="+orderid);
            }
        }
        }
}
using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class Track : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
           ((index)Master).GetFooter.Visible = false;
            updatebtns.Visible = false;
            if(Session["Usertype"]!=null && Session["Usertype"].ToString().Equals("Manager"))
            {
                updatebtns.Visible = true;
            }
            this.LoadTracker();
        }

        public void LoadTracker()
        {

            if (Request.QueryString["orderId"] != null)
            {
                string orderId = Request.QueryString["orderId"];
                var order = client.GetOrderByID(orderId);
                var transaction = client.GetTransaction(order.OrderID);
                qty.InnerText = "" + transaction.NumberOfItems;
                totalAmount.InnerText = "R" + Math.Round(transaction.TransactionAmount, 2);
                Useraddress.InnerText = client.GetUser(order.UserID).UserAddress;
                date.InnerText = order.OrderEstDate;
                this.CheckStatus(order.OrderStatus);
                trackerID.InnerText = order.OrderID;
            }
            else
            {
                Response.Redirect("myorders.aspx");
            }
         }

        private void CheckStatus(string status)
        {
        
            if (status.Equals("Order confirmed"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "15%");
            }
            else if (status.Equals("Picked up by courier"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "40%");
            }
            else if (status.Equals("On the way"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "60%");
            }
            else if (status.Equals("Order arrived"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "100%");
            }
        }

        private bool UpdateOrder(string newStatus)
        {
            bool updated;
            if(Request.QueryString["userid"]!=null&& Request.QueryString["orderId"] != null)
            {
                string orderid = Request.QueryString["orderId"];
                string userid =QueryStringModule.Decrypt(Request.QueryString["userid"]);
                if (client.UpdateOrderStatus(newStatus, userid, orderid))
                {
                    updated = true;
                     Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "window.location.href='Track.aspx?orderId="+ orderid + "&userid=" + QueryStringModule.Encrypt(userid)+"';", true);
                }
                else
                {
                    updated = false;
                }
            }
            else
            {
                updated = false;
            }

            return updated;
        }
        
        protected void btnSt1(object sender, EventArgs e)
        {

            if (this.UpdateOrder("Order confirmed"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "15%");
            }
        }
        protected void btnSt2(object sender, EventArgs e)
        {
            if (this.UpdateOrder("Picked up by courier"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "40%");
            }
        }
        protected void btnSt3(object sender, EventArgs e)
        {
            if (this.UpdateOrder("On the way"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "white");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "60%");
            }
        }
        protected void btnSt4(object sender, EventArgs e)
        {
            if (this.UpdateOrder("Order arrived"))
            {
                c1.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c2.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c3.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                c4.Attributes.CssStyle.Add(HtmlTextWriterStyle.BackgroundColor, "rgb(0, 175, 58)");
                pBar.Attributes.CssStyle.Add(HtmlTextWriterStyle.Width, "100%");
            }
        }
    }
}
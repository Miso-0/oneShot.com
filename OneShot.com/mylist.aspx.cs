using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OneShot.com.ServiceReference1;

namespace OneShot.com
{
    public partial class mylist : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            emptylist.Visible = false;
            this.LoadUserList();
        }
        private void LoadUserList()
        {
            string display = "";
            if (Session["ID"] != null)
            {
                int tlist = client.GetItemsONcustomerList(Session["ID"].ToString()).Count();
                listitemsTotal.InnerText = "" + tlist;
                string id = Session["ID"].ToString();
                var customerList = client.GetItemsONcustomerList(id);
                if (customerList.Count() == 0)
                {
                    emptylist.Visible = true;
                }
                else
                {
                    emptylist.Visible = false;
                    foreach (Item item in customerList)
                    {
                        display += "<div class='each-item-my-list'><div class='imgview-and-info'><img src='" + item.ItemImageUrl + "' alt='img'>";
                        display += "</div><div class='item-name'><h4>" + item.ItemName + "</h4></div>";
                        display += "<div class='item-infor-prices'><h4>R" + Math.Round(Convert.ToDouble(item.ItemPrice), 2) + "</h4><a href='helpermethodspage.aspx?command=removefromlst&itemcode=" + item.ItemCode + "'><span class='material-icons-outlined'>delete</span></a></div></div>";
                    }
                    cuslistDisplay.InnerHtml = display;
                }
           
            }
     
        }

        protected void CopyToCart_ServerClick(object sender, EventArgs e)
        {
            bool add=false;
            foreach (Item item in client.GetItemsONcustomerList(Session["ID"].ToString()))
            {
                 add = client.AddCartQty(item.ItemCode,Session["ID"].ToString());
            }
            if (add)
            {
                Response.Redirect("cart.aspx");
            }
        }

        protected void clearList_ServerClick(object sender, EventArgs e)
        {
            
            if (client.ClearList(Session["ID"].ToString()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "window.location.href='mylist.aspx';", true);
            }
        }
    }
}
using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class selectproduct : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadItems();
            LoadSeachOptions();
        }
        public void LoadItems()
        {
            string display = "";
            var Items = client.GetItems();
            int promoid = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["promotionId"]));
            display += "<table class='Products'><tr><th>Image</th><th>Name</th><th>Price</th><th>Add/Remove item</th> </tr>";
            if (Session["q"] != null)
            {
                foreach (Item item in Items)
                {
                    if (item.ItemName.ToUpper().Contains(Session["q"].ToString().ToUpper()))
                    {
                        display += "<tr><td><img src='" + item.ItemImageUrl + "' class='imgProduct' alt='img'></td>";
                        display += "<td>" + item.ItemName + "</td><td>R" + item.ItemPrice + "</td>";
                        if (client.getItemOnPromobyCode(item.ItemCode, promoid) != null)
                        {
                            display += "<td><a href='helpermethodspage.aspx?command=RemovefromPromotion&itemcode=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "&promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promoid)) + "'>";
                            display += "<span class='material-icons'>remove</span><span>Remove</span></a></td></tr>";
                        }
                        else if (client.getItemOnPromobyCode(item.ItemCode, promoid) == null)
                        {
                            display += "<td><a href='helpermethodspage.aspx?command=addToPromotion&itemcode=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "&promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promoid)) + "'>";
                            display += "<span class='material-icons'>add</span><span>Add</span></a></td></tr>";
                        }
                    }
                }
                Session.Remove("q");
            }
            else
            {
                foreach (Item item in Items)
                {

                    display += "<tr><td><img src='" + item.ItemImageUrl + "' class='imgProduct' alt='img'></td>";
                    display += "<td>" + item.ItemName + "</td><td>R" + item.ItemPrice + "</td>";
                    if (client.getItemOnPromobyCode(item.ItemCode, promoid) != null)
                    {
                        display += "<td><a href='helpermethodspage.aspx?command=RemovefromPromotion&itemcode=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "&promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promoid)) + "'>";
                        display += "<span class='material-icons'>remove</span><span>Remove</span></a></td></tr>";
                    }
                    else if (client.getItemOnPromobyCode(item.ItemCode, promoid) == null)
                    {
                        display += "<td><a href='helpermethodspage.aspx?command=addToPromotion&itemcode=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "&promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promoid)) + "'>";
                        display += "<span class='material-icons'>add</span><span>Add</span></a></td></tr>";
                    }

                }
            }
            display += "</table>";
            ShowItem.InnerHtml = display;
        }
        private void LoadSeachOptions()
        {
            var items = client.GetItems();
            string display = "";
            foreach (Item item in items)
            {
                display += "<option value='" + item.ItemName + "'></option>";
            }
            searching_auto.InnerHtml = display;
        }
        protected void find_ServerClick(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Session["q"] = searchSomething.Value;
           Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "window.location.href='"+url+"';", true);
        }
    }
}

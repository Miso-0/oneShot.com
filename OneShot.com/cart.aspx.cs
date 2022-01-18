using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class cart : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadCart();
            AddToRecommended();
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
        public void LoadCart()
        {
            string display = "";
            if (Session["ID"] != null)
            {
                string id = Session["ID"].ToString();
                var ITEMS = client.getItemsonCart(id);
                numonCart.InnerText = "" + GetTotalNumOnCart(id);
                foreach (Item item in ITEMS)
                {
                    var it = client.GetItemOnCart(id, item.ItemCode);
                    display += "<div class='each-item-view'><div class='imgView-cart-each'><img src='"+item.ItemImageUrl+"' alt='img'></div>";
                    display += "<div class='namein'><p>"+item.ItemName+"</p></div>";
                    display += "<div class='qty-cony'><a href='helpermethodspage.aspx?command=minusQTY&itemcode=" + item.ItemCode + "' class='btn-add-increment'><span class='material-icons-outlined'>remove</span>";
                    display += "</a><p>"+it.qty+ "</p><a href='helpermethodspage.aspx?command=addtocart&itemcode=" + item.ItemCode + "' class='btn-add-increment'><span class='material-icons-outlined'>add</span></a></div>";
                    display += "<div class='actions-info'><ul><li><h2>R"+Math.Round(it.itemTotalPrice,2)+"</h2></li>";
                    display += "<li><a href='helpermethodspage.aspx?command=removefromCart&itemcode=" + item.ItemCode + "'><span class='material-icons-outlined'>delete</span><span>Remove</span></a>";
                    display += "</li><li><a href='#'><span class='material-icons-outlined'>format_list_bulleted</span>";
                    display += "<span>Add to your list</span></a></li></ul></div></div>";
                }
                double tCart = Math.Round(this.GetTotalCartPrice(id), 2);
                TotalOnCart.InnerText = "R" + tCart;
                double delivaryPrice = 0.00;
                if (tCart>0&&tCart < 250)
                {
                    delivaryPrice = 100.00;
                }
                totalDelivery.InnerText = "R"+Math.Round(delivaryPrice);
                orderTotal.InnerText = "R" +Math.Round((tCart + delivaryPrice),2);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
            itemsDisplay.InnerHtml = display;
       
        }

        public double GetTotalCartPrice(string userid)
        {
            double  totalPrice = 0;
            foreach (onCart item in client.GetOnCart(userid))
            {
                totalPrice +=Convert.ToDouble(item.itemTotalPrice);
            }
            return totalPrice;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                string id = Session["ID"].ToString();
                double tCart = Math.Round(this.GetTotalCartPrice(id), 2);
                double delivaryPrice = 0.00;
                if (tCart > 0 && tCart < 250)
                {
                    delivaryPrice = 100.00;
                }
                Session["delivery"] = Math.Round(delivaryPrice);
                Session["cartTotal"] = tCart;
                Response.Redirect("delivery.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void CopyToCart_ServerClick(object sender, EventArgs e)
        {
            foreach(onCart item in client.GetOnCart(Session["ID"].ToString()))
            {
                bool added = client.addItemOnList(item.ItemCode, Session["ID"].ToString());
            }
        }
            protected void RemoveItemsOnCart_ServerClick(object sender, EventArgs e)
        {
            string id = Session["ID"].ToString();
            if (client.RmoveAllFromCart(id))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "window.location.href='cart.aspx';", true);
            }
         }

        //counts the number of stars a review has and returns a string with stars for each number of stars
        public string CountStars(int stars)
        {
            string starsEle = "";
            for (int i = 1; i <= stars; i++)
            {
                starsEle += "<span class='material-icons'>star_rate</span>";
            }
            return starsEle;
        }

        public double CalculateAverageReview(int id)
        {
         
            int totalStars = 0;
            int totalReviews = 0;
            //calculate the avarage rating stars of each product
            int result = 0;
            var Reviews = client.GetReviews(id);
            foreach (ItemReview review in Reviews)
            {
                totalStars += review.stars;
                totalReviews += 1;
            }
            if (totalReviews != 0)
            {
                result = totalStars / totalReviews;
            }
            return result;
        }

        private void AddToRecommended()
        {
            string display = "";
            Random random = new Random();
            var ItemsList = client.GetItems();
            int randomNum;
            var recommendedList = new List<Item>();
            for (int i = 0; i < 3; i++)
            {
                randomNum = random.Next(0, ItemsList.Count());
                recommendedList.Add(ItemsList.ElementAt(randomNum));
            }
            foreach (Item item in recommendedList)
            {
                ///  if(item.ItemName.Equals(filter)||client.GetCategory())
                display += "<div class='col-item-container'><div class='row-item-container'><div class='sub-row-item-container'>";
                display += "<div class='row-base'><div class='row-top-sec'><div class='row-img-view'>";
                display += "<a href='item.aspx?id=" +QueryStringModule.Encrypt(Convert.ToString(item.ItemCode))+ "'><img src='" + item.ItemImageUrl + "' alt='img'></a></div>";
                display += "<div id='add' class='item-link-cont-circle-a'><a href='helpermethodspage.aspx?command=addtolist&itemcode=" + item.ItemCode + "'><span class='material-icons'>list</span></a>";
                display += "</div></div> <div class='row-item-info'><ul><li><h3>R" + item.ItemPrice + "</h3>";
                display += "</li><li class='name-cont'>" + item.ItemName + " </li><li class='links-list-cont'><div class='item-stars'>";
                display += this.CountStars(Convert.ToInt32(this.CalculateAverageReview(item.ItemCode)));
                display += "</div><div class='item-link-cont-circle-b'>";
                display += "<a href='helpermethodspage.aspx?command=addtocart&itemcode=" + item.ItemCode + "'><span class='material-icons'>add</span></a></div></li></ul></div></div></div></div></div>";

            }
            recommendedItems.InnerHtml = display;
        }

    }
}

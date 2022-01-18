using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class item : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        int countStar = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //  ((index)Master).GetTopSection.Visible = false;
            //    ((index)Master).GetMiddleSec.Visible = false;


            this.LoadItem();
        }
        public void LoadItem()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                //update item information with infor from the database
                string ItemId = QueryStringModule.Decrypt(Request.QueryString["id"]);
                int id = Convert.ToInt32(ItemId);
                var item = client.GetItem(id);
                ItemName.InnerText = item.ItemName;
                ItemPrice.InnerText = "R" + Convert.ToString(item.ItemPrice);
                ItemDescrptionPanel.InnerText = item.ItemDescription;
                itemImage.Src = item.ItemImageUrl;
                //Get reviews for the item shown
                LoadReviews(id);
                this.AddToRecommended();
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }


        }

        public void LoadReviews(int id)
        {
            string display = "";
            var reviews = client.GetReviews(id);
            int nReviews = 0;
            foreach (ItemReview rev in reviews)
            {
                nReviews += 1;
                display += "<div class='eachReview'><div class='reviewUserDet'> <h4>" + rev.UserName + "</h4><h4 style='font-size:13px;margin-top:3px;'>" + rev.ReviewDate.ToString("d") + "</h4></div>";
                display += "<div class='rev'>" + rev.review + "</div>";
                display += "<div class='Stars'>" + CountStars(rev.stars) + "</div></div>";
            }
            numReviews.InnerText = "" + nReviews;
            itemStars.InnerText = "Average reviews (" + this.CalculateAverageReview() + ")";
            Reviews.InnerHtml = display;
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

        public double CalculateAverageReview()
        {
            string ItemId = QueryStringModule.Decrypt(Request.QueryString["id"]);
            int id = Convert.ToInt32(ItemId);
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

        protected void AddReview(object sender, EventArgs e)
        {
            int itemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["id"]));
            if (!string.IsNullOrEmpty(reviewField.Value))
            {
                if (Session["ID"] != null)
                {
                    string userId = Session["ID"].ToString();
                    string date = DateTime.Now.ToString("d");
                    int stars = Convert.ToInt32(starss.Value.ToString());
                    string reveiw = reviewField.Value;
                    if (client.addItemReview(userId, itemCode, reveiw, date, stars))
                    {
                        Response.Redirect("item.aspx");
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                    else
                    {
                        Response.Redirect("item.aspx");
                        Response.Redirect(Request.UrlReferrer.ToString());
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                /*   error.InnerText = "type something on the text area";
                   error.Visible = true;  */
            }
        }

        public void AddToRecommended()
        {
            string display = "";
            Random random = new Random();
   
            string ItemId = QueryStringModule.Decrypt(Request.QueryString["id"]);
            int id = Convert.ToInt32(ItemId);
            var ItemsList = client.GetItems();
            var categorymates = new List<Item>();
            int itemCat = client.GetItem(id).CatID;
            foreach (Item item in ItemsList)
            {
                if (item.CatID.Equals(itemCat))
                {
                    categorymates.Add(item);
                }
            }
            int randomNum ;
            var recommendedList = new List<Item>();
            for (int i =1;i<6;i++)
            {
                 randomNum = random.Next(0, categorymates.Count());
                recommendedList.Add(categorymates.ElementAt(randomNum));
            }
                foreach (Item item in recommendedList)
                 {
                ///  if(item.ItemName.Equals(filter)||client.GetCategory())
                display += "<div class='col-item-container'><div class='row-item-container'><div class='sub-row-item-container'>";
                display += "<div class='row-base'><div class='row-top-sec'><div class='row-img-view'>";
                display += "<a href='item.aspx?id=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "'><img src='" + item.ItemImageUrl + "' alt='img'></a></div>";
                display += "<div id='add' class='item-link-cont-circle-a'><a href='helpermethodspage.aspx?command=addtolist&itemcode=" + item.ItemCode + "'><span class='material-icons'>list</span></a>";
                display += "</div></div> <div class='row-item-info'><ul><li><h3>R" + item.ItemPrice + "</h3>";
                display += "</li><li class='name-cont'>" + item.ItemName + " </li><li class='links-list-cont'><div class='item-stars'>";
                display += this.CountStars(Convert.ToInt32(this.CalculateAverageReview()));
                display += "</div><div class='item-link-cont-circle-b'>";
                display += "<a href='#'><span class='material-icons'>add</span></a></div></li></ul></div></div></div></div></div>";

                }
            recommended.InnerHtml = display;
        }
        protected void AddToCart(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                string userid = Session["ID"].ToString();
                int itemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["id"]));
                int num = Convert.ToInt32(qty.Value);
                if (client.ADDItemWithQTY(itemCode, userid, num))
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "redirect", "window.location.href='item.aspx?id=" + QueryStringModule.Encrypt(itemCode.ToString()) + "';", true);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void AddToList(object sender, EventArgs e)
        {
            int itemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["id"]));
            if (Session["ID"] != null)
            {
                string userId = Session["ID"].ToString();
                if (client.addItemOnList(itemCode, userId))
                {
                    Response.Redirect("item.aspx");
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Redirect("item.aspx");
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
        }     
    }    
}

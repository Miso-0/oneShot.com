using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class index1 : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Visitor"] != null)
            {
                countVisitors();
            }
            LoadPromotions();
            loadAllCatss();
        }

        public void countVisitors()
        {

            Session["Visitor"]  =  "counted";
            string Month = DateTime.Now.ToString("MMM");
            client.AddVisitor(Month);
        }

        /*  "<li style='display: inline-flex;'><h4 style='color: red;margin-right: 10px;'><strike><em>R26,99</em> </strike></h4><h4>R20.99</h4></li>"
                            */

        public void LoadPromotions()
        {
            string display = "";
            var promotions = client.GetPromotions();

            int count  =  0;
            foreach(Promotion promo in promotions)
            {
                if (promo.PromotionStatus.Equals("Active"))
                {
                    display += "<div class='promotion-container-demo'><div class='top-header-each-promo'>";
                    display += "<h4 style='float: left;'>" + promo.Promotion_Name + "</h4><div class='promo-btn'>";
                    display += "<div onclick='showMore(" + count + ")' class='showbtns'>Show all</div></div></div>";
                    display += "<div class='promo-content-each'>";
                    var itemonpromo = client.GetItemsByPromo(promo.Promotion_ID);
                    foreach (Item item in itemonpromo)
                    {
                        double ItemPromoPrice = this.CalcutePromotionDiscount(promo.PromotioPercentageOFF, Convert.ToDouble(item.ItemPrice));
                        double newPrice = Convert.ToDouble(item.ItemPrice) - ItemPromoPrice;
                        display += "<div class='col-item-container'><div class='row-item-container'><div class='sub-row-item-container'>";
                        display += "<div class='row-base'><div class='row-top-sec'><div class='row-img-view'>";
                        display += "<a href='item.aspx?id=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "'><img src='" + item.ItemImageUrl + "' alt='img'></a></div>";
                        display += "<div id='add' class='item-link-cont-circle-a'><a href='helpermethodspage.aspx?command=addtolist&itemcode=" + item.ItemCode + "'><span class='material-icons'>list</span></a>";
                        display += "</div></div> <div class='row-item-info'><ul><li style='display: inline-flex;'><h4 style='color: red;margin-right: 10px;'><strike><em>R" + Math.Round(Convert.ToDouble(item.ItemPrice), 2) + "</em> </strike></h4><h4>R" + Math.Round(newPrice, 2) + "</h4></li>";
                        display += "<li style='margin-bottom:3px;'>save R" + Math.Round(ItemPromoPrice, 2) + " on our " + promo.Promotion_Name + "</li>";
                        display += "<li class='name-cont'>" + item.ItemName + " </li><li class='links-list-cont'><div class='item-stars'>";
                        display += this.CountStars(this.CalculateAverageReview(item.ItemCode));
                        display += "</div><div class='item-link-cont-circle-b'>";
                        display += "<a href='helpermethodspage.aspx?command=addtocart&itemcode=" + item.ItemCode + "'><span class='material-icons'>add</span></a></div></li></ul></div></div></div></div></div>";
                    }
                    display += "</div></div>";
                    count++;
                }
            }
            promotioncontainer.InnerHtml = display;
        }

        private double CalcutePromotionDiscount(int PercentOff,double OriginalPrice)
        {
            double promoPrice = (double)(( OriginalPrice/ 100) * PercentOff);
            return promoPrice;
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

        public int CalculateAverageReview(int itemCode)
        {
            int totalStars = 0;
            int totalReviews = 0;
            //calculate the avarage rating stars of each product
            int result = 0;
            var Reviews = client.GetReviews(itemCode);
            foreach (ItemReview review in Reviews)
            {
                totalStars += review.stars;
                totalReviews += 1;
            }
            if (totalReviews != 0)
            {
                result = Convert.ToInt32(totalStars / totalReviews);
            }
            return result;
        }

        private void loadAllCatss()
        {
            string display = "";
            var list = client.GetCategorynames();
            foreach (string catname in list)
            {
                display += "<a href='Shopall.aspx?filter=true&category=" + catname + "' class='each-category'><span>" + catname + "</span></a>";
            }
            loadAllCats.InnerHtml = display;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        public void SendEmail()
        {
            MailMessage mailMessage = new MailMessage("220034828@student.uj.ac.za", "misomenze6@gmail.com");
            mailMessage.Subject="OneShot.com";
            mailMessage.Body = "This is an email body";

            SmtpClient smtpclient = new SmtpClient("smtp.gmail.com", 587);
            smtpclient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "220034828@student.uj.ac.za",
                Password = "Misomenze@9582"
            };
            smtpclient.EnableSsl = true;
            smtpclient.Send(mailMessage);
        }

        public void LoadPromotionA()
        {
            List<Item> list1 = new List<Item>();
            List<Item> list2 = new List<Item>();
            List<Item> list3 = new List<Item>();
            List<Item> list4 = new List<Item>();
            List<Item> list5 = new List<Item>();
        }

    }
}


/*  <h3 style="color: red;"><strike><em>R26,99</em> </strike></h3>
                           <h4 style="margin-left: 10px;">R26,99</h4>  */

/*   
      
       

    


     */
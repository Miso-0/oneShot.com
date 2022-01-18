using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class promotions : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PromoLoader();
        }

        public void PromoLoader()
        {
            string display = "";
            int count = 1;
            var promotions = client.GetPromotions();
            display += "<table class='admimTable'><tr><th>#No.</th><th>Promotion name</th><th>Start date</th><th>End date</th><th>Status</th><th>Actions</th></tr>";
            foreach (Promotion promo in promotions) {
                display += "<tr><td>#" + count + "</td><td>" + promo.Promotion_Name + "</td><td>" + promo.Promotion_StartDate.ToString("d") + "</td><td>" + promo.Promotion_EndDate.ToString("d") + "</td>";
                if (promo.PromotionStatus.Equals("Active"))
                {
                    display += "<td> <a style='text-decoration: none;' href='helpermethodspage.aspx?command=editInActivePromo&promoID=" + promo.Promotion_ID+ "'><span class='material-icons-outlined'>toggle_on</span></a></td>";
                }
                else
                {
                    display += "<td><a style='text-decoration: none;' href='helpermethodspage.aspx?command=editActivePromo&promoID=" + promo.Promotion_ID + "'><span style='color: red;' class='material-icons-outlined'>toggle_off</span></a></td>";
                }
                display += "<td><a href='selectproduct.aspx?promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promo.Promotion_ID))+"'><span class='material-icons'>edit</span></a>";
                display += "<a style='margin-left:10px;' href='helpermethodspage.aspx?command=deletePromo&promotionId=" + QueryStringModule.Encrypt(Convert.ToString(promo.Promotion_ID)) + "'><span class='material-icons-outlined'>delete</span></a></td></tr>";
                count ++;
            }
            display += "</table>";
            promoLoader.InnerHtml = display;
        }
        
    }
}

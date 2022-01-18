using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class newpromotion : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddPromotion(object sender, EventArgs e)
        {
             string  promoName =promotionName.Value;
            string description = promDescription.Value;
            string stDate = promStDate.Value;
            string endDate = promEDDate.Value;
            int pOff = Convert.ToInt32(percentageOff.Value);
            string status = "";
            string currentDate = DateTime.Now.ToString("d");

            if (Convert.ToDateTime(stDate).CompareTo(Convert.ToDateTime(currentDate)) > 0){
                  status = "Not Active";
            }
            else if(Convert.ToDateTime(stDate).CompareTo(Convert.ToDateTime(currentDate))<0)
            {
                status = "Active";
            }
            else if (Convert.ToDateTime(stDate).CompareTo(Convert.ToDateTime(currentDate)) == 0)
            {
                status = "Active";
            }

            if (client.AddPromotion(promoName, description, stDate, endDate, status,pOff)){
                int id = client.GetPromotionByName(promoName).Promotion_ID;
                Response.Redirect("selectproduct.aspx?promotionId="+QueryStringModule.Encrypt(Convert.ToString(id)));
            }
        }
     }
}
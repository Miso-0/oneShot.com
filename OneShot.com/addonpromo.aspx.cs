using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class addonpromo : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ItemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            int PromotionCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["promotionId"]));
            if (client.AddItemOnPromotion(ItemCode, PromotionCode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}
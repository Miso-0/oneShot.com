using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class helpermethodspage : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

            string command = Request.QueryString["command"];
            switch (command)
            {
                case "userdelete":
                    break;
                case "addtocart":
                    this.AddToCart();
                    break;
                case "addtolist":
                    this.AddItemToList();
                    break;
                case "minusQTY":
                    this.MinusQty();
                    break;
                case "removefromCart":
                    this.RemoveFromCart();
                    break;
                case "removefromlst":
                    this.DeleFromList();
                    break;
                case "removeallcart":
                    break;
                case "removealllist":
                    break;
                case "addToPromotion":
                    this.AddItemToPromo();
                    break;
                case "deleItemFromDataBase":
                    this.DeleteItemFromDataBase();
                    break;
                case "editActivePromo":
                    this.EditPromoStatus("Active");
                    break;
                case "editInActivePromo":
                    this.EditPromoStatus("inActive");
                    break;
                case "RemovefromPromotion":
                    this.RemoveFromPromo();
                    break;
                case "deletePromo":
                    deletePromo();
                    break;
            }
        }
        private void deletePromo()
        {
            int PromotionCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["promotionId"]));
            if (client.DeletePromotion(PromotionCode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        private void RemoveFromPromo()
        {
            int ItemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            int PromotionCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["promotionId"]));

            if (client.removeFromPromo(ItemCode, PromotionCode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
         private void EditPromoStatus(string status)
        {
            int promoID = Convert.ToInt32(Request.QueryString["promoID"]);
            if (client.EditPromoStatus(promoID, status))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        private void DeleteItemFromDataBase()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            if (client.deleteItemFromDB(Itemcode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }

        public void AddToCart()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            if (Session["ID"] != null)
            {
                string userID = Session["ID"].ToString();
                if (client.AddCartQty(Itemcode, userID))
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public void MinusQty()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
                string userID = Session["ID"].ToString();
                if (client.MinuesCartQty(Itemcode, userID))
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
        }

        public void RemoveFromCart()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            string userID = Session["ID"].ToString();
            if (client.DeleteItem(Itemcode, userID))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }

        public void AddItemToList()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            if (Session["ID"] != null)
            {
                string id = Session["ID"].ToString();
                if (client.addItemOnList(Itemcode, id))
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        public void DeleFromList()
        {
            int Itemcode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            string id = Session["ID"].ToString();
            if (client.DeletItemONList(id,Itemcode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
        public void AddItemToPromo()
        {
            int ItemCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["itemcode"]));
            int PromotionCode = Convert.ToInt32(QueryStringModule.Decrypt(Request.QueryString["promotionId"]));
            if (client.AddItemOnPromotion(ItemCode, PromotionCode))
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }
    }
}
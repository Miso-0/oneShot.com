using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HashPass;
namespace OneShot.com
{

    
    public partial class Login : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            ((index)Master).GetFooter.Visible = false;
            ((index)Master).GetTopHeader.Visible = false;
            ((index)Master).GetMiddleHeader.Visible = false;
            error.Visible = false;

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (client.Login(emailaddress.Value, Secrecy.HashPassword(userPassword.Value)) != null)
            {
                var user = client.Login(emailaddress.Value, Secrecy.HashPassword(userPassword.Value));
                Session["Usertype"] = user.UserType;
                Session["UserName"] = user.FiratName;
                Session["ID"] = user.UserID;
                Session["City"] = user.UserCity;
                if (((index)Master).CookiesAllowed())
                {
                    saveCookies(QueryStringModule.Encrypt(user.UserID), user.FiratName, user.UserType);
                }
                Response.Redirect("index.aspx");
            }
            else
            {
                error.InnerText = "Incorrect Email address or password";
                error.Visible = true;
            }
        }
        public void saveCookies(string id,string username,string type)
        {
            HttpCookie cookie = new HttpCookie("Login");
            cookie["id"] = id;
            cookie["username"]=username;
            cookie["usertype"] = type;
            cookie.Expires =  DateTime.Now.AddDays(30);

            Response.Cookies.Add(cookie);
        }
    }
}
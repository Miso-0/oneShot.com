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
    public partial class index : System.Web.UI.MasterPage
    {
        OneShotServiceClient client = new OneShotServiceClient();
        private bool cookieChoice;
        protected void Page_Load(object sender, EventArgs e)
        {

            
            this.Loadfilter();
            this.LoadSeachOptions();
            cookieChoice = false;
            searchiteminput.Value = "";
            error.Visible = false;
            admindashboard.Visible = false;
            signin.Visible = true;
            myprofile.Visible = false;
            userC.Visible = false;
            int count = 0;

            HttpCookie permisssionCookie = Request.Cookies["policy"];
            if (permisssionCookie != null)
            {
                cookiePolicy.Visible = false;
                cookieChoice = true;
                HttpCookie cookie = Request.Cookies["Login"];
                if (cookie != null)
                {
                    Session["Usertype"] = cookie["usertype"];
                    Session["UserName"] = cookie["username"];
                    Session["ID"] = cookie["id"];
                }
            }
            else
            {
                cookieChoice = false;
                cookiePolicy.Visible = true;
            }
            numItemsOnCart.InnerText = "" + count;
            if (Session["Usertype"] != null )
                {

                    myprofile.Visible = true;
                    signin.Visible = false;
                    userCity.InnerText = client.GetUser(Session["ID"].ToString()).UserCity;
                    userC.Visible = true;
                    usernameup.InnerText = Session["UserName"].ToString();
                     numItemsOnCart.InnerText = "" + this.GetTotalNumOnCart(Session["ID"].ToString());
                    if (Session["Usertype"].ToString().Equals("Manager"))
                    {
                        admindashboard.Visible = true;
                        cusSupport.Visible = false;
                        services.Visible = false;
                    myaccount.Visible = false;
                    mylist.Visible = false;
                    myoders.Visible = false;
                    mycart.Visible = false;
                   
                    }
                }
        }

        public int GetTotalNumOnCart(string userid)
        {
            int count = 0;
            foreach(onCart item in client.GetOnCart(userid))
            {
                count+=item.qty;
            }
            return count;
        }

        private void LoadSeachOptions()
        {
           var items = client.GetItems();
     //      var categories = client.GetCategorynames();
            string display = "";
             foreach(Item item in items) { 
                display += "<option value='"+item.ItemName+"'></option>";
            
            }
          /*   foreach(string category in categories)
            {
                display += "<option value='" + category + "'></option>";
            }*/
            searching_auto.InnerHtml = display;
        }

        protected void CookieAccept(object sender, EventArgs e)
        {
            this.SaveCookiePolicy("true");
            cookiePolicy.Visible = false;
        }

        protected void CookieDecline(object sender, EventArgs e)
        {
            cookieChoice = false;
            cookiePolicy.Visible = false;
        }

        protected void OrdersClick(object sender, EventArgs e)
        {
            Response.Redirect("MyOrders.aspx");
        }

        protected void SupportClick(object sender, EventArgs e)
        {
            Response.Redirect("Customersupport.aspx");
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.RemoveAll();
            HttpCookie cookie = Request.Cookies["Login"];
            if (cookie!= null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("index.aspx");
        }

        protected void btn_sign_in(object sender, EventArgs e)
        {
            if (client.Login(emailaddress.Value, Secrecy.HashPassword(userPassword.Value)) != null)
            {
                var user = client.Login(emailaddress.Value, Secrecy.HashPassword(userPassword.Value));
                Session["Usertype"] = user.UserType;
                Session["UserName"] = user.FiratName;
                Session["ID"] = user.UserID;
                Session["City"] = user.UserCity;
                if (cookieChoice)
                {
                    SaveCookies(user.UserID, user.FiratName, user.UserType);
                }
                Response.Redirect("index.aspx");
            }
            else
            {

                error.InnerText = "Incorrect Email address or password";
                error.Visible = true;
            }
        }
        public bool CookiesAllowed()
        {
            return cookieChoice;
        }
        public void SaveCookies(string id, string username, string type)
        {
            HttpCookie cookie = new HttpCookie("Login");
            cookie["id"] = id;
            cookie["username"] = username;
            cookie["usertype"] = type;
            cookie.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(cookie);
        }
        public void SaveCookiePolicy(string choice)
        {
            HttpCookie policyCookie = new HttpCookie("policy");
            policyCookie["Decision"] = choice;
            cookieChoice = true;
            policyCookie.Expires = DateTime.Now.AddDays(60);
            Response.Cookies.Add(policyCookie);
        }

        public dynamic GetFooter
        {
            get
            {
                return footer;
            }
        }

        public dynamic GetTopHeader
        {
            get
            {
                return top_header;
            }
        }

        public dynamic GetMiddleHeader
        {
            get
            {
                return middle_header;
            }
        }
        public dynamic GetMainHeader
        {
            get
            {
                return mainheader;
            }
        }

        public void Loadfilter()
        {
            string display = "";
            var list = client.GetCategorynames();
            foreach (string catname in list)
            {
                display += "<li><a href='Shopall.aspx?filter=true&category=" + catname + "'>" + catname + "</a></li>";
            }
            loadDropDown.InnerHtml = display;
        }

       protected void btn_Search(object sender, EventArgs e)
        {
            string question = Text1.Value.ToString();
            Response.Redirect("Shopall.aspx?q="+question);
        }
    }
}
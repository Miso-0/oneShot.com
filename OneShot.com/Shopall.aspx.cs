using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class Shopall : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            //     filtersSelected.Visible = false;
            filtersSelected.Visible = false;
            this.HandlerLoader();
            this.Loadfilter();
          
        }

        private void HandlerLoader()
        {
            if (Request.QueryString["filter"] != null)
            {
                if (Request.QueryString["category"] != null)
                {
                    string catName = Request.QueryString["category"];
                    foreach (Item item in this.GetSelectedItemsCategory(catName))
                    {
                        helperClass.AddOnList(item);
                    }
                }
                if (Request.QueryString["min"] != null&&Request.QueryString["max"] != null)
                {
                    double max = Convert.ToDouble(Request.QueryString["max"]);
                    double min = Convert.ToDouble(Request.QueryString["min"]);
                    foreach (Item item in this.GetItemsPriceRange(min,max))
                    {
                        helperClass.AddOnList(item);
                    }
                }
                if (Request.QueryString["promoID"] != null)
                {
                    int promoID = Convert.ToInt32(Request.QueryString["promoID"]);
                    foreach (Item item in this.GetItemsOnSelectedPromotion(promoID))
                    {
                        helperClass.AddOnList(item);
                    }
                }
        
                this.LoadDisplayer(helperClass.getFilteredList());
                string display = "";
                foreach(string f in helperClass.getFilters())
                {
                    display += "<li class='filtes-selected' style='font-size:13px;color:rgb(0, 175, 58);'>" + f+"</li>";
                }
               
                selectedFiltersShow.InnerHtml = display;
                filtersSelected.Visible = true;
                if (helperClass.getFilteredList().Count == 0)
                {
                    filtersSelected.Visible = false;
                }
            }else if (Request.QueryString["q"] != null)
            {
                string find = Request.QueryString["q"];
                this.LoadDisplayer(this.FindItems(find));
            }
            else
            {
                var allItems = client.GetItems();
                List<Item> items = new List<Item>();
                foreach(Item item in allItems)
                {
                    items.Add(item);
                }
                helperClass.getFilteredList().Clear();
                this.LoadDisplayer(items);
            }

        }

        private List<Item> GetFiltered(List<Item> itemsList)
        {
            List<Item> newList = null;
            if (helperClass.order.Equals("all"))
            {
                selectedOrder.InnerText = "Sort by";
                newList = itemsList.ToList();
            }else   if (helperClass.order.Equals("az"))
            {
                selectedOrder.InnerText = "Name A-Z";
                newList = (from item in itemsList orderby item.ItemName ascending select item).ToList();

            }
            else if (helperClass.order.Equals("za"))
            {
                selectedOrder.InnerText = "Name Z-A";
                newList = (from item in itemsList orderby item.ItemName descending select item).ToList();
            }
            else if (helperClass.order.Equals("lh"))
            {
                selectedOrder.InnerText = "Price Low-High";
                newList = (from item in itemsList orderby item.ItemPrice ascending select item).ToList();
            }
            else if (helperClass.order.Equals("hl"))
            {
                selectedOrder.InnerText = "Price High-Low";
                newList = (from item in itemsList orderby item.ItemPrice descending select item).ToList();
            }
            return newList;
        }

        private void LoadDisplayer(List<Item> itemsList)
        {
            string display = "";
            List<Item> orderedList = this.GetFiltered(itemsList);


            List<Item> FinalList = new List<Item>();
            if (Session["Num"] != null)
            {
                helperClass.numberToShow = Convert.ToInt32(Session["Num"].ToString());
            }

            if (helperClass.numberToShow == client.GetItems().Count())
            {
                numberShowing.InnerText = "All";
            }
            else
            {
                numberShowing.InnerText = "1-" + helperClass.numberToShow;
            }

            if (orderedList.Count() < helperClass.numberToShow)
            {
                for (int i = 0; i < orderedList.Count(); i++)
                {
                    FinalList.Add(orderedList.ElementAt(i));
                }
            }
            else
            {
                for (int i = 0; i < helperClass.numberToShow; i++)
                {
                    FinalList.Add(orderedList.ElementAt(i));
                }
            }
           

            if (FinalList != null)
            {
                foreach (Item item in FinalList)
                {
                    display += "<div class='col-item-container'><div class='row-item-container'><div class='sub-row-item-container'>";
                    display += "<div class='row-base'><div class='row-top-sec'><div class='row-img-view'>";
                    display += "<a href='item.aspx?id=" + QueryStringModule.Encrypt(Convert.ToString(item.ItemCode)) + "'><img src='" + item.ItemImageUrl + "' alt='img'></a></div>";
                    display += "<div id='add' class='item-link-cont-circle-a'><a href='helpermethodspage.aspx?command=addtolist&itemcode=" + item.ItemCode +"'><span class='material-icons'>list</span></a>";
                    display += "</div></div> <div class='row-item-info'><ul><li><h3>R" + item.ItemPrice + "</h3>";
                    display += "</li><li class='name-cont'>" + item.ItemName + " </li><li class='links-list-cont'><div class='item-stars'>";
                    display += this.CountStars(this.CalculateAverageReview(item.ItemCode));
                    display += "</div><div class='item-link-cont-circle-b'>";
                    display += "<a href='helpermethodspage.aspx?command=addtocart&itemcode=" + item.ItemCode + "'><span class='material-icons'>add</span></a></div></li></ul></div></div></div></div></div>";
                }
            }
            MainDisplay.InnerHtml = display;
        }
       

        private List<Item> FindItems(string q)
        {
            var items = new List<Item>();
            var list = client.GetItems();
            foreach(Item item in list)
            {
                if (item.ItemName.Contains(q)||item.ItemDescription.Contains(q))
                {
                    items.Add(item);
                }
            }
            return items;
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
            foreach (ItemReview review in Reviews){
                totalStars += review.stars;
                totalReviews += 1;
            }
            if (totalReviews != 0)
            {
                 result = Convert.ToInt32(totalStars / totalReviews);
            }
            return result;
        }

        public void Loadfilter()
        {
            string display  =  "";
            var list = client.GetCategorynames();
            foreach  (string catname in list)
            {
               display += "<li><a href='Shopall.aspx?filter=true&category="+catname+"'>" + catname+"</a></li>";
            }
            var promos = client.GetPromotions();
            string displayPromos = "";
            foreach(Promotion promoName in promos)
            {
                displayPromos += "<li><a href='Shopall.aspx?filter=true&promoID=" + promoName.Promotion_ID+ "&promoxd=" + promoName.Promotion_Name + "'>" + promoName.Promotion_Name+"</a></li>";
            }
            promoFilter.InnerHtml = displayPromos;
            categories.InnerHtml = display;
        }
        protected void removeAll(object sender, EventArgs e)
        {
            helperClass.getFilteredList().Clear();
            helperClass.getFilters().Clear();
            filtersSelected.Visible = false;
            Response.Redirect("Shopall.aspx");
        }
          private List<Item> GetSelectedItemsCategory(string catogory)
        {
            helperClass.Addfilter(catogory);
            var items = new List<Item>();
            var Allitems = client.GetItems();
            foreach(Item item in Allitems)
            {
                int catId = client.GetCategory(catogory).CatID;
                if (item.CatID.Equals(catId))
                {
                    items.Add(item);
                }
            }
            return items;
        }

        private List<Item> GetItemsPriceRange(double min,double max)
        {
            string filterName = "R" + min + ".99 - R" + max+".99";
            helperClass.Addfilter(filterName);
            var items = new List<Item>();
            var Allitems = client.GetItems();
            foreach (Item item in Allitems)
            {
                double itemPrice =Convert.ToDouble(item.ItemPrice);
                if(itemPrice>=min && itemPrice <= max) { 
                    items.Add(item);
                }
            }
            return items;
        }
        private List<Item> GetItemsOnSelectedPromotion(int id)
        {
            helperClass.Addfilter(Request.QueryString["promoxd"]);
            var items = new List<Item>();
            var onPromo = client.GetItemsByPromo(id);
            foreach (Item item in onPromo)
            {
                   items.Add(item);
            }
            return items;
        }

        protected void btnSortRemove_ServerClick(object sender, EventArgs e)
        {
            helperClass.order = "all";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }

        protected void btnSortAZ_ServerClick(object sender, EventArgs e)
        {
            helperClass.order = "az";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }

        protected void btnSortZA_ServerClick(object sender, EventArgs e)
        {
            helperClass.order = "za";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }

        protected void btnSortHL_ServerClick(object sender, EventArgs e)
        {
            helperClass.order = "hl";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }

        protected void btnSortLH_ServerClick(object sender, EventArgs e)
        {
            helperClass.order = "lh";
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }

        protected void btn16_ServerClick(object sender, EventArgs e)
        {
            Session["Num"]=16;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }
        protected void btn32_ServerClick(object sender, EventArgs e)
        {
            Session["Num"] = 32;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }
        protected void btn64_ServerClick(object sender, EventArgs e)
        {
            Session["Num"] = 64;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }
        protected void btnall_ServerClick(object sender, EventArgs e)
        {
            Session["Num"] = client.GetItems().Count();
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            Response.Redirect(url);
        }
    }
}
/*display += "<span class='material-icons'>star_rate</span><span class='material-icons'>star_rate</span><span class='material-icons'>star_rate</span>";
display += "<span class='material-icons'>star_rate</span><span class='material-icons'>star_rate</span>";*/
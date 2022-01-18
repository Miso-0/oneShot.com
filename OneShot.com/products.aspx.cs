using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class products : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadProducts();
        }
        private void LoadProducts()
        {
            string display = "";
            var items = client.GetItems();
            int count = 1;
            display += "<table class='admimTable'><tr><th>#No.</th><th>Name</th><th>Image</th><th>Price</th><th>Availablity</th><th>Actions</th></tr>";
            foreach (Item item in items)
            {
                display += "<tr><td>#"+count+"</td><td>"+item.ItemName+"</td><td><img class='productImg' src='"+item.ItemImageUrl+"' alt='img'>";
                display += "</td><td>R"+item.ItemPrice+"</td><td>"+this.CalculateAvailability(item.ItemAvailableQTY,item.ItemQuantity) + "</td><td>";
                display += "<a href='#'> <span class='material-icons'>edit</span></a><a href='helpermethodspage.aspx?command=deleItemFromDataBase&itemcode=" + item.ItemCode + "'><span class='material-icons'>delete_outline</span></a></td></tr>";
                count++;
            }
            display += "</table>";
            products_Display.InnerHtml = display;
        }

        public string CalculateAvailability(int availableQty,int StockQty)
        {
            string display;
            double  calc=(double) availableQty /StockQty;
            double t = calc * 100;
          //  display =""+t;
        if ( t < 35)
            {
                display = "<span style='color: red;' class='material-icons'>fiber_manual_record</span>";
            }else if( t>=35 &&  t < 49)
            {
                display = "<span style='color: yellow;' class='material-icons'>fiber_manual_record</span>";
            }
            else
            {
                display = "<span class='material-icons'>fiber_manual_record</span>";
            } 
            return display;
        }
    }
}


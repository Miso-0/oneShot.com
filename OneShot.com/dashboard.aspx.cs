using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class dashboard : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadDashBoard();
            this.LoadEmployees();
            this.LoadStatsSummarry();
        }
        public void LoadDashBoard()
        {
            string LineGraphDisplay = "";
            var lineGDatalist = client.GetLineGraphData();
            foreach (LineGraphData lineG in lineGDatalist)
            {
                LineGraphDisplay += "<p class='dataLine'>" + lineG.Mon + "</p> <p class='dataLine'>" + lineG.RevenuAmount + "</p> <p class='dataLine'>" + lineG.ExpenseAmount + "</p>";
            }
            LineGraphLoader.InnerHtml = LineGraphDisplay;

            string columnGraphDisplay = "";
            var ColumnGraphList = client.GetColumnGraphData();
            foreach (ColumnGraphData cd in ColumnGraphList)
            {
                columnGraphDisplay += "<p class='dataLine2'>" + cd.Mon + "</p> <p class='dataLine2'>" + cd.Visitors + "</p><p class='dataLine2'>" + cd.Registered + "</p><p class='dataLine2'>" + cd.Ordered + "</p>";
            }
            ColumnGraphDateLoader.InnerHtml = columnGraphDisplay;
        }
        public void LoadStatsSummarry()
        {
            var lineGDatalist = client.GetLineGraphData();
            double TotalRevene=0;
            foreach (LineGraphData lineG in lineGDatalist)
            {
                TotalRevene += Convert.ToDouble(lineG.RevenuAmount);
            }

            int count = 0;
             foreach(User user in client.GetUsers())
            {
                if (user.UserType.Equals("Customer"))
                {
                    count++;
                }
            }
             
            totalSales.InnerText =""+ this.ShortenNumbers(client.GetTransactions().Count());
            totalCustomers.InnerText = "" + this.ShortenNumbers(count);
            totalProducts.InnerText = "" + this.ShortenNumbers(client.GetItems().Count());
            TRevenue.InnerText = "R" + this.ShortenNumbers(TotalRevene);
        }
        private void LoadEmployees()
        {
            string display = "";
            var users = client.GetUsers();
            int count = 1;
            display += "<table class='employesstbl'><tr><th>#No.</th><th>Fullname</th><th>Email Address</th><th>Employee type</th></tr>";
            foreach (User user in users)
            {
                if (user.UserType.Equals("Manager"))
                {
                    display += "<tr><td>#"+count+"</td><td>"+user.FiratName+" "+user.LastName+"</td><td>"+user.UserEmail+"</td><td>"+user.UserType+"</td></tr>";
                    count++;
                }
            }
            display += "</table>";
            employees.InnerHtml = display;
        }

        public string ShortenNumbers(double number)
        {
            string shortened = "";
            if (number < 1000)
            {
                shortened = ""+number;
            }else if(number>=1000 && number < 10000)
            {
                string strnumber = ("" + number).Substring(0, 1);
                shortened = strnumber+"k";
            }else if(number>=10000 && number < 100000)
            {
                string strnumber = ("" + number).Substring(0, 2);
                shortened = strnumber+"k";
            }else if (number >= 100000 && number < 1000000)
            {
                string strnumber = ("" + number).Substring(0, 3);
                shortened = strnumber + "k";
            }
            return shortened;
        }
    }

}

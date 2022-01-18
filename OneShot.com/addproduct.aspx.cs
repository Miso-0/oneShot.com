using OneShot.com.ServiceReference1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OneShot.com
{
    public partial class addproduct : System.Web.UI.Page
    {
        OneShotServiceClient client = new OneShotServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            imageView.Visible = false;
            addError.Visible = false;
            this.LoadCategoryOptions();
        }

        private void LoadCategoryOptions()
        {
            var catNames = client.GetCategorynames();
            Category.Items.Add(new ListItem("Category", "Default"));
            foreach (string cat in catNames)
            {
                Category.Items.Add(new ListItem(cat, cat));
            }
        }

        //Adds products to the databese
        protected void AddProduct(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(ProductName.Value)&&
                !string.IsNullOrEmpty(productDescription.Value)&&
                !string.IsNullOrEmpty(ProductPrice.Value)&&
                !string.IsNullOrEmpty(qty.Value)&& !Category.Value.Equals("Default"))
            {
                string Name = ProductName.Value;
                string description = productDescription.Value;
                double price = Convert.ToDouble(ProductPrice.Value.ToString())+0.99;
                int quantity = Convert.ToInt32(qty.Value.ToString());
                string categoryname = Category.Value.ToString();
                if (client.AddItem(Name, price, categoryname, description, quantity, this.previewImageLoaded()))
                {
                    addError.InnerText = "Product added";
                    addError.Attributes.CssStyle.Add(HtmlTextWriterStyle.Color, " rgb(0, 175, 58)");
                    addError.Visible = true;
                    ProductName.Value = "";
                    ProductPrice.Value = "";
                    productDescription.Value = "";
                    qty.Value = "";
                   
                    imageView.Visible = false;
                    labell.Visible = true;
                }
                else
                {
                    addError.InnerText = "Something went wrong";
                    addError.Visible = true;
                }
            }
            else
            {
                addError.InnerText = "File in the missing inforamtion";
                addError.Visible = true;
            }
                        
        }

        protected void PreViewImage(object sender, EventArgs e)
        {
            this.previewImageLoaded();

        }
        //Processes an image that is  loaded and displays it on the display elements
        public string previewImageLoaded()
        {
            string path = "";
            if (ProductImageUpload.HasFile)
            {
                path = "ItemImages/" + ProductImageUpload.FileName;
                FileInfo file = new FileInfo(path);
                string extension = file.Extension;
                if (extension.Equals(".jpg") || extension.Equals(".png"))
                {     
                    ProductImageUpload.SaveAs(Server.MapPath(path));
                    imageView.Src = path;
                    imageView.Visible = true;
                    labell.Visible = false;
                }
                else
                {
                    addError.InnerText = "Image not supported";
                    addError.Visible = true;
                }
            }
            else
            {
                addError.InnerText = "No image selected";
                addError.Visible = true;
            }
            return path;
        }
    }
}
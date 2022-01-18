<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="OneShot.com.addproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Add new product</title>
    <link rel="shortcut icon" type="image" href="images/logoshortcut-removebg-preview.png">
    <link rel="stylesheet" href="css/oneshot.css">
    <link rel="stylesheet" href="css/oneShotResponsive.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Roboto:wght@100;300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="css/oneshott.css">

</head>
<body>
    <form id="form1" runat="server">
        <div class="mainAddProduct">
        <div class="headN">
            <a onclick="goBack()" href="products.aspx">
                <span style="font-size: 18px; margin-top: 4px;margin-right: 5px;" class="material-icons">arrow_back</span>
                <h4>Open product manager</h4>
            </a>
        </div>
        <div class="MainBBb">
            <div class="Inputssa">
                <h4>Fill in the product information</h4>
                <input runat="server" class="ProductInfo" id="ProductName" type="text" placeholder="Name"/>
                <br/>
                <textarea runat="server"  name="Description" class="Description" id="productDescription" cols="30" rows="10" placeholder="Descibe the Product"></textarea><br/>
                <select  runat="server"  name="Category" class="Category" id="Category">

                </select>
                 <input runat="server"  class="ProductInfo" id="ProductPrice" placeholder="Price" type="text" /><br/>
                <input runat="server"  class="ProductInfo" id="qty" placeholder="Quantity" type="text"/><br/>
            </div>
            <div class="imageInputs">
                <p id="labell" runat="server">Image review</p>
               <img class="imgVvv" id="imageView" runat="server" src=""  alt="img"/>
            </div>
            <asp:FileUpload ID="ProductImageUpload" class="fileUploader"  runat="server" /><br/>
             <button class="btnAddProduct" runat="server" onserverclick="PreViewImage">Preview Image</button>
            <button class="btnAddProduct1" runat="server" onserverclick="AddProduct">Add product</button><br />
              <p style="color:red; float:left;margin-left:10%;margin-top:10px;" runat="server" id="addError"></p>
        </div>
          
    </div>
    </form>
</body>
    <script>
        function goBack() {
            window.history.back();
            window.location.replace('url');
        }
    </script>
</html>

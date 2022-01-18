<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newpromotion.aspx.cs" Inherits="OneShot.com.newpromotion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New promotion</title>
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
            <a href="promotions.aspx">
                <span style="font-size: 18px; margin-top: 4px;margin-right: 5px;" class="material-icons">arrow_back</span>
                <h4>Open promotion manager</h4>
            </a>
        </div>
        <div class="MainBBb">
            <div class="Inputssa">
                <h4>Fill in the product information</h4>
                <input required="required" runat="server" class="ProductInfo" id="promotionName" type="text" placeholder="Promotion name"><br>
                 <input required="required" runat="server" class="ProductInfo" id="percentageOff" type="text" placeholder="Price percentage off"><br>
                <label style="float: left; margin-left: 14%;" for="promStDate">Start date</label><br>
                <input required="required" runat="server"  class="ProductInfo" id="promStDate" type="date"><br>
                <label style="float: left; margin-left: 14%;" for="promEDDate">End date</label><br>
                <input required="required" runat="server"  class="ProductInfo" id="promEDDate" type="date"><br>
                <button class="btnAddProduct" style="float:left;margin-left: 14%;" runat="server" onserverclick="AddPromotion">Procced</button>
            </div>
            <div style="height: auto;" class="imageInputs">
                <textarea required="required" name="Description" class="Description" id="promDescription" cols="30" runat="server"  rows="10" placeholder="Describe the promotion"></textarea>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

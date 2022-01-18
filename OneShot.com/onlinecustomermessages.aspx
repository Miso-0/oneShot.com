<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="onlinecustomermessages.aspx.cs" Inherits="OneShot.com.onlinecustomermessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>OneShot.com</title>
    <link rel="shortcut icon" type="image" href="images/logoshortcut-removebg-preview.png">
    <link rel="stylesheet" href="css/oneshot.css">
    <link rel="stylesheet" href="css/oneShotResponsive.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Roboto:wght@100;300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
     <link href="https://fonts.googleapis.com/icon?family=Material+Icons+Outlined" rel="stylesheet">
    <link rel="stylesheet" href="css/oneshott.css">
     <link rel="stylesheet" href="css/onshopbootstrap.css">
      <link rel="stylesheet" href="css/oneshotB.css">
    <link rel="stylesheet" href="/css/oneshot_c_.css">
    <link rel="stylesheet" href="/css/oneshot_a_.css">
        <style>
        .BottomSectionInputAndButtons .UserInputSupport{
            padding-left:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="customer-support-container">


        <div class="MainAdminDisplay">
            <div class="TopAdminHeader">
                <div class="topLogo">
                    <a id="homeLogo" href="Home.html">
                        <p style="color: white; font-weight: bold;"><span style="background-color: white; color: rgb(0, 175, 58); border-radius: 5px;">One</span>Shot.com</span>
                        </p>
                    </a>
                </div>
                <!-- <div style="display: none;" class="searchBarbase">
                    <input type="search" class="searchInput" placeholder="Promotion name" id="searchSomething">
                    <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
                </div>
                <a href="#"> <span class="material-icons">notifications</span></a>
                <a href="#"><span class="material-icons">email</span></a> -->
            </div>
            <div class="sideNav">

                <ul>
                    <li>
                    <a href="dashboard.aspx">
                        <span class="material-icons">dashboard</span>
                        <span class="names">Dashboard</span>
                    </a>
                </li>
                <li>
                    <a href="users.aspx">
                        <span class="material-icons">manage_accounts</span>
                        <span class="names">Users</span>
                    </a>
                </li>
                <li>
                    <a href="orders.aspx">
                        <span class="material-icons">grading</span>
                        <span class="names">Orders</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="material-icons">ad_units</span>
                        <span class="names">Banners</span>
                    </a>
                </li>
                <li>
                    <a href="products.aspx">
                        <span class="material-icons">precision_manufacturing</span>
                        <span class="names">Products</span>
                    </a>
                </li>
                <li>
                    <a href="promotions.aspx">
                        <span class="material-icons">auto_awesome</span>
                        <span class="names">Promotions</span>
                    </a>
                </li>
                <li>
                    <a href="onlinesupport.aspx">
                        <span class="material-icons">support_agent</span>
                        <span class="names">Customer support</span>
                    </a>
                </li>

                <li>
                    <a href="transactions.aspx">
                        <span class="material-icons">receipt_long</span>
                        <span class="names">Transactions</span>
                    </a>
                </li>
                <li>
                    <a href="index.aspx">
                        <span class="material-icons">layers</span>
                        <span class="names">Open website</span>
                    </a>
                </li>
                </ul>
            </div>

            <div class="more-messages-displayer">
                <ul runat="server" id="sidenavViewer">
       

                </ul>
            </div>
       <div class="main-content-customer-support">

                <div runat="server" id="messages" class="MessageSection">
               

                </div>
                <div class="BottomSectionInputAndButtons">
                    <input id="UserInputSupport" runat="server" placeholder="Say something" class="UserInputSupport" type="email">
                    <button id="btnsend" runat="server" onserverclick="btnsend_ServerClick" class="btnsend">Send</button>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

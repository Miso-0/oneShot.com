<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="selectproduct.aspx.cs" Inherits="OneShot.com.selectproduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Add products to promotion</title>
    <link rel="shortcut icon" type="image" href="images/logoshortcut-removebg-preview.png">
    <link rel="stylesheet" href="css/oneshot.css">
    <link rel="stylesheet" href="css/oneShotResponsive.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Roboto:wght@100;300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
    <link rel="stylesheet" href="css/oneshott.css">
         <link rel="stylesheet" href="css/onshopbootstrap.css">


    <style>
        .searchBarbase .searchInput{
            color:white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="mainAddProduct">
        <div class="headN">
            <a href="promotions.aspx">
                  <span style="font-size: 18px; margin-top: 4px;margin-right: 5px;" class="material-icons">done</span>
                <h4>Done</h4>

            </a>
             <div  class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Find an Item" list="searching_auto" runat="server" id="searchSomething">
                <button runat="server" onserverclick="find_ServerClick" class="btnFind">
                    <span class="material-icons">search</span>
                </button>
                  <datalist runat="server" id="searching_auto"></datalist>
            </div>
        </div>
        <div runat="server" id="ShowItem" class="MainBBb">
  
              

            
        </div>
    </div>
    </form>
</body>
</html>

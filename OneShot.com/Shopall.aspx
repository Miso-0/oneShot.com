<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true"  CodeBehind="Shopall.aspx.cs" Inherits="OneShot.com.Shopall" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="css/oneShotResponsive.css">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="ShopAllMain">
                <div class="FilterSideBar">
                        <div id="filtersSelected" runat="server" class="filterbyCat">
                        <div class="topFilterLabel">
                            <h5>Filter by</h5>
                        </div>
                        <ul id="selectedFiltersShow" runat="server">
                 
                    
                        </ul>
                              <div class="close-btn">
                            <button runat="server" onserverclick="removeAll" class="removeAll">
                                <span class="material-icons-outlined">close</span>
                                <span>Remove all</span>
                            </button>
                        </div>
                    </div>
                    <div class="filterbyCat">
                        <div class="topFilterLabel">
                            <h5>Filter by Category</h5>
                        </div>
                        <ul id="categories" runat="server">
                           <li><a href="Shopall.aspx?q=Bakery">Bakery</a></li>
                        </ul>
                    </div>
                    <div class="filterbyOnSpecial">
                        <div class="topFilterLabel">
                            <h5>Filter by Price</h5>
                        </div>
                        <ul>
                            <li><a href="Shopall.aspx?filter=true&min=0&max=39">R0-R39.99</a></li>
                            <li><a href="Shopall.aspx?filter=true&min=40&max=79">R40-R79.99</a></li>
                            <li><a href="Shopall.aspx?filter=true&min=80&max=119">R80-R119.99</a></li>
                              <li><a href="Shopall.aspx?filter=true&min=120&max=159">R120-R159.99</a></li>
                            <li><a href="Shopall.aspx?filter=true&min=160&max=179">R160-R179.99</a></li>
                            <li><a href="Shopall.aspx?filter=true&min=180&max=299">R180-R299.99</a></li>
                        </ul>
                    </div>
                    <div class="filterbyPrice">
                        <div class="topFilterLabel">
                            <h5>Filter by Promotion</h5>
                        </div>
                        <ul runat="server" id="promoFilter">
                          
                  
                        </ul>
                    </div>
                </div>

               <div  class="topFilterContainer">
                     <div class="num-toshow-container">
                        <div onclick="openDropDown(0)" class="drop-down-header">
                            <span style="margin-left: 5px;">Show</span>
                            <span style="margin-left: 5px;"><span runat="server" id="numberShowing"></span></span>
                            <span style="margin-left: 5px;" class="material-icons-outlined">arrow_drop_down</span>
                        </div>
                        <div id="numdrop" class="drop-down-content-num">
                            <ul>
                                <li><button runat="server" onserverclick="btn16_ServerClick" class="btn-sort">1-16</button></li>
                                <li><button runat="server" onserverclick="btn32_ServerClick"  class="btn-sort">1-32</button></li>
                                <li><button runat="server" onserverclick="btn64_ServerClick"  class="btn-sort">1-62</button></li>
                                <li><button runat="server" onserverclick="btnall_ServerClick"  class="btn-sort">All</button></li>
                            </ul>
                        </div>
                    </div>

                    <div class="sort-by-container">
                        <div onclick="openDropDown(1)" class="drop-down-header-sort">
                            <span style="margin-left: 5px;" runat="server" id="selectedOrder">Sort by</span>
                            <span style="margin-left: 5px;" class="material-icons-outlined">arrow_drop_down</span>
                        </div>
                        <div id="sortdrop" class="drop-down-sort">
                            <ul>
                                <li><button runat="server" onserverclick="btnSortRemove_ServerClick" class="btn-sort" >Sort by</button></li>
                                <li><button class="btn-sort"  runat="server" onserverclick="btnSortAZ_ServerClick">Name A-Z</button></li>
                                <li><button class="btn-sort" runat="server" onserverclick="btnSortZA_ServerClick">Name Z-A</button></li>
                                <li><button class="btn-sort" runat="server" onserverclick="btnSortHL_ServerClick">Price High-Low</button></li>
                                <li><button class="btn-sort" runat="server" onserverclick="btnSortLH_ServerClick">Price Low-High</button></li>

                            </ul>
                        </div>
                    </div>
                </div>

            
                <div class="AlterFilter">
                   <div class="filterbyCat">
                        <div class="topFilterLabel">
                            <h5>Filter by Category</h5>
                        </div>
                        <ul>
                           <li><a href="Shopall.aspx?category=Bakery">Bakery</a></li>
                            <li><a href="Shopall.aspx?category=Dairy_and_Eggs">Dairy & Eggs</a></li>
                            <li><a href="Shopall.aspx?category=Meat_and_Poultry">Meat & Poultry</a></li>
                            <li><a href="Shopall.aspx?category=Frozen_Food">Frozen Food</a></li>
                            <li><a href="Shopall.aspx?category=Chocolates_Chips _and_Snacks">Chocolates , Chips & Snacks</a></li>
                            <li><a href="Shopall.aspx?category=Food_Cupbord">Food Cupbord</a></li>
                            <li><a href="Shopall.aspx?category=House_Hold_and_Cleaning">House Hold & Cleaning</a></li>
                            <li><a href="Shopall.aspx?category=Personal_care_and_Pharmarcy">Personal care & Pharmarcy</a></li>
                            <li><a href="Shopall.aspx?category=Electronics_and_Office">Electronics & Office</a></li>
                        </ul>
                    </div>
                    <div class="filterbyOnSpecial">
                        <div class="topFilterLabel">
                            <h5>Filter by Price</h5>

                        </div>
                        <ul>
                            <li><a href="Shopall.aspx?minimum=0&maximum=39.99">R0-R39.99</a></li>
                            <li><a href="Shopall.aspx?minimum=40&maximum=79.99">R40-R79.99</a></li>
                            <li><a href="Shopall.aspx?minimum=80&maximum=119.99">R80-R119.99</a></li>
                              <li><a href="Shopall.aspx?minimum=120&maximum=159.99">R120-R159.99</a></li>
                            <li><a href="Shopall.aspx?minimum=120&maximum=179.99">R160-R179.99</a></li>
                            <li><a href="Shopall.aspx?minimum=180&maximum=299.99">R180-R299.99</a></li>
                        </ul>
                    </div>
                    <div style="display:none;" class="filterbyPrice">
                        <div class="topFilterLabel">
                            <h5>Filter by Promotion</h5>
                        </div>
                        <ul>
                            <li><a href="#">Prom Name</a></li>
                            <li><a href="#">Prom Name</a></li>
                            <li><a href="#">Prom Name</a></li>
                        </ul>
                    </div>
                </div>

                <div runat="server" id="MainDisplay" class="MainItemDispleyerC">


                </div>
            </div>
     <script src="js/main.js"></script>
     <script>
                    function openDropDown(num) {
                        if (num == 0) {
                            if (document.getElementById("numdrop").style.display === "none") {
                                document.getElementById("numdrop").style.display = "block";
                                document.getElementById("sortdrop").style.display = "none";
                            } else {
                                document.getElementById("numdrop").style.display = "none";
                            }
                        } else if (num == 1) {
                            if (document.getElementById("sortdrop").style.display === "none") {
                                document.getElementById("sortdrop").style.display = "block";
                                document.getElementById("numdrop").style.display = "none";
                            } else {
                                document.getElementById("sortdrop").style.display = "none";
                            }
                        }

         }

         function closeall() {
             document.getElementById("sortdrop").style.display = "none";
             document.getElementById("numdrop").style.display = "none";
         }
       
     </script>
</asp:Content>

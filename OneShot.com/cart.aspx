<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="OneShot.com.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Cart</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script>
         function closeadd() {
             document.getElementsByClassName("shadow-background")[0].style.display = "none"
             document.getElementsByClassName("promo-add")[0].style.display = "none";
         }

         function openadd() {
             document.getElementsByClassName("shadow-background")[0].style.display = "block";
             document.getElementsByClassName("promo-add")[0].style.display = "block";
         }
     </script>

    <div onclick="closeadd()" class="shadow-background"></div>
    <div class="promo-add">
        <div style="width:100%;margin: 0;" class="RegisterContainer">
            <div onclick="closeadd()" style="margin: 0; background-color: transparent; border: none; color:z;" class="tobbtna">
                <span onclick="closeadd()" style="margin-left: 90%; cursor: pointer;" id="close" class="material-icons-outlined">close</span>
            </div>
            <div style="margin-top: 5px; margin-left: 26%;" class="RegisterInputs">
                <label for="emailaddress">Enter promo code</label><br>
                <input id="FirstName" runat="server" placeholder="ENTER PROMO CODE" type="text"><br>
                <p style="color: red;">invalid promo code</p><br>
                <button class="btn__next">
                    <span class="ll" style="margin-left: 20px;">Proceed</span>
                </button>
            </div>
        </div>
    </div>
    <div class="cart-container-base">
        <div class="items-base-cart">
            <div class="cart-header">
                  <h4 style="float: left;">YOUR CART(<span runat="server" id="numonCart">3</span>)</h4>
                   
                <button runat="server" onserverclick="RemoveItemsOnCart_ServerClick" class="btn-clear-cart">Clear cart</button>
                 <button runat="server" onserverclick="CopyToCart_ServerClick" class="btn-clear-cart">Copy to your list</button>
            </div>
            <div class="cart-progress">
                <div class="circles">
                    <span class="ci">
                        <div class="circle-prog">
                            <span class="count">1</span>
                    <!-- <span class="material-icons-outlined">check</span> -->
                </div>
                <h4 class="sub-t">View cart</h4>
                </span>
                <span class="ci">
                        <div class="circle-prog">
                            <span class="count">2</span>
                <!-- <span class="material-icons-outlined">check</span> -->
            </div>
            <h4 class="sub-t">Delivery</h4>
            </span>
            <span class="ci">
                        <div class="circle-prog">
                            <span class="count">3</span>
            <!-- <span class="material-icons-outlined">check</span> -->
        </div>
        <h4 class="sub-t">Payment</h4>
        </span>
    </div>
    <div style="width: 25%;" class="progress-bottom"></div>
    </div>
    <div runat="server" id="itemsDisplay" class="cart-items">



        
    </div>
    <div class="recommended-items">
        <div class="header-addmore">
            <h5>Recommended for you</h5>
            <a class="viewall" href="#">view all</a>
        </div>
        <div runat="server" id="recommendedItems" class="main-content-addmore">


        </div>
    </div>
    </div>
    <div class="cart-summary-totals">
        <div class="top-header-order-summary">
            <h4> Order summary</h4>
        </div>
        <ul>
            <li>
                <span class="title">Your Cart</span>
                <span id="TotalOnCart" runat="server" class="value">0</span>
            </li>
            <li>
                <span class="title">Total Discount</span>
                <span class="value">0</span>
            </li>
            <li>
                <span class="title">Delivery</span>
                <span id="totalDelivery" runat="server" class="value">0</span>
            </li>
            <li>
                <h4>
                    <span class="title">Order Total</span>
                    <span id="orderTotal" runat="server" class="value">0</span>
                </h4>
            </li>
            <li>
                <button runat="server" onserverclick="btnNext_Click" class="btn_proceed">
                        <span class="material-icons-outlined">lock</span>
                        <h3><span>Proceed</span></h3>
                    </button>
            </li>
            <li class="bbtn">
                <span class="title">DO YOU HAVE A PROMO CODE?</span>
                <span id="add" onclick="openadd()" class="value">ADD</span>
            </li>
        </ul>
    </div>
    </div>
</asp:Content>

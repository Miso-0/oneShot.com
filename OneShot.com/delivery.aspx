<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="delivery.aspx.cs" Inherits="OneShot.com.delivery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Delivery</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="cart-container-base">
        <div class="items-base-cart">
            <div class="cart-header">
                <h4>YOUR CART(<span runat="server" id="numonCart"></span>)</h4>
            </div>
            <div class="cart-progress">
                <div class="circles">
                    <span class="ci">
                        <div class="circle-prog">
                            <!-- <span class="count">1</span> -->
                    <span class="material-icons-outlined">check</span>
                </div>
                <h4 class="sub-t"><a style="text-decoration: none; color: rgb(0, 175, 58);" href="#">View cart</a> </h4>
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
    <div style="width: 50%;" class="progress-bottom"></div>
    </div>
    <div class="cart-items">
        <div id="deliverybanner" runat="server" class="free-delivery-banner">
            <h3>Spend R250 or more, and your delivery fee will automatically be removed!</h3>
        </div>
        <div class="delivery-address">
            <div class="delivery-info">
                <ul>
                    <li>Delivery Address: <span id="customeraddress" runat="server" class="delivery-info">Lorem ipsum dolor sit amet consectetur
                                    adipisicing elit. Exercitationem, veniam!</span></li>
                         <li>Name<span id="username" runat="server" class="delivery-info">someone@gmail.com</span></li>
                    <li>Estimated delivery time: <span id="estimatedDeliveryTime" runat="server" class="delivery-info">09/10/2021 17:00pm</span></li>
                    <li>Email address: <span id="customerEmail" runat="server" class="delivery-info">someone@gmail.com</span></li>
                    <li>Contact: <span id="cutomerContact" runat="server" class="delivery-info">1234567890</span></li>
                </ul>
            </div>
            <div class="actions-del">
                <a class="up-address" href="Registerlaststep.aspx?change=true"><span class="material-icons-outlined">local_shipping</span>Change delivery address</a>
            </div>
        </div>

        <div class="Note">
            <h4><span class="material-icons">info</span>Note:</h4><br>
            <ul>
                <li>The contact number provided will be used solely for delivery communication purposes.</li>
                <li>We will not share your delivery contact information with any external third parties.</li>
                <li>We will not use your email address or phone number for marketing purposes.</li>
            </ul>
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
                <button runat="server" onserverclick="btnPay_Click" class="btn_proceed">
                        <span class="material-icons-outlined">lock</span>
                        <h3><span>Pay</span></h3>
                    </button>
            </li>
        </ul>
    </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Vieworder.aspx.cs" Inherits="OneShot.com.Vieworder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div style="margin-bottom20px;" class="headerNav">
            <h3>Orders</h3>
            <input class="searchInput" placeholder="Order id \ Client email address" type="search">
            <button class="btnFind">Find order</button>
        </div>
       <div style="margin-top:0;" class="MainTracker">

        <div class="topS">
            <h4 style="margin-left:1.5%">Track</h4>
            <hr>
            <h4 style="margin-left:1.5%">Order ID : &nbsp;<span id="trackerID">243234ijk2v24f2</span></h4>

        </div>
        <div class="MidSec">
            <ul>
                <li>Clientname</li>
                <li>Items : <br> <span>5</span></li>
                <li>Amount paid : <br> <span>R4355</span></li>
                <li>Status : <br> <span>On its way</span></li>
                <li>Estimated arrival time :<br><span>20:40</span></li>
            </ul>
        </div>
        <div class="CheckSteps">
            <p>Order confirmed<input type="checkbox" class="checkbox" name="" id=""></p>
            <p> Picked up by courier<input type="checkbox" class="checkbox" name="" id=""></p>
            <p>On the way<input type="checkbox" class="checkbox" name="" id=""></p>
            <p>Order arrived<input type="checkbox" class="checkbox" name="" id=""></p>
        </div>
        <button class="backToOrder">
            <span class="material-icons">cached</span>
            <span>Update order</span>
        </button>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="orders.aspx.cs" Inherits="OneShot.com.orders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
    <title>Orders</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
            <div class="TopAdminHeader">
            <div class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Find order by Customer Name" id="searchSomething">
                <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
            </div>
            <a href="#"> <span class="material-icons">notifications</span></a>
            <a href="#"><span class="material-icons">email</span></a>
        </div>
        <div class="main-content">
            <div runat="server" id="showOrders" class="sub-main-content">
      
            </div>

        </div>
</asp:Content>

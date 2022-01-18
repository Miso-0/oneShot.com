<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="OneShot.com.products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
         <div class="TopAdminHeader">
            <div class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Find item" id="searchSomething">
                <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
            </div>
            <a href="#"> <span class="material-icons">notifications</span></a>
            <a href="#"><span class="material-icons">email</span></a>
        </div>
        <div class="main-content">
            <div id="products_Display" runat="server" class="sub-main-content">

            </div>
               <div class="floating-add-btn">
                   <a href="addproduct.aspx">
                        <span class="material-icons">add</span>
                  </a>
              </div>
        </div>
</asp:Content>

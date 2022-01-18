<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="promotions.aspx.cs" Inherits="OneShot.com.promotions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
           <div class="TopAdminHeader">
            <div class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Promotion name" id="searchSomething">
                <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
            </div>
            <a href="#"> <span class="material-icons">notifications</span></a>
            <a href="#"><span class="material-icons">email</span></a>
        </div>
        <div class="main-content">
            <div runat="server" id="promoLoader" class="sub-main-content">

            </div>
              <div class="floating-add-btn">
                   <a href="newpromotion.aspx">
                        <span class="material-icons">add</span>
                  </a>
              </div>
        </div>
</asp:Content>

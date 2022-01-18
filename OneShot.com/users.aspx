<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="OneShot.com.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div class="TopAdminHeader">
            <div class="searchBarbase">
                <input type="search" class="searchInput" placeholder="Find User" id="searchSomething">
                <button class="btnFind">
                    <span class="material-icons">search</span>
                </button>
            </div>
            <a href="#"> <span class="material-icons">notifications</span></a>
            <a href="#"><span class="material-icons">email</span></a>
        </div>
        <div class="main-content">
            <div runat="server" id="usersdisplay" class="sub-main-content">
        
            </div>
               <div class="floating-add-btn">
                   <a href="Addmanager.aspx">
                        <span class="material-icons">add</span>
                  </a>
              </div>
        </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="mylist.aspx.cs" Inherits="OneShot.com.mylist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>My List</title>
        <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.3.0/font/bootstrap-icons.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="my-account-container_dash">
                <div class="top-myaccount-header">
                    <h3 style="float: left;">My List(<span runat="server" id="listitemsTotal">4</span>)</h3>
                    <button class="list-btns" runat="server" onserverclick="clearList_ServerClick">Clear list</button>
                    <button runat="server" onserverclick="CopyToCart_ServerClick" class="list-btns">Copy  to Cart</button>
                </div>
                <div class="my-account-bottom-section">
                    <div class="slabs-a">
                        <div class="slab-nav">
                                         <a href="account.aspx" class="btn-myaccount-nav">
                                        <span class="material-icons-outlined">dashboard</span>
                                <span>My dashboard</span>
                            </a>
                                 <a href="mylist.aspx" class="btn-myaccount-nav">
                                <span class="material-icons-outlined">
                                format_list_bulleted
                                </span>
                                <span>My List</span>
                            </a>
                            <a href="myorders.aspx" class="btn-myaccount-nav">
                                <span class="material-icons-outlined">shopping_bag</span>
                                <span>My Orders</span>
                            </a>
                            <a href="Customersupport.aspx" class="btn-myaccount-nav">
                                <span class="material-icons-outlined">help_outline</span>
                                <span>Need help?</span>
                            </a>
                        </div>
                        <div runat="server" id="cuslistDisplay" class="main-content-viewer-my-account">
                           <h2 id="emptylist" runat="server" style="margin-left: 42%;margin-right: auto;margin-top: 120px; font-size: 50px;"> <i class="bi bi-card-list"></i><span style="font-size: 17px;margin-left: 10px;">Your list is empty<i style="margin-left: 10px; font-size: 14px;" class="bi bi-emoji-frown"></i></span></h2>
                        </div>
                    </div>

                </div>
            </div>
</asp:Content>

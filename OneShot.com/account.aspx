<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="OneShot.com.account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>My Account</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="my-account-container_dash">
                <div class="top-myaccount-header">
                    <h3>My Account</h3>
                </div>
                <div class="my-account-bottom-section">
                    <div class="slabs-a">
                        <div class="my-account-slab">
                            <h5>My Details</h5>
                            <ul>
                                <li>
                                    <span class="inn-my-account">Firstname:  </span>
                                    <span id="FirstName" runat="server" class="my-account-values">UserName</span>
                                </li>
                                <li>
                                    <span class="inn-my-account">Lastname:  </span>
                                    <span id="LastName" runat="server" class="my-account-values">UserName</span>
                                </li>

                                      <li>
                                    <span class="inn-my-account">Contact number:</span>
                                    <span runat="server" id="contactNumber" class="my-account-values">UserName</span>
                                </li>

                                <li>
                                    <span class="inn-my-account">Email address:</span>
                                    <span runat="server" id="emailAddress" class="my-account-values">UserName</span>
                                </li>

                                <li>
                                    <span class="inn-my-account">Delivery address:</span>
                                    <span runat="server" id="CustomerAddress" class="my-account-values">Lorue commodi velit, iste optio provident quam quaerat eveniet, impedit dolorem.</span>
                                </li>
                            </ul>
                        </div>
                        <a href="mylist.aspx" class="btn-myaccount" id="myaccount" runat="server">
                            <span class="material-icons-outlined">
                                format_list_bulleted
                                </span>
                            <span>My List (<span runat="server" id="listitemsTotal">10</span>)</span>
                        </a>
                        <a href="myorders.aspx"  class="btn-myaccount" id="myoders" runat="server">
                            <span class="material-icons-outlined">shopping_bag</span>
                            <span>My Orders (<span>2</span>)</span>
                        </a>
                        <a href="Customersupport.aspx"  class="btn-myaccount" id="cussupport" runat="server">
                            <span class="material-icons-outlined">help_outline</span>
                            <span>Need help?</span>
                        </a>
                    </div>
                </div>
            </div>
</asp:Content>

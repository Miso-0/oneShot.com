<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="transactions.aspx.cs" Inherits="OneShot.com.transactoins" %>
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
            <div class="sub-main-content">
                <table class="admimTable">
                    <tr>
                        <th>#No.</th>
                        <th>Customer name</th>
                        <th>Transaction date,time</th>
                        <th>Amount</th>
                        <th>Amount(-Tax)</th>
                        <th>Actions</th>
                    </tr>

                    <tr>
                        <td>#1</td>
                        <td>Name</td>
                        <td>2021/09/07</td>
                        <td>R300</td>
                        <td>R295</td>
                        <td><a href="#"><span class="material-icons">visibility</span></a></td>
                    </tr>






                </table>
            </div>

        </div>
</asp:Content>

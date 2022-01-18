<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Customersupport.aspx.cs" Inherits="OneShot.com.Customersupport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .BottomSectionInputAndButtons .UserInputSupport{
            padding-left:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div style="margin-bottom:150px; margin-left:8%" class="MainDisplay">
            <div id="messages" runat="server" class="MessageSection"></div>
            <div class="BottomSectionInputAndButtons">
                <input id="UserInputSupport" class="UserInputSupport"  placeholder="Say something" runat="server" type="email">
                <button id="btnsend" style="cursor:pointer" class="btnsend" runat="server" onserverclick="btnsend_ServerClick">Send</button>
            </div>
        </div>
</asp:Content>

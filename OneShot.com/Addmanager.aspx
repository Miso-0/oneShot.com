<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Addmanager.aspx.cs" Inherits="OneShot.com.Addmanager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="RegisterContainer">
                <div class="tobbtna">
                    <a href="#">
                        <h4>
                            <span style="background-color: rgb(0, 175, 58); border-radius: 3px; color: white;font-weight: bold;">One</span>
                            <span style="color: rgb(16, 16, 121);font-weight: bold;">Short</span>
                            <span>.</span>
                            <span style="color: rgb(51, 116, 182);">com</span>
                        </h4>
                    </a>
                </div>
                 <a style="text-decoration:none;color: rgb(0, 175, 58);" class="goAd" href="Usermanager.aspx">Go back to Admin</a>
                <div class="RegisterInputs">
                    <label for="FirstName">FirstName</label><br> 
                    <input id="FirstName" required="required" runat="server" type="text"><br>
                    <label for="LastName">LastName</label><br>
                    <input id="LastName" required="required" runat="server" type="text"><br>
                    <label for="FirstName">Email Address</label><br>
                    <input id="emailaddress" required="required" runat="server" type="text"><br>
                    <label for="IdNumber">ID Number</label><br>
                    <input id="IdNumber" required="required" runat="server" type="text"><br>
                    <label for="contactNumber">Contact Number</label><br>
                    <input id="contactNumber" required="required" runat="server" type="text"><br>
                    <label for="NewPassword">New Password</label><br>
                    <input id="NewPassword" required="required" runat="server" type="password"><br>
                    <label for="re_enter_Password">re-enter Password</label><br>
                    <input id="re_enter_Password" required="required" runat="server" type="password"><br>
                    <asp:Button ID="btnNext"  CssClass="btn_next"  runat="server" Text="Register" OnClick="btnNext_Click" /><br />
                      <p id="error" runat="server" style="color:red"></p>
                </div>
            </div>
</asp:Content>

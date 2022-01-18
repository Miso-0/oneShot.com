<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OneShot.com.Login" %>
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

                    <p style="margin-left: 30%;">Don't have an account? <a style="color: rgb(16, 16, 121);" href="Registerfirststep.aspx">Sign up</a></p>
                </div>


                <div style="margin-top: 5px; margin-left: 20%;" class="RegisterInputs">
                    <h4>Log in</h4>
                    <p style="font-weight:lighter; font-size: 13px;">Registered on our website?</p>
                    <p style="font-weight:lighter; font-size: 13px; border-bottom: 100px;">Use your login details here.</p><br>

                    <label for="emailaddress">Email address</label><br>
                    <input id="emailaddress" required="required" runat="server" type="text"><br>
                    <label for="userPassword">Password</label><br>
                    <input id="userPassword" required="required" runat="server" type="password"><br>
              

                       <button runat="server" onserverclick="btnNext_Click" class="btn__next">
                        <span class="material-icons">lock</span>
                        <span class="ll">Sign in</span>
                    </button><br />


                      <p id="error" runat="server" style="color:red"></p>
                </div>
            </div>
</asp:Content>

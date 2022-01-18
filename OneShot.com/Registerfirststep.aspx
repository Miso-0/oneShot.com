<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Registerfirststep.aspx.cs" Inherits="OneShot.com.Registerfirststep" %>
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
                    <p style="margin-left: 30%;">Already have an account? <a style="color: rgb(16, 16, 121);" href="Login.aspx">Sign in</a></p>
                </div>
                <p style="font-weight:lighter; font-size: 13px;">Let's get you signed up in a few easy steps.</p>
                <div class="RegisterInputs">
                    <label for="emailaddress">Email Address</label><br>
                    <input id="emailaddress" required="required" runat="server" type="text"><br>
              
                         <button runat="server" onserverclick="btnNext_Click" class="btn__next">
                        <span class="material-icons">arrow_forward</span>
                        <span class="ll">Next</span>
                    </button><br />

                    <p id="error" runat="server" style="color:red"></p>
                </div>
            </div>
</asp:Content>

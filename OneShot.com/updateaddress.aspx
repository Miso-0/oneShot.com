<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="updateaddress.aspx.cs" Inherits="OneShot.com.updateaddress" %>
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
                <p style="font-weight:lighter; font-size: 13px;">One last step.</p>
                <div class="RegisterInputs">
              
                    <input id="stAddress" required="required"  runat="server" placeholder="Street Address" type="text"><br>
                    <input id="complax" required="required"   runat="server" placeholder="Complex/Building" type="text"><br>
                    <input id="suburb" required="required"   runat="server" placeholder="Suburb" type="text"><br>

                    <input id="city" runat="server" required="required"   placeholder="City/Town" type="text"><br>

                    <select name="Province" runat="server" class="Province" id="Province">
                       <option  value="Province">Province</option>
                        <option value="Eastern Cape">Eastern Cape</option>
                        <option value="Free State">Free State</option>
                        <option value="Gauteng">Gauteng</option>
                        <option value="KwaZulu-Natal">KwaZulu-Natal</option>
                        <option value="Limpopo">Limpopo</option>
                        <option value="Mpumalanga">Mpumalanga</option>
                        <option value="Northern Cape">Northern Cape</option>
                        <option value="North West">North West</option>
                        <option value="Western Cape">Western Cape</option>
                    </select>

                    <input id="postalcode"  required="required"   runat="server" placeholder="Postal Code" type="text"><br>


                     <button runat="server"  onserverclick="btnNext_Click" class="btn__next">
                        <span class="material-icons">how_to_reg</span>
                        <span class="ll">Sign up</span>
                    </button>

                        <p id="error" runat="server" style="color:red"></p>
                    </div>
            </div>
</asp:Content>

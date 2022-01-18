<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="Track.aspx.cs" Inherits="OneShot.com.Track" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="MainTracker">
        <div class="topS">
            <h4 style="margin-left:1.5%">Track</h4>
            <hr>
            <h4 style="margin-left:1.5%">Order ID : &nbsp;<span id="trackerID" runat="server">243234ijk2v24f2</span></h4>

        </div>
        <div class="MidSec">
            <ul style="margin-top:10px;margin-bottom:10px;">
               <li style="margin-left: 10px;">Items : <br> <span id="qty"  runat="server"></span></li>
                <li>Amount paid : <br> <span id="totalAmount" runat="server"></span></li>
                <li style="width: 200px;">Address :<br><span id="Useraddress" runat="server"></span></li>
                <li>Estimated arrival time :<br><span id="date" runat="server"></span></li>
            </ul>
        </div>
        <div class="ProgreessBarBase">
            <div style="background-color:whitesmoke" class="basepr">
                <div id="pBar" runat="server" class="progress">
                    <div id="c1" runat="server" class="CircleOne">
                        <!-- 15% -->
                        <span onclick="goUp(1)" id="icon_1" class="material-icons">done</span>
                    </div>

                    <div id="c2" runat="server"  class="CircleTwo">
                        <!-- 40% -->
                        <span onclick="goUp(2)" id="icon_1" class="material-icons">person</span>
                    </div>

                    <div id="c3" runat="server"  class="CircleThree">
                        <!-- 60% -->
                        <span onclick="goUp(3)" id="icon_1" class="material-icons">local_shipping</span>
                    </div>

                    <div id="c4" runat="server"  class="CircleFour">
                        <!-- 80% -->
                        <span onclick="goUp(4)" id="icon_1" class="material-icons">home</span>
                    </div>
                </div>
            </div>

        </div>
        <div class="subtitles">
            <h5 class="sub1">Order confirmed</h5>
            <h5 class="sub2">Picked up by courier</h5>
            <h5 class="sub3">On the way</h5>
            <h5 class="sub4">Order arrived</h5>
        </div>

                <div style="margin-top: 20px;" id="updatebtns" runat="server" class="subtitles">
            <h5 class="sub1 ">
                <button runat="server" onserverclick="btnSt1" class="btnTrack">Order confirmed</button>
            </h5>
            <h5 class="sub2 "> <button class="btnTrack"  runat="server" onserverclick="btnSt2" >Picked up by courier</button></h5>
            <h5 class="sub3 "> <button style="margin-left: 20px;" class="btnTrack"  runat="server" onserverclick="btnSt3" >On the way</button></h5>
            <h5 class="sub4 "> <button class="btnTrack"  runat="server" onserverclick="btnSt4" >Order arrived</button></h5>
        </div>

        <a href="MyOrders.aspx">
            <div class="backToOrder" id="backToOrder"><span class="material-icons">arrow_back_ios</span> Back to orders</div>
        </a>
    </div>
    <script>
    function goUp(num) {
        if (num == 1) {
            document.getElementById("pBar").style.width = '15%';
            document.getElementById("c1").style.backgroundColor = 'rgb(0, 175, 58)';

        } else if (num == 2) {
            document.getElementById("pBar").style.width = '40%';
            document.getElementById("c2").style.backgroundColor = 'rgb(0, 175, 58)';

        } else if (num == 3) {
            document.getElementById("pBar").style.width = '60%';
            document.getElementById("c3").style.backgroundColor = 'rgb(0, 175, 58)';

        } else if (num == 4) {
            document.getElementById("pBar").style.width = '100%';
            document.getElementById("c4").style.backgroundColor = 'rgb(0, 175, 58)';

        }

    }
    </script>
</asp:Content>

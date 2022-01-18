<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="item.aspx.cs" Inherits="OneShot.com.item" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .num-reviews{
          font-size:12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     <script>
            var backgroundd = document.getElementById("sign_background");
            var page = document.getElementById("sign_in_pa");

            var close = document.getElementById("close");

            var signin = document.getElementById("signin")

            function Close() {
                backgroundd.style.display = "none";
                page.style.display = "none";
            }

            function Open() {
                backgroundd.style.display = "block";
                page.style.display = "block";
            }

            signin.addEventListener("click", () => {
                Open();
            })

            backgroundd.addEventListener("click", () => {
                Close();
            })

            close.addEventListener("click", () => {
                Close();
            })

     </script>
        <div id="mainbody " class="mainBody ">
            <div class="item-view-container">
                <div class="image-view">
                    <img runat="server" id="itemImage" src="images/coffe-removebg-preview.png" alt="img">
                </div>
                <div class="item-info-base">
                    <div class="top-item-info">
                        <ul>
                            <li>
                                <h2 id="ItemName" runat="server"></h2>
                            </li>
                            <li>
                                <h6>
                                    <span runat="server" id="ItemPrice" class="Item-name"></span>
                                </h6>
                            </li>
                            <li>
                                <div class="item-stars-view">
                                    <p  runat="server" id="itemStars"></p>
                                </div>
                               <!-- <a href="#">
                                    <span>50</span>
                                    <span>Reviews</span></a>-->
                            </li>
                            <li>
                                <hr style="opacity: 0.3;">
                            </li>
                            <li>
                                <select name="qty" runat="server" class="select-qty" id="qty">
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                    <option value="4">4</option>
                                    <option value="5">5</option>
                                    <option value="6">6</option>
                                    <option value="7">7</option>
                                    <option value="8">8</option>
                                    <option value="9">9</option>
                                    <option value="10">10</option>
                                     <option value="11">11</option>
                                    <option value="12">12</option>
                                    <option value="13">13</option>
                                    <option value="14">14</option>
                                    <option value="15">15</option>
                                </select>
                                <button class="btn-add-cart" runat="server" onserverclick="AddToCart">
                                    Add to cart
                                </button>
                            </li>
                            <li>
                                <hr style="opacity: 0.3;">
                            </li>
                            <li>
                                <button class="add-to-list">
                                    <span class="material-icons">list</span>
                                    <span>Add to list</span>
                                </button>
                            </li>
                        </ul>
                    </div>
                    <div class="accordian-base">
                        <div class="accordion">
                            <span>Description</span>
                            <span class="material-icons-outlined">add</span>
                        </div>
                        <div id="ItemDescrptionPanel" runat="server" class="panel">
                        </div>

                        <div class="accordion">
                            <span>Reviews (<span runat="server" id="numReviews" class="num-reviews">0</span>)</span>
                            <span class="material-icons-outlined">add</span>
                        </div>
                        <div class="panel">
                            <div id="Reviews" runat="server" class="Reviews-view">

                        
                            </div>
                        </div>

                        <div class="accordion">
                            <span>Review this product</span>
                            <span class="material-icons-outlined">add</span>
                        </div>
                        <div class="panel">
                            <div id="addReviewSection" class="AddReviewSection">
                                <textarea class="ReviewArea" name="Review" id="reviewField" runat="server" cols="30" rows="10"></textarea><br>

                                <div class="Stars">
                                    <div onclick="star(1)" class="ratingstar"><span id="star1" ClientIDMode="Static" class="material-icons">star_rate</span></div>
                                    <div onclick="star(2)" class="ratingstar"><span id="star2" ClientIDMode="Static"   class="material-icons">star_rate</span></div>
                                    <div onclick="star(3)" class="ratingstar"><span id="star3" ClientIDMode="Static"  class="material-icons">star_rate</span></div>
                                    <div onclick="star(4)" class="ratingstar"><span id="star4" ClientIDMode="Static"  class="material-icons">star_rate</span></div>
                                    <div onclick="star(5)" class="ratingstar"><span id="star5" ClientIDMode="Static"  class="material-icons">star_rate</span></div>
                                    <input type="text" style="display:none" ClientIDMode="Static" runat="server" name="star" id="starss">
                                    <p style="display: none;" id="numStars">0</p>
                                </div>
                                <Button class="submitReview" runat="server" onserverclick="AddReview">Submit Review</Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="recomadations">
                <div style="text-align: left;" class="reco-toplabel">
                    <p>
                       Similer Items
                    </p>
                </div>
                <div runat="server" id="recommended" class="reco-content">

                </div>
            </div>
        </div>
    
    <script>

        var star1 = document.getElementById("star1");
        var star2 = document.getElementById("star2");
        var star3 = document.getElementById("star3");
        var star4 = document.getElementById("star4");
        var star5 = document.getElementById("star5");
        var number = document.getElementById("numStars");
        var starInput = document.getElementById("starss");

        function star(num) {
            if (num === 1) {
                star1.style.color = "rgb(0, 175, 58)";
                star2.style.color = "rgb(161, 248, 190)";
                star3.style.color = "rgb(161, 248, 190)";
                star4.style.color = "rgb(161, 248, 190)";
                star5.style.color = "rgb(161, 248, 190)";
                number.innerText = 1;
                document.getElementById("starss").value = 1;
            } else if (num === 2) {
                star1.style.color = "rgb(0, 175, 58)";
                star2.style.color = "rgb(0, 175, 58)";
                star3.style.color = "rgb(161, 248, 190)";
                star4.style.color = "rgb(161, 248, 190)";
                star5.style.color = "rgb(161, 248, 190)";
                number.innerText = 2;
                document.getElementById("starss").value = 2;
            } else if (num === 3) {
                star1.style.color = "rgb(0, 175, 58)";
                star2.style.color = "rgb(0, 175, 58)";
                star3.style.color = "rgb(0, 175, 58)";
                star4.style.color = "rgb(161, 248, 190)";
                star5.style.color = "rgb(161, 248, 190)";
                number.innerText = 3;
                document.getElementById("starss").value = 3;
            } else if (num === 4) {
                star1.style.color = "rgb(0, 175, 58)";
                star2.style.color = "rgb(0, 175, 58)";
                star3.style.color = "rgb(0, 175, 58)";
                star4.style.color = "rgb(0, 175, 58)";
                star5.style.color = "rgb(161, 248, 190)";
                number.innerText = 4;
                document.getElementById("starss").value = 4;
            } else if (num === 5) {
                star1.style.color = "rgb(0, 175, 58)";
                star2.style.color = "rgb(0, 175, 58)";
                star3.style.color = "rgb(0, 175, 58)";
                star4.style.color = "rgb(0, 175, 58)";
                star5.style.color = "rgb(0, 175, 58)";
                number.innerText = 5;
                document.getElementById("starss").value = 5;
            }
        }

    </script>
    <script src="js/main.js"></script>
    <script>
        var acc = document.getElementsByClassName("accordion");
        var i;

        for (i = 0; i < acc.length; i++) {
            acc[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var panel = this.nextElementSibling;
                if (panel.style.display === "block") {
                    panel.style.display = "none";
                } else {
                    panel.style.display = "block";
                }
            });
        }
    </script>
</asp:Content>

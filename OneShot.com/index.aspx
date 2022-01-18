<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="OneShot.com.index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function showMore(num) {
            if (document.getElementsByClassName("promo-content-each")[num].style.height === "430px") {

                document.getElementsByClassName("promo-content-each")[num].style.overflow = "initial";
                document.getElementsByClassName("promo-content-each")[num].style.height = "auto";
                document.getElementsByClassName("showbtns")[num].innerText = "Show less"

            } else {
                document.getElementsByClassName("promo-content-each")[num].style.overflow = "hidden";
                document.getElementsByClassName("promo-content-each")[num].style.height = "430px";
                document.getElementsByClassName("showbtns")[num].innerText = "Show all"
            }
        }
    </script>

    <style>
        .col-item-container ul li{
            margin-top:0;
            margin-bottom:0;
            font-size:15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="topSliderBannerContainer">
                <div class="bannertop">
                    <div class="container_slider">
                        <div class="carousel">
                            <div class="slider">
                              <section>
                                    <a href="#">
                                        <img style="width: 100%;height: 400px;" src="images/Online-Free-Delivery-Website-Banner.jpg" alt="img">
                                    </a>
                                </section>
                                <section>
                                     <a href="#">
                                        <img style="width: 100%;height: 400px;" src="images/Online-Free-Delivery-Website-Banner.jpg" alt="img">
                                    </a>
                                </section>
                                <section>
                                     <a href="#">
                                        <img style="width: 100%;height: 400px;" src="images/photo-1632776350300-11016768b521.jpg" alt="img">
                                    </a>
                                </section>
                                <section runat="server" id="banner4">
                                    Content for section 4
                                </section>
                            </div>
                            <div class="controls">
                                <span class="arrow left"><span class="material-icons">arrow_back_ios</span></span>
                                <span runat="server" class="arrow right"><span class="material-icons">arrow_forward_ios</span></span>
                                <ul style="display: none;">
                                    <li class="selected"></li>
                                    <li></li>
                                    <li></li>
                                    <li></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="mainBodyA">

                <div runat="server" id="promotioncontainer"></div>

            </div>

 <div class="d">
        <h3>All our food categories</h3>
    </div>
    <div runat="server" id="loadAllCats" class="categories-base">

    </div>



    <script>
    const slider = document.querySelector(".slider");
    const leftArrow = document.querySelector(".left");
    const rightArrow = document.querySelector(".right");
    const indicatorParent = document.querySelector('.controls ul')

    var sectionIndex = 0;

    function ChangeSlider() {
        sectionIndex = 3;
        slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
    }


    document.querySelectorAll(".controls li").forEach(function(indicator, index) {
        indicator.addEventListener("click", function() {
            sectionIndex = index;
            document.querySelector('.controls .selected').classList.remove('selected');
            indicator.classList.add('selected')
            slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
        })
    })

    rightArrow.addEventListener("click", function() {
        sectionIndex = (sectionIndex < 3) ? sectionIndex + 1 : 3;
        indicatorParent.children[sectionIndex].classList.add('selected');

        document.querySelector('.controls .selected').classList.remove('selected');

        slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
    });

    leftArrow.addEventListener("click", function() {
        sectionIndex = (sectionIndex > 0) ? sectionIndex - 1 : 0;
        indicatorParent.children[sectionIndex].classList.add('selected');
        document.querySelector('.controls .selected').classList.remove('selected');
        slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';

    });




    count = 0;

    function Add() {
        count += 1;
        document.getElementById("numITemsToAdd").innerText = count;
    }

    function Minus() {
        if (count <= 0) {
            count = 0;
            document.getElementById("numITemsToAdd").innerText = 0;
        } else {
            count -= 1;
            document.getElementById("numITemsToAdd").innerText = count;
        }

    }
    </script>
</asp:Content>

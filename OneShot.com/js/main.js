

function OpenClose() {
    if (document.getElementById("OptionsToshow").style.display === "block") {
        document.getElementById("OptionsToshow").style.display = "none";
        document.getElementById("tdown").style.display = "block"
        document.getElementById("tUp").style.display = "none"

    } else {
        document.getElementById("OptionsToshow").style.display = "block";
        document.getElementById("tUp").style.display = "block"
        document.getElementById("tdown").style.display = "none"
    }
}

var star1 = document.getElementById("star1");
var star2 = document.getElementById("star2");
var star3 = document.getElementById("star3");
var star4 = document.getElementById("star4");
var star5 = document.getElementById("star5");
var number = document.getElementById("numStars");

function star(num) {
    if (num === 1) {
        star1.style.color = "rgb(0, 175, 58)";
        star2.style.color = "rgb(161, 248, 190)";
        star3.style.color = "rgb(161, 248, 190)";
        star4.style.color = "rgb(161, 248, 190)";
        star5.style.color = "rgb(161, 248, 190)";
        document.getElementById("starss").value = 1;
       
    } else if (num === 2) {
        star1.style.color = "rgb(0, 175, 58)";
        star2.style.color = "rgb(0, 175, 58)";
        star3.style.color = "rgb(161, 248, 190)";
        star4.style.color = "rgb(161, 248, 190)";
        star5.style.color = "rgb(161, 248, 190)";
        document.getElementById("starss").value = 2;

    } else if (num === 3) {
        star1.style.color = "rgb(0, 175, 58)";
        star2.style.color = "rgb(0, 175, 58)";
        star3.style.color = "rgb(0, 175, 58)";
        star4.style.color = "rgb(161, 248, 190)";
        star5.style.color = "rgb(161, 248, 190)";
        document.getElementById("starss").value = 3;
    } else if (num === 4) {
        star1.style.color = "rgb(0, 175, 58)";
        star2.style.color = "rgb(0, 175, 58)";
        star3.style.color = "rgb(0, 175, 58)";
        star4.style.color = "rgb(0, 175, 58)";
        star5.style.color = "rgb(161, 248, 190)";
        document.getElementById("starss").value = 4;
    } else if (num === 5) {
        star1.style.color = "rgb(0, 175, 58)";
        star2.style.color = "rgb(0, 175, 58)";
        star3.style.color = "rgb(0, 175, 58)";
        star4.style.color = "rgb(0, 175, 58)";
        star5.style.color = "rgb(0, 175, 58)";
        document.getElementById("starss").value = 5;
    }
}

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

const slider = document.querySelector(".slider");
const leftArrow = document.querySelector(".left");
const rightArrow = document.querySelector(".right");
const indicatorParent = document.querySelector('.controls ul')

var sectionIndex = 0;
document.querySelectorAll(".controls li").forEach(function (indicator, index) {
    indicator.addEventListener("click", function () {
        sectionIndex = index;
        document.querySelector('.controls .selected').classList.remove('selected');
        indicator.classList.add('selected')
        slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
    })
})

rightArrow.addEventListener("click", function () {
    sectionIndex = (sectionIndex < 3) ? sectionIndex + 1 : 3;
    indicatorParent.children[sectionIndex].classList.add('selected');
    document.querySelector('.controls .selected').classList.remove('selected');
    slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
});

leftArrow.addEventListener("click", function () {
    sectionIndex = (sectionIndex > 0) ? sectionIndex - 1 : 0;
    indicatorParent.children[sectionIndex].classList.add('selected');
    document.querySelector('.controls .selected').classList.remove('selected');
    slider.style.transform = 'translate(' + (sectionIndex) * -25 + '%)';
});


var description = document.getElementById("DescriptionSection");
var Reviews = document.getElementById("ReviewSection");
var AddReview = document.getElementById("addReviewSection");

var Extend1 = document.getElementById("extend1");
var Extend1Less = document.getElementById("extend1Less");
var Extend2 = document.getElementById("extend2");
var Extend2Less = document.getElementById("extend2Less");

function SwitchSection(num) {
    if (num == 1) {
        description.style.display = "block";
        Reviews.style.display = "none";
        AddReview.style.display = "none";
        Extend1.style.display = "none"
        Extend1Less.style.display = "block"

        Extend2.style.display = "block";
        Extend2Less.style.display = "none";

    } else if (num == 2) {
        description.style.display = "none";
        Reviews.style.display = "block";
        AddReview.style.display = "none";

        Extend1.style.display = "block"
        Extend1Less.style.display = "none"

        Extend2.style.display = "none";
        Extend2Less.style.display = "block";

    } else if (num == 3) {
        description.style.display = "none";
        Reviews.style.display = "none";
        AddReview.style.display = "block";

        Extend1.style.display = "block"
        Extend1Less.style.display = "none"

        Extend2.style.display = "none";
        Extend2Less.style.display = "block";

    }
}

window.addEventListener('scroll', () => {
    const scolleNum = window.scrollY;
    ScrollerSenser(scolleNum);
})



var description = document.getElementById("DescriptionSection");
var Reviews = document.getElementById("ReviewSection");
var AddReview = document.getElementById("addReviewSection");

var Extend1 = document.getElementById("extend1");
var Extend1Less = document.getElementById("extend1Less");
var Extend2 = document.getElementById("extend2");
var Extend2Less = document.getElementById("extend2Less");

function SwitchSection(num) {
    if (num === 1) {
        description.style.display = "block";
        Reviews.style.display = "none";
        AddReview.style.display = "none";
        Extend1.style.display = "none"
        Extend1Less.style.display = "block"

        Extend2.style.display = "block";
        Extend2Less.style.display = "none";

    } else if (num === 2) {
        description.style.display = "none";
        Reviews.style.display = "block";
        AddReview.style.display = "none";

        Extend1.style.display = "block"
        Extend1Less.style.display = "none"

        Extend2.style.display = "none";
        Extend2Less.style.display = "block";

    } else if (num === 3) {
        description.style.display = "none";
        Reviews.style.display = "none";
        AddReview.style.display = "block";

        Extend1.style.display = "block"
        Extend1Less.style.display = "none"

        Extend2.style.display = "none";
        Extend2Less.style.display = "block";

    }
}
function showAlterFilter() {
    document.getElementsByClassName("AlterFilter")[0].style.display = "block"
}

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
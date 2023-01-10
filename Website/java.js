
function navBar() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}

let mybutton = document.getElementById("myBtn");
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

let slideIndex = 1;
showSlides(slideIndex);


function plusSlides(n) {
  showSlides(slideIndex += n);
}


function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  let i;
  let slides = document.getElementsByClassName("mySlidesfade");
  let dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1}
  if (n < 1) {slideIndex = slides.length}
  for (i = 0; i < slides.length; i++) {
    slides[i].style.display = "none";
  }
  for (i = 0; i < dots.length; i++) {
    dots[i].className = dots[i].className.replace(" active", "");
  }
  slides[slideIndex-1].style.display = "block";
  dots[slideIndex-1].className += " active";
}


var loader = document.getElementById("preloader")
window.addEventListener("load", function () {
    loader.transoto
    loader.style.display = "none";
})
AOS.init({
duration: 1000,
once: true,

});


function selectLan() {
  let select = document.getElementById('language').value ;
  let rules1 = document.getElementById('Rules1');
   if(document.getElementById('language').value === 'eu'){
   document.getElementById('rulesTitle').innerHTML = "ANGOL";
   rules1.innerHTML = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa laudantium blanditiis fugit"
  }
  else{
    document.getElementById('rulesTitle').innerHTML = "SZABÁLYZAT";
    rules1.innerHTML = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Ipsa laudantium blanditiis fugitvelit accusantium dolore asperiores culpa sunt voluptatum magni! Voluptatum, error veroeveniet dolor natus at explicabo voluptatem accusamus!Deserunt facere itaque minima laboriosam quae corrupti, dolores, in sequi sunt numquamsed aliquam inventore reprehenderit adipisci esse, earum, soluta quasi!" 
  }
   }
  


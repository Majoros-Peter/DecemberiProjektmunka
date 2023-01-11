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
 if(document.getElementById('language').value === 'eu')
 {
    document.getElementById("Rules1").innerHTML = "Navigating in Menu:";
    document.getElementById("made").innerHTML = "Made By:";
    document.getElementById("project").innerHTML = "December Project Work";
    document.getElementById("labirint").innerHTML = "Labirynth";
    document.getElementById('nav2').innerHTML = "RULES";
    document.getElementById('nav3').innerHTML = "THE GAME";
    document.getElementById('nav4').innerHTML = "THE TEAM";
    document.getElementById('rulesTitle').innerHTML = "RULES";
    document.getElementById("RulesText1").innerHTML = "You can navigate through the menu by pressing ↑ ↓ ENTER and go back one step (or exit) by pressing ESC.";
    document.getElementById("RulesText2").innerHTML = "In the map editor you can move around by default using the ↑ ↓ → ← buttons. Items can be selected using the characters shown below them. You can rotate the selected map elements by pressing the + - buttons and unload them by pressing ENTER. When the track is done, you just press ESC and if it is done correctly, you can save it.";
    document.getElementById("RulesText3").innerHTML = "In the game, control is by default with the ↑ ↓ → ← buttons. The goal of the game is to get to (and out of) as many treasure rooms as possible. The difficulty of the game can be increased by using a covered map, a light maze, blindness";
    document.getElementById("SlidesText1").innerHTML = "EDITING THE LABYRINTH: After specifying the width and height of the labyrinth (20;10 in the picture), you can move with the arrows (you must place at least 1 treasure room to make it regular).";
    document.getElementById("SlidesText2").innerHTML = "TO CREATE A LABYRINTH: After entering the width and height of the maze (30;15 in the picture), you have to enter the starting coordinate, the centre of the track is recommended (the program will print this). After that you can further modify the maze (you have to add at least 1 treasure room to make it regular).";
    document.getElementById("SlidesText3").innerHTML = "MODIFYING AN EXISTING LABYRINTH: it starts by specifying the name of an existing labyrinth (no path, no extension, just the name of the labyrinth).";
    
  }
  else
  {
    document.getElementById("made").innerHTML = "Készítette:";
    document.getElementById("project").innerHTML = "Decemberi Projektmunka";
    document.getElementById("labirint").innerHTML = "Labirintus";
    document.getElementById('nav2').innerHTML = "Szabályzatról";
    document.getElementById('nav3').innerHTML = "Játékról";
    document.getElementById('nav4').innerHTML = "Csapatról";
    document.getElementById('rulesTitle').innerHTML = "SZABÁLYZAT";
    document.getElementById("RulesText1").innerHTML = "Menüben navigálás";
    document.getElementById("RulesText2").innerHTML = "Térkép szerkesztőben irányítás";
    document.getElementById("RulesText3").innerHTML = "Játékban irányítás";
    document.getElementById("SlidesText1").innerHTML = "SAJÁT LABIRINTUS SZERKESZTÉSE: A labirintus szélessége és magassága (a képen 20;10) megadása után a nyilakkal lehet mozogni (legalább 1 kincses termet muszáj rakni, hogy szabályos legyen).";
    document.getElementById("SlidesText2").innerHTML = "LABIRINTUS GENERÁLÁSA: A labirintus szélessége és magassága (a képen 30;15) megadása után meg kell még adni a kezdőkoordinátát, a pálya közepe az ajánlott (ezt majd kiírja a program). Ezután lehet tovább módosítani még a labirintuson (legalább 1 kincses termet muszáj rakni, hogy szabályos legyen).";
    document.getElementById("SlidesText3").innerHTML = "MEGLÉVŐ LABIRINTUSON MÓDOSÍTÁS: Azzal kezdődik, hogy meg kell egy létező labirintus nevét (nem kell elérési út, se kiterjesztés, csak a labirintus neve).";
  }
}
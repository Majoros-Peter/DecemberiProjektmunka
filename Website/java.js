
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


function selectLan() 
{

 if(document.getElementById("language").value == "us")
 {
  document.getElementById("Rules1").innerHTML = "Navigating in the menu"
  document.getElementById("Rules2").innerHTML = "Map editor"
  document.getElementById("Rules3").innerHTML = "In game control"
  document.getElementById("kozepre").innerHTML = "Game and editor introduction"
  document.getElementById("project").innerHTML = "Project work in december"
  document.getElementById("labirint").innerHTML = "Labirynth"
  document.getElementById("nav2").innerHTML = "RULES"
  document.getElementById("nav3").innerHTML = "ABOUT GAME"
  document.getElementById("nav4").innerHTML = "ABOUT TEAM"
  document.getElementById("rulesTitle").innerHTML = "RULES"
  document.getElementById("RulesText1").innerHTML = "You can navigate through the menu by pressing ↑ ↓ ENTER and go back one step (or exit) by pressing ESC."
  document.getElementById("RulesText2").innerHTML = "In the map editor you can move around by default using the ↑ ↓ → ← buttons. Items can be selected using the characters shown below them. You can rotate the selected map elements by pressing the + - buttons and unload them by pressing ENTER. When the track is done, you just press ESC and if it is done correctly, you can save it.";
  document.getElementById("RulesText3").innerHTML=" In the game, control is by default with the ↑ ↓ → ← buttons. The goal of the game is to get to (and then out of) as many treasure rooms as possible. The difficulty of the game can be increased by using a covered map with a lightbox, blinds"
  document.getElementById("SlidesText1").innerHTML = "EDITING THE LABYRINTH: After specifying the width and height of the labyrinth (20;10 in the picture), you can move with the arrows (you must place at least 1 treasure room to make it regular)."
  document.getElementById("SlidesText2").innerHTML = "TO CREATE A LABYRINTH: After entering the width and height of the maze (30;15 in the picture), you have to enter the starting coordinate, the centre of the track is recommended (the program will print this). After that you can further modify the maze (you have to add at least 1 treasure room to make it regular)."
  document.getElementById("SlidesText3").innerHTML = "MODIFYING AN EXISTING LABYRINTH: it starts by specifying the name of an existing labyrinth (no path, no extension, just the name of the labyrinth)."
  document.getElementById("SlidesText4").innerHTML = "HOW THE GAME WORKS: After entering the name of the track, you load the track with various data next to it. After discovering the treasure rooms, you can leave the map and win the game."
  document.getElementById("SlidesText5").innerHTML= "DIFFERENT GAME MODES: the loss of light, where the pathways are goes into dark, or the opposite."
  document.getElementById("SlidesText6").innerHTML = "You can read various details in the information box next to the track, including the size of the track, which directions you can go in and the number of rooms you have explored."
  document.getElementById("Teamh2").innerHTML = "Work schedule"
  document.getElementById("AboutTheTeam1").innerHTML = "Game Program"
  document.getElementById("AboutTheTeam2").innerHTML = "Map Editor"
  document.getElementById("AboutTheTeam3").innerHTML = "Methods,Website"
}
  else if(document.getElementById("language").value == "hu")
  {
    document.getElementById("AboutTheTeam1").innerHTML = "Játékprogram"
    document.getElementById("AboutTheTeam2").innerHTML = "Pályaszerkesztő"
    document.getElementById("AboutTheTeam3").innerHTML = "Metódusok, Weboldal"
    document.getElementById("Rules1").innerHTML = "Menüben navigálás"
    document.getElementById("Rules2").innerHTML = "Térkép szerkesztőben irányítás "
    document.getElementById("Rules3").innerHTML = "Játékban irányítás"
    document.getElementById("kozepre").innerHTML = "Játék és szerkesztő bemutatása"
    document.getElementById("project").innerHTML = "Decemberi Projektmunka"
    document.getElementById("labirint").innerHTML = "Labirintus"
    document.getElementById("nav2").innerHTML = "Szabályzatról"
    document.getElementById("nav3").innerHTML = "Játékról"
    document.getElementById("nav4").innerHTML = "Csapatról"
    document.getElementById("rulesTitle").innerHTML = "SZABÁLYZAT"
    document.getElementById("RulesText1").innerHTML = "A menüben a ↑ ↓ ENTER gombokkal lehet navigálni, valamint az ESC gombbal eggyel vissza lehet menni (vagy kilépni)."
    document.getElementById("RulesText2").innerHTML = "A térkép szerkesztőben alapból a ↑ ↓ → ← gombokkal lehet mozogni. Az elemeket az alattuk látható karakterekkel lehet kiválasztani. Forgatni a + - gombokkal lehet a kiválasztott pálya elemeket, lerakni pedig az ENTER-el. Ha kész a pálya, akkor csak meg kell nyomni az ESC-t, és ha szabályosan lett megcsinálva, akkor el is lehet menteni."
    document.getElementById("RulesText3").innerHTML = " A játéban az irányítás alapból a ↑ ↓ → ← gombokkal működik. A játék célja, a lehető legtöbb kincses terembe való eljutás (majd kijutás). A játék nehézségét lehet fokozni fedett térképpel fényvesztővel, vaksággal"
    document.getElementById("SlidesText6").innerHTML = "Különböző adatokat le lehet olvasni a pálya mellett található információs mezőben, melyben megtalálható a pálya mérete, hogy melyik irányokba tudunk menni és a felfedezett termek száma."
    document.getElementById("SlidesText5").innerHTML = "KÜLÖNBÖZŐ JÁTÉKMÓDOK:a fényvesztés, melyben elsötétülnek a járatok, melyekben már jártunk, vagy pont az ellentéte ennek."
    document.getElementById("SlidesText4").innerHTML = "A JÁTÉK MENETE: A pálya neve után megadva betölti a pályát, amely mellett különböző adatok találhatóak. A kincses termek felfedezése után ki lehet menni a pályáról, ezáltal megnyerni a játékot."
    document.getElementById("SlidesText3").innerHTML = "MEGLÉVŐ LABIRINTUSON MÓDOSÍTÁS: Azzal kezdődik, hogy meg kell egy létező labirintus nevét (nem kell elérési út, se kiterjesztés, csak a labirintus neve)."
    document.getElementById("SlidesText2").innerHTML = "LABIRINTUS GENERÁLÁSA: A labirintus szélessége és magassága (a képen 30;15) megadása után meg kell még adni a kezdőkoordinátát, a pálya közepe az ajánlott (ezt majd kiírja a program). Ezután lehet tovább módosítani még a labirintuson (legalább 1 kincses termet muszáj rakni, hogy szabályos legyen)."
    document.getElementById("SlidesText1").innerHTML = "SAJÁT LABIRINTUS SZERKESZTÉSE: A labirintus szélessége és magassága (a képen 20;10) megadása után a nyilakkal lehet mozogni (legalább 1 kincses termet muszáj rakni, hogy szabályos legyen)."
    document.getElementById("Teamh2").innerHTML = "Munkafelosztás"
  }

}

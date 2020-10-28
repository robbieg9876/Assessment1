var displayedImage = document.querySelector('.displayed-img');
var thumbBar = document.querySelector('.thumb-bar');

var overlay = document.querySelector('.overlay');

/* Looping through images */
var names = ["Kiko Casilla","Pontus Jansson","Kalvin Phillips","Mateusz Klich","Pablo Hernandez","Jack Clarke","Kemar Roofe","Liam Cooper","Patrick Bamford","Luke Ayling"];
var ages = ["32","28","23","28","34","18","26","27","25","27"]
var positions = ["Goalkeeper","Center Back","Center Defensive Mid", "Center Mid","Right Mid","Right Mid","Striker","Centre Back","Striker","Right Back"];
 for(var i = 1; i <= 10; i++) {
  var newImage = document.createElement('img');
  newImage.setAttribute('src', 'player' + i + '.jpg');
  thumbBar.appendChild(newImage);
  newImage.onclick = function(e) {
    var imgSrc = e.target.getAttribute('src');
    displayImage(imgSrc);
    var chosenImg=imgSrc;
    if (chosenImg=="player1.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[0];
      document.getElementById("age").innerHTML =  "Age: "+ages[0];
      document.getElementById("position").innerHTML = "Positon: "+positions[0];
    }
    else if (chosenImg=="player2.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[1];
      document.getElementById("age").innerHTML =  "Age: "+ages[1];
      document.getElementById("position").innerHTML = "Positon: "+positions[1];
    }
    else if (chosenImg=="player3.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[2];
      document.getElementById("age").innerHTML =  "Age: "+ages[2];
      document.getElementById("position").innerHTML = "Positon: "+positions[2]
    }
    else if (chosenImg=="player4.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[3];
      document.getElementById("age").innerHTML =  "Age: "+ages[3];
      document.getElementById("position").innerHTML = "Positon: "+positions[3];
    }
    else if (chosenImg=="player5.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[4];
      document.getElementById("age").innerHTML =  "Age: "+ages[4];
      document.getElementById("position").innerHTML = "Positon: "+positions[4]
      }
    else if (chosenImg=="player6.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[5];
      document.getElementById("age").innerHTML =  "Age: "+ages[5];
      document.getElementById("position").innerHTML = "Positon: "+positions[5];
    }
    else if (chosenImg=="player7.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[6];
      document.getElementById("age").innerHTML =  "Age: "+ages[6];
      document.getElementById("position").innerHTML = "Positon: "+positions[6]
    }
    else if (chosenImg=="player8.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[7];
      document.getElementById("age").innerHTML =  "Age: "+ages[7];
      document.getElementById("position").innerHTML = "Positon: "+positions[7];
    }
    else if (chosenImg=="player9.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[8];
      document.getElementById("age").innerHTML =  "Age: "+ages[8];
      document.getElementById("position").innerHTML = "Positon: "+positions[8]
    }
    else if (chosenImg=="player10.jpg"){
      document.getElementById("name").innerHTML = "Name: "+names[9];
      document.getElementById("age").innerHTML =  "Age: "+ages[9];
      document.getElementById("position").innerHTML = "Positon: "+positions[9];
    }
  }
}
  function displayImage(imgSrc) {
  displayedImage.setAttribute('src', imgSrc);
}


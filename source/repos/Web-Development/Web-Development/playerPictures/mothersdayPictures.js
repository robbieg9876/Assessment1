var displayedImage = document.querySelector('.displayed-img');
var thumbBar = document.querySelector('.thumb-bar');

var overlay = document.querySelector('.overlay');

/* Looping through images */
var names = ["To a very special Mum,","We wanted to do something different.","So this year (given the rationing of paper),","we thought we'd share the fond memories we have had together.","We have had some wonderful times with countless laughs.","We've been to places far and wide","but the best place is wherever you are.","Thank you for being the best mum in the world,","we love you 3000!","Happy Mothers Day!"];
var ages = ["2010","2011","2012","2013","2014","2015","2016","2017","2018","2019"]
var positions = ["Orlando","Lauterbrunnen","Majorca", "Los Angeles","Sienna","San Francisco","France","Riverton","Courchevel","Rome"];
 for(var i = 1; i <= 10; i++) {
  var newImage = document.createElement('img');
  newImage.setAttribute('src', 'mother' + i + '.jpg');
  thumbBar.appendChild(newImage);
  newImage.onclick = function(e) {
    var imgSrc = e.target.getAttribute('src');
    displayImage(imgSrc);
    var chosenImg=imgSrc;
    if (chosenImg=="mother1.jpg"){
      document.getElementById("name").innerHTML = " "+names[0];
      document.getElementById("age").innerHTML =  "Year: "+ages[0];
      document.getElementById("position").innerHTML = "Place: "+positions[0];
    }
    else if (chosenImg=="mother2.jpg"){
      document.getElementById("name").innerHTML = " "+names[1];
      document.getElementById("age").innerHTML =  "Year: "+ages[1];
      document.getElementById("position").innerHTML = "Place: "+positions[1];
    }
    else if (chosenImg=="mother3.jpg"){
      document.getElementById("name").innerHTML = " "+names[2];
      document.getElementById("age").innerHTML =  "Year: "+ages[2];
      document.getElementById("position").innerHTML = "Place: "+positions[2];
    }
    else if (chosenImg=="mother4.jpg"){
      document.getElementById("name").innerHTML = " "+names[3];
      document.getElementById("age").innerHTML =  "Year: "+ages[3];
      document.getElementById("position").innerHTML = "Place: "+positions[3];
    }
    else if (chosenImg=="mother5.jpg"){
      document.getElementById("name").innerHTML = " "+names[4];
      document.getElementById("age").innerHTML =  "Year: "+ages[4];
      document.getElementById("position").innerHTML = "Place: "+positions[4];
      }
    else if (chosenImg=="mother6.jpg"){
      document.getElementById("name").innerHTML = " "+names[5];
      document.getElementById("age").innerHTML =  "Year: "+ages[5];
      document.getElementById("position").innerHTML = "Place: "+positions[5];
    }
    else if (chosenImg=="mother7.jpg"){
      document.getElementById("name").innerHTML = " "+names[6];
      document.getElementById("age").innerHTML =  "Year: "+ages[6];
      document.getElementById("position").innerHTML = "Place: "+positions[6];
    }
    else if (chosenImg=="mother8.jpg"){
      document.getElementById("name").innerHTML = " "+names[7];
      document.getElementById("age").innerHTML =  "Year: "+ages[7];
      document.getElementById("position").innerHTML = "Place: "+positions[7];
    }
    else if (chosenImg=="mother9.jpg"){
      document.getElementById("name").innerHTML = " "+names[8];
      document.getElementById("age").innerHTML =  "Year: "+ages[8];
      document.getElementById("position").innerHTML = "Place: "+positions[8];
    }
    else if (chosenImg=="mother10.jpg"){
      document.getElementById("name").innerHTML = " "+names[9];
      document.getElementById("age").innerHTML =  "Year: "+ages[9];
      document.getElementById("position").innerHTML = "Place: "+positions[9];
    }
  }
}
  function displayImage(imgSrc) {
  displayedImage.setAttribute('src', imgSrc);
}


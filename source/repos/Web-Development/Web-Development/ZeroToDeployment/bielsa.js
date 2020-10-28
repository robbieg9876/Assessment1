var myHeading = document.querySelector('h1');
myHeading.textContent = 'Hello Premier league';
var myImage = document.querySelector('img');
myImage.onclick = function() {
    var mySrc = myImage.getAttribute('src');
    if(mySrc === 'bielsa.jpg') {
      myImage.setAttribute ('src','bielsa2.jpg');
    
    } 
    else {
      myImage.setAttribute ('src','bielsa.jpg');
     }
    }

var myButton = document.querySelector('button');
var myHeading = document.querySelector('h2');
function setTeam(){
	var myTeam= prompt('Please enter your team.');
	localStorage.setItem('team',myTeam);
	 myHeading.textContent = 'MOT';
 	if(!localStorage.getItem('team')){
 		setUserName();

  } else {
  	var storedT= localStorage.getItem('Team');
 myHeading.textContent=myTeam+' are going up!';
		}
}
myButton.onclick = function() {
  setTeam();
}
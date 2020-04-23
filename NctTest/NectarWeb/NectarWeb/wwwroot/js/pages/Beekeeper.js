function selectSwarm(divSwarm) {
  var images = document.getElementsByClassName('ioo-image');
  var middles = document.getElementsByClassName('ioo-middle');

  for (var i = 0; i < images.length; i++) {
    images[i].style.opacity = '1';
  }

  for (var i = 0; i < middles.length; i++) {
    middles[i].style.opacity = '0';
  }

  divSwarm.firstElementChild.style.opacity = '0.3';
  divSwarm.firstElementChild.nextElementSibling.style.opacity = "1"; 
}
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

function isChecked(element) {
    if (element.checked) {
        return true;
    }
    return false;
}

function checkSwarmTypeBeforeSubmit() {
    var errMsg = document.getElementById('swarmTypeErrorMsg');
    var swarmTypes = document.getElementsByName('course-radio-1');
    var hasSwarmType = false;
    for (i = 0; i < swarmTypes.length; i++) {
        if (swarmTypes[i].checked) {
            hasSwarmType = true;
        }
    }
    if (hasSwarmType) {
        errMsg.style.visibility = 'hidden';
    }
    else {
        errMsg.style.visibility = 'visible';
    }
}

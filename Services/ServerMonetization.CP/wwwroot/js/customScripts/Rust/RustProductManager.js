'use strict';

let panelTable = document.getElementById('panelTable');
panelTable.style.display = 'none';

function windowReadyHandler() {
    let spinner = document.getElementById('spinner');
    let panelTable = document.getElementById('panelTable');

    spinner.style.display = 'none';
    panelTable.style.display = 'block';
}

window.addEventListener("load", windowReadyHandler);
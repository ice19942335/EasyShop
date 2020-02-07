'use strict';

let tableWrap = document.getElementById('tableWrap');
let spinner = document.getElementById('spinner');

function windowReadyHandler() {
    spinner.style.display = 'none';
    tableWrap.style.display = 'block';
}

window.addEventListener("load", windowReadyHandler);
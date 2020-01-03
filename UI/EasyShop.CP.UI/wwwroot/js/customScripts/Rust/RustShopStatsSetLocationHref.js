'use strict';

document.getElementById('selectPeriod').addEventListener("change", setLocationHref);

function setLocationHref() {
    let selectBox = document.getElementById("selectPeriod");
    let selectedValue = selectBox.options[selectBox.selectedIndex].value;

    let url = new URL(window.location.href);
    let queryString = url.search;
    let searchParams = new URLSearchParams(queryString);

    searchParams.set('statsPeriod', selectedValue);
    url.search = searchParams.toString();

    let newUrl = url.toString();

    window.location.href = newUrl;
}
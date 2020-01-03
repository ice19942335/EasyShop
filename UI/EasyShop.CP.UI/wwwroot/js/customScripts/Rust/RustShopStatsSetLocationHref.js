'use strict';

document.getElementById('selectPeriod').addEventListener("change", setLocationHref);

function setLocationHref() {
    let selectBox = document.getElementById("selectPeriod");
    let selectedValue = selectBox.options[selectBox.selectedIndex].value;

    let url = new URL(window.location.href);
    let query_string = url.search;
    let search_params = new URLSearchParams(query_string);

    search_params.set('statsPeriod', selectedValue);
    url.search = search_params.toString();

    let new_url = url.toString();

    window.location.href = new_url;
}
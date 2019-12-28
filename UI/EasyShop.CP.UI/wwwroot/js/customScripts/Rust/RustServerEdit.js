'use strict';

document.getElementById('ShowInShop').addEventListener("click", rustShowInShop);

let showInShopToggle = document.getElementById('ShowInShop');
let editServerDiv = document.getElementById('EditServerDiv');

if (showInShopToggle.value.toLowerCase() === "true") {
    editServerDiv.style.display = 'block';
} else {
    editServerDiv.style.display = 'none';
}

function rustShowInShop(event) {
    let toggle = event.target;
    let editServerDiv = document.getElementById('EditServerDiv');
    if (toggle.value.toLowerCase() === "true") {
        toggle.value = "false";
        editServerDiv.style.display = 'none';
    } else {
        editServerDiv.style.display = 'block';
        toggle.value = "true";
    }
}
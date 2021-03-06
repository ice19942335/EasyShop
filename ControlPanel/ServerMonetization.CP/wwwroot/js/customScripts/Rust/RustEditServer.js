﻿'use strict';

document.getElementById('ShowInShop').addEventListener("click", rustShowInShop);
document.getElementById('IpAddressInput').addEventListener("input", checkInputMaskIp);
document.getElementById('PortInput').addEventListener("input", checkInputMaskPort);

// SaveChanges button Activate-Deactivate-------------------------------------
let saveBtn = document.getElementById('SaveBtn');

let ipInputValueCorrect = true;
let portInputValueCorrect = true;

function canSaveChanges() {
    if (ipInputValueCorrect === true && portInputValueCorrect === true) {
        saveBtn.removeAttribute("disabled");
    } else {
        saveBtn.setAttribute("disabled", "disabled");
    }
}
//-----------------------------------------------------------------------------

let showInShopToggle = document.getElementById('ShowInShop');
let overlayDiv = document.getElementsByClassName('form-overlay')[0];

if (showInShopToggle.value.toLowerCase() === "true") {
    overlayDiv.style.display = 'none';
} else {
    overlayDiv.style.display = 'block';
}

function rustShowInShop(event) {
    let toggle = event.target;
    let overlayDiv = document.getElementsByClassName('form-overlay')[0];
    if (toggle.value.toLowerCase() === "true") {
        toggle.value = "false";
        overlayDiv.style.display = 'block';
    } else {
        toggle.value = "true";
        overlayDiv.style.display = 'none';
    }
}

function checkInputMaskIp(event) {
    let input = event.target;
    let result = input.value.match(/^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$/);

    if (result === null) {
        input.classList.add("bg-danger");
        ipInputValueCorrect = false;
    } else {
        input.classList.remove("bg-danger");
        ipInputValueCorrect = true;
    }

    canSaveChanges();
}

function checkInputMaskPort(event) {
    let input = event.target;
    let result = input.value.match(/^[0-9]{5}$/);

    if (result === null) {
        input.classList.add("bg-danger");
        portInputValueCorrect = false;
    } else {
        input.classList.remove("bg-danger");
        portInputValueCorrect = true;
    }

    canSaveChanges();
}
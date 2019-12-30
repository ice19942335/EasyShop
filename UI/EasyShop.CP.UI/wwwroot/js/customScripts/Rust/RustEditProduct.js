'use strict';

document.getElementById('ShowInShop').addEventListener("click", rustShowInShop);
document.getElementById('demo-datepicker-2').addEventListener("input", checkInputMask);
document.getElementById('demo-datepicker-2-btn').addEventListener("click", clearBlockedTillInputInput);
document.getElementById('RustEditProductPriceInput').addEventListener("input", checkPriceInputIsCorrect);

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

function checkInputMask(event) {
    let input = event.target;
    let result = input.value.match(/^[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}$/);

    if (result === null) {
        input.classList.add("bg-danger");
    } else {
        input.classList.remove("bg-danger");
    }
}

function clearBlockedTillInputInput() {
    let input = document.getElementById('demo-datepicker-2');
    input.value = "";
    input.classList.remove("bg-danger");
}

function checkPriceInputIsCorrect(event) {
    let input = event.target;
    let result = input.value.match(/^[0-9]*\.[0-9]{2}$/);

    if (result === null) {
        input.classList.add("bg-danger");
        input.classList.remove("bg-success");
    } else {
        input.classList.remove("bg-danger");
        input.classList.add("bg-success");
    }
}
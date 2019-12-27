'use strict';

let rows = document.querySelectorAll('#Row');

for (let node of rows) {
    if (node.classList.contains('showProductInShop-false')) {
        node.style.filter = 'brightness(0.2)';
    }
}
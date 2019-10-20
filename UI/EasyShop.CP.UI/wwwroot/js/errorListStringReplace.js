'use strict';
substringReplace('User name', 'Email');

function substringReplace(sub, newSub) {
    let ul = document.querySelector('.stringReplace').children[0];

    for (let node of ul.children) {
        if (node !== undefined && node !== null) {
            if (node.textContent.includes(sub)) {
                node.textContent = node.textContent.replace(sub, newSub);
                break;
            }
        }
    }
}
'use strict';
substringReplace('User name', 'Email');

function substringReplace(sub, newSub) {
    let div = document.querySelector('.stringReplace');
    if (div !== null && div !== undefined) {
        let ul = div.children[0];
        console.log(ul);
        if (ul !== null && ul !== undefined) {
            for (let li of ul.children) {
                console.log(li);
                if (li.textContent.includes(sub)) {
                    li.textContent = li.textContent.replace(sub, newSub);
                }
            }
        }
    }
}



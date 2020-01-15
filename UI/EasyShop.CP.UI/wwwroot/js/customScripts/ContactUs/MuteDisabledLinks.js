'use strict';

let disabledLinks = document.querySelectorAll('.muted');

for (let item of disabledLinks) {
    item.addEventListener("click", () => {
        toastr.info('This option is still under development.');
    });
}


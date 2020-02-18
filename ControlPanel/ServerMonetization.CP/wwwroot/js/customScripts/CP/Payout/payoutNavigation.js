'use strict';

function payoutNavigationSetActiveLink() {
    let url = window.location.href;
    url = url.split('?')[0].split('/');
    let activeLinkId = `/${url[url.length - 2]}/${url[url.length - 1]}`;

    let linkNodes = document.querySelector('.payoutNavigationDiv');

    if (linkNodes !== null && linkNodes !== undefined) {
        for (let link of linkNodes.children) {
            if (link.pathname === activeLinkId) {
                link.classList.add('active');
                break;
            }
        }
    }
}

payoutNavigationSetActiveLink();
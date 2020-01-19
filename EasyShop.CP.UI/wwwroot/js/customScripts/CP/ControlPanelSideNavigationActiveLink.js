'use strict';
selectActiveSideBarNavLink();

function selectActiveSideBarNavLink() {
    let url = window.location.href;
    url = url.split('?')[0].split('/');
    let activeLinkId = `/${url[url.length - 2]}/${url[url.length - 1]}`;

    let navUl = document.getElementById('controlPanelSideNavigation');

    if (navUl !== null && navUl !== undefined) {
        for (let li of navUl.children) {
            if (li.children[0] !== null && li.children[0] !== undefined) {
                if (li.children[0].pathname === activeLinkId) {
                    li.classList.add('active');
                    break;
                }
            }
        }
    }
}
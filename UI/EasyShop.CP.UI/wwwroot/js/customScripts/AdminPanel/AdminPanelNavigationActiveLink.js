'use strict';

selectActiveSideNavigationLink();

function selectActiveSideNavigationLink() {
    let splittedUrl = window.location.href.split('?')[0].split('/');
    let activeLinkId = `/${splittedUrl[splittedUrl.length - 2]}/${splittedUrl[splittedUrl.length - 1]}`;

    let linkNodesWrap = document.getElementById('AdminNavigation');

    if (linkNodesWrap !== null && linkNodesWrap !== undefined) {
        for (let link of linkNodesWrap.children) {
            if (linkNodesWrap.children[0].classList.contains('index')) {
                linkNodesWrap.children[0].classList.add('active');
            }

            if (link.pathname === activeLinkId) {
                linkNodesWrap.children[0].classList.remove('active');
                link.classList.add('active');
                break;
            }
        }
    }
}
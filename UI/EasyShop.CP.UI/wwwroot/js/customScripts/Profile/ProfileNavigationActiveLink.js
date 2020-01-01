'use strict';

selectActiveSideNavigationLink();

function selectActiveSideNavigationLink() {
    let splittedUrl = window.location.href.split('?')[0].split('/');
    let activeLinkId = `/${splittedUrl[splittedUrl.length - 2]}/${splittedUrl[splittedUrl.length - 1]}`;
    console.log(activeLinkId);
    console.log(splittedUrl);

    let linkNodesWrap = document.getElementById('profileNavigation');

    if (linkNodesWrap !== null && linkNodesWrap !== undefined) {
        for (let link of linkNodesWrap.children) {
            if (link.pathname === activeLinkId) {
                link.classList.add('active');
                break;
            }
        }
    }
}
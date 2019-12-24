'use strict';
selectActiveTopNavLink();
selectActiveSideBarNavLink();

function selectActiveTopNavLink() {

    let url = window.location.href;
    url = url.split('?')[0].split('/');
    let activeLinkId = `/${url[url.length - 2]}/${url[url.length - 1]}`;

    let ulNodes = document.querySelector('.profile-nav').children;

    const setDefaultActiveLink = () => {
        ulNodes[1].children[0].id = "shopSettingsActiveItem";
    }

    for (let nodeLi of ulNodes) {
        if (nodeLi.children[0].pathname === activeLinkId) {
            nodeLi.children[0].id = "shopSettingsActiveItem";
            break;
        } else {
            setDefaultActiveLink();
        }
    }
}

function selectActiveSideBarNavLink() {
    let url = window.location.href;
    url = url.split('?')[0].split('/');
    let activeLinkId = `/${url[url.length - 2]}/${url[url.length - 1]}`;

    let linkNodes = document.querySelector('.shopManagerSideNavigation');

    if (linkNodes !== null && linkNodes !== undefined) {
        for (let link of linkNodes.children) {
            if (link.pathname === activeLinkId) {
                link.classList.add('active');
                break;
            }
        }
    }
}
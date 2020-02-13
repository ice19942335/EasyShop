'use strict';

class BodySpinner {
    constructor() {
        this.spinner = document.getElementById('spinner');
        this.mainLayout = document.getElementById('main-layout');

        this.windowReadyHandler = this.windowReadyHandler.bind(this);
    }
    init() {
        window.addEventListener('load', this.windowReadyHandler)
    }
    windowReadyHandler() {
        this.spinner.style.display = 'none';
        this.mainLayout.style.display = 'block';
    }
}

function initialize() {
    const bodySpinner = new BodySpinner();
    bodySpinner.init();
}

initialize();
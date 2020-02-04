'use strict';

class DynamicCategories {
    constructor() {
        this.allProductsNodes = [];
        this.substringFilterValue = '';
        this.selectedCategoryId = '';

        this.clickOnCategoryHandler = this.clickOnCategoryHandler.bind(this);
        this.inputSearchFieldHandler = this.inputSearchFieldHandler.bind(this);
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
    }
    initializeVariables() {
        this.allProductsNodes = document.querySelectorAll('.product');
    }
    setEventHandlers() {
        const categories = document.querySelectorAll('.ctegory-btn');

        for (const category of categories) {
            category.addEventListener('click', this.clickOnCategoryHandler);
        }

        document.getElementById('search-input').addEventListener('input', this.inputSearchFieldHandler);
    }
    clickOnCategoryHandler(event) {
        if (event.target.dataset.categoryId !== undefined) {
            this.selectedCategoryId = event.target.dataset.categoryId;
            this.renderProductsList();
        }
    }
    inputSearchFieldHandler(event) {
        this.substringFilterValue = event.target.value;

        this.renderProductsList();
    }
    renderProductsList() {
        for (const product of this.allProductsNodes) {
            let productCategoryId = product.dataset.categoryId;
            let productName = product.dataset.productName;

            if (this.selectedCategoryId.toLowerCase() === 'all'.toLowerCase()) {
                product.style.display = 'block';
            } else if (this.selectedCategoryId === productCategoryId && productName.includes(this.substringFilterValue)) {
                product.style.display = 'block';
            } else {
                product.style.display = 'none';
            }
        }
    }
}

class BuyModal {
    constructor() {
        this.allProductsNodes = [];

        this.modalCloseButtons = [];
        this.modal = undefined;
        this.modalContentCustom = undefined;
        this.modalBg = undefined;
        this.body = undefined;
        this.products = undefined;
        this.byuModalProductTitle = undefined;
        this.byuModalProductImg = undefined;
        this.productDescription = undefined;
        this.modalTotalToPay = undefined;
        this.modalItemsToBuy = undefined;
        this.itemToBuyPrice = 0;

        this.clickOnProductHandler = this.clickOnProductHandler.bind(this);
        this.closeModalHandler = this.closeModalHandler.bind(this);
        this.clickOnModalHandler = this.clickOnModalHandler.bind(this);
        this.clickOnDecrementHandler = this.clickOnDecrementHandler.bind(this);
        this.clickOnIncrementHandler = this.clickOnIncrementHandler.bind(this);
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
    }
    initializeVariables() {
        this.allProductsNodes = document.querySelectorAll('.product');
        this.modalCloseButtons = document.querySelectorAll('[data-dismiss="modal"]');
        this.modal = document.getElementById('buy-modal');
        this.modalBg = document.getElementById('buy-modal-bg');
        this.byuModalProductTitle = document.getElementById('byu-modal-product-title');
        this.byuModalProductImg = document.getElementById('byu-modal-product-img');

        this.modalTotalToPay = document.getElementById('modal-total-to-pay');
        this.modalItemsToBuy = document.getElementById('modal-items-to-buy');
        this.productDescription = document.getElementById('product-description');
    }
    setEventHandlers() {
        for (const product of this.allProductsNodes) {
            product.addEventListener('click', this.clickOnProductHandler);
        }

        for (const product of this.modalCloseButtons) {
            product.addEventListener('click', this.closeModalHandler);
        }

        this.modal.addEventListener('click', this.clickOnModalHandler);

        document.getElementById('modal-decrement').addEventListener('click', this.clickOnDecrementHandler);
        document.getElementById('modal-increment').addEventListener('click', this.clickOnIncrementHandler);
    }
    clickOnDecrementHandler() {
        const itemsToBuy = +this.modalItemsToBuy.value;
        const itemsToBuyResult = itemsToBuy - 1;

        if (itemsToBuyResult < 1) return;

        this.modalItemsToBuy.value = itemsToBuyResult;
        this.modalTotalToPay.value = `${(itemsToBuyResult * this.itemToBuyPrice).toFixed(2)}`;
    }
    clickOnIncrementHandler() {
        const itemsToBuy = +this.modalItemsToBuy.value;
        const itemsToBuyResult = itemsToBuy + 1;

        this.modalItemsToBuy.value = itemsToBuyResult;
        this.modalTotalToPay.value = `${(itemsToBuyResult * this.itemToBuyPrice).toFixed(2)}`;
    }
    closeModalHandler() {
        this.closeModal();
    }
    clickOnProductHandler(event) {
        let product = undefined;

        if (event.path[5].dataset.productId !== undefined) {
            product = event.path[5];
        } else if (event.path[4].dataset.productId !== undefined) {
            product = event.path[4];
        } else if (event.path[3].dataset.productId !== undefined) {
            product = event.path[3];
        } else if (event.path[2].dataset.productId !== undefined) {
            product = event.path[2];
        } else if (event.path[1].dataset.productId !== undefined) {
            product = event.path[1];
        } else if (event.path[0].dataset.productId !== undefined) {
            product = event.path[0];
        }

        this.showModal(product);
    }
    clickOnModalHandler(event) {
        if (event.target.id === 'buy-modal') {
            this.closeModal();
        }
    }
    showModal(product) {
        this.modal.style.display = 'block';
        this.modalBg.style.display = 'block';

        this.setModalDataOnFirstShow(product);
    }
    closeModal() {
        this.modal.style.display = 'none';
        this.modalBg.style.display = 'none';
    }
    setModalDataOnFirstShow(product) {
        this.itemToBuyPrice = +product.dataset.productPriceAfterDiscount;
        this.byuModalProductTitle.innerText = product.dataset.productName;
        this.byuModalProductImg.src = product.dataset.productImgUrl;
        this.modalItemsToBuy.value = '1';
        this.modalTotalToPay.value = product.dataset.productPriceAfterDiscount;
        this.productDescription.innerText = '';

        if (product.dataset.productDescription !== undefined) {
            let description = product.dataset.productDescription;
            description = description.replace(/_/gi, ' ');
            description = description.replace(/^"|"$/gi, '');

            this.productDescription.innerText = description;
        }

    }
}

function initialize() {
    const dynamicCategories = new DynamicCategories();
    dynamicCategories.init();

    const buyModal = new BuyModal();
    buyModal.init();
}

initialize();
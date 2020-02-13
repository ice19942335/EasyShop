'use strict';

class DynamicCategories {
    constructor() {
        this.allProductsNodes = [];
        this.categories = [];
        this.substringFilterValue = '';
        this.selectedCategoryId = undefined;

        this.searchInput = undefined;

        this.clickOnCategoryHandler = this.clickOnCategoryHandler.bind(this);
        this.inputSearchFieldHandler = this.inputSearchFieldHandler.bind(this);
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
        this.renderProductsList();
    }
    initializeVariables() {
        this.categories = document.querySelectorAll('.ctegory-btn');
        this.allProductsNodes = document.querySelectorAll('.product');
        this.searchInput = document.getElementById('search-input');
    }
    setEventHandlers() {
        for (const category of this.categories) {
            category.addEventListener('click', this.clickOnCategoryHandler);
        }

        this.searchInput.addEventListener('input', this.inputSearchFieldHandler);
    }
    clickOnCategoryHandler(event) {
        this.searchInput.value = '';
        this.substringFilterValue = '';

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

            if (this.selectedCategoryId === 'all' || this.selectedCategoryId === undefined) {
                if (productName.toLowerCase().includes(this.substringFilterValue.toLowerCase())) {
                    product.style.display = 'block';
                } else {
                    product.style.display = 'none';
                }
            } else {
                if (this.selectedCategoryId === productCategoryId && productName.toLowerCase().includes(this.substringFilterValue.toLowerCase())) {
                    product.style.display = 'block';
                } else {
                    product.style.display = 'none';
                }
            }

            if (product.dataset.blocked !== undefined) {
                product.style.backgroundColor = "rgba(119,119,119,0.6)";
            }
        }

        this.renderSideMenu();
    }
    renderSideMenu() {
        for (const btn of this.categories) {
            if (btn.dataset.categoryId === this.selectedCategoryId) {
                btn.style.backgroundColor = 'gray';
                btn.style.borderColor = 'gray';
            } else {
                btn.style.backgroundColor = '#d9230f';
                btn.style.borderColor = '#d9230f';
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
        this.productIdHidden;

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

        this.productIdHidden = document.getElementById('product-id');
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

        if (product.dataset.blocked !== undefined) {
            return;
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
        this.productIdHidden.value = product.dataset.productId;

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
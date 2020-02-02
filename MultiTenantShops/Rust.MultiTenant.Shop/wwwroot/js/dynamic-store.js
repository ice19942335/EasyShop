'use strict';

class DynamicStore {
    constructor() {
        this.allProductsNodes = [];
        this.showCategoriesState = [];
        this.substringFilterValue = '';

        this.modalCloseButtons = [];
        this.modal = undefined;
        this.modalContentCustom = undefined;
        this.modalBg = undefined;
        this.body = undefined;
        this.products = undefined;

        this.clickOnCategoryHandler = this.clickOnCategoryHandler.bind(this);
        this.inputSearchFieldHandler = this.inputSearchFieldHandler.bind(this);
        this.clickOnProductHandler = this.clickOnProductHandler.bind(this);
        this.closeModalHandler = this.closeModalHandler.bind(this);
        this.clickOnModalHandler = this.clickOnModalHandler.bind(this);
        this.onScrollHandler = this.onScrollHandler.bind(this);
        
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
    }
    initializeVariables() {
        this.showCategoriesState = this.setDefaultShowCategoriesState();
        this.allProductsNodes = this.GetAllProductNodes();
        this.modal = document.getElementById('customModal');
        this.modalContentCustomdocument = document.querySelector('.modal-content-custom');
        this.modalCloseButtons = document.querySelectorAll('[data-dismiss="modal"]');
        this.modalBg = document.getElementById('modalBg');
    }
    setDefaultShowCategoriesState() {
        const categories = document.querySelectorAll('.ctegory');
        const categoriesIds = [];

        for (const node of categories) {
            categoriesIds.push({
                categoryId: node.children[0].dataset.categoryId,
                show: true
            });
        }

        return categoriesIds;
    }
    GetAllProductNodes() {
        return document.querySelectorAll('.product');
    }
    setEventHandlers() {
        const categories = document.querySelectorAll('.ctegory');

        for (const category of categories) {
            category.addEventListener('click', this.clickOnCategoryHandler);
        }

        for (const product of this.allProductsNodes) {
            product.addEventListener('click', this.clickOnProductHandler);
        }

        for (const product of this.modalCloseButtons) {
            product.addEventListener('click', this.closeModalHandler);
        }

        document.getElementById('searchInput').addEventListener('input', this.inputSearchFieldHandler);

        this.modal.addEventListener('click', this.clickOnModalHandler);

        document.documentElement.addEventListener('onscroll', this.onScrollHandler)
    }
    onScrollHandler() {
        console.log(document.documentElement.scrollTop);
    }
    closeModalHandler() {
        this.closeModal();
    }
    clickOnProductHandler(event) {
        

        let product = undefined;

        if (event.path[4].dataset.productId !== undefined) {
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

        this.showModal(product,);
    }
    clickOnCategoryHandler(event) {
        if (event.target.dataset.categoryId !== undefined) {
            const categoryId = event.target.dataset.categoryId;

            let categoryState = this.showCategoriesState.find((item) => {
                if (item.categoryId === categoryId) {
                    return true;
                } else {
                    return false;
                }
            });

            if (event.target.checked) {
                categoryState.show = true;
            } else {
                categoryState.show = false;
            }

            this.render();
        }
    }
    inputSearchFieldHandler(event) {
        this.substringFilterValue = event.target.value;

        this.render();
    }
    clickOnModalHandler(event){
        if (event.target.id === 'customModal') {
            this.closeModal();
        }
    }
    showModal(product) {
        console.log(document.documentElement.scrollTop)
        this.modal.style.display = 'block';
        this.modalBg.style.display = 'block';
    }
    closeModal() {
        this.modal.style.display = 'none';
        this.modalBg.style.display = 'none';
    }
    render() {
        for (const product of this.allProductsNodes) {
            let productCategoryId = product.dataset.categoryId;
            let productName = product.dataset.productName;

            let categoryState = this.showCategoriesState.find((item) => {
                if (item.categoryId === productCategoryId) {
                    return true;
                } else {
                    return false;
                }
            });

            if (categoryState.show === true && productName.includes(this.substringFilterValue)) {
                product.style.display = 'block';
            } else {
                product.style.display = 'none';
            }
        }
    }
}

class CustomModal {
    constructor() {

    }
    init() {

    }
}

function initialize() {
    const dynamicStore = new DynamicStore();
    dynamicStore.init();

    const customModal = new CustomModal();
    customModal.init();
}

initialize();
'use strict';

class DynamicStore {
    constructor() {
        this.allProductsNodes = [];
        this.showCategoriesState = [];
        this.substringFilterValue = '';

        this.clickOnCategoryHandler = this.clickOnCategoryHandler.bind(this);
        this.inputSearchFieldHandler = this.inputSearchFieldHandler.bind(this);
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
    }
    initializeVariables() {
        this.showCategoriesState = this.setDefaultShowCategoriesState();
        this.allProductsNodes = this.GetAllProductNodes();
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
            category.addEventListener('click', this.clickOnCategoryHandler)
        }

        document.getElementById('searchInput').addEventListener('input', this.inputSearchFieldHandler)
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
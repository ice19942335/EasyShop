'use strict';

class DynamicStore {
    constructor() {
        this.allProductsNodes = [];
        this.filteredProductsNodes = [];
        this.showCategoriesState = [];
        this.substringFilterValue = '';

        this.clickOnCategoryHandler = this.clickOnCategoryHandler.bind(this);
    }
    init() {
        this.initializeVariables();
        this.setEventHandlers();
    }
    initializeVariables() {
        this.showCategoriesState = this.setDefaultShowCategoriesState();
        this.allProductsNodes = this.GetAllProductNodes();

        console.log(this.showCategoriesState);
    }
    setDefaultShowCategoriesState() {
        const categories = document.querySelectorAll('.ctegory');
        const categoriesIds = [];

        for (const node of categories) {
            categoriesIds.push({
                categoryId: node.children[0].dataset.categoryid,
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
    }
    clickOnCategoryHandler(event) {
        if (event.target.dataset.categoryid !== undefined) {
            const categoryId = event.target.dataset.categoryid;

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
    render() {
        for (const product of this.allProductsNodes) {
            let productCategoryId = product.dataset.categoryid;
            
            let categoryState = this.showCategoriesState.find((item) => {
                if (item.categoryId === productCategoryId) {
                    return true;
                } else {
                    return false;
                }
            });

            if(categoryState.show === true){
                product.style.display = 'block';
            } else {
                product.style.display = 'none';
            }
        }
    }
}

function initialize() {
    const dynamicStore = new DynamicStore();
    dynamicStore.init();
}

initialize();
'use strict'

class RustProduct {
    constructor() {
        this.discountInput;
        this.afterDiscountInput;
        this.rustProductPriceInput;

        this.curency = '$';

        this.discountInputEventHandler = this.discountInputEventHandler.bind(this);

        this.init();
    }
    init() {
        this.setVariables();
        this.setEventHandlers();

        this.render();
    }
    setVariables() {
        this.discountInput = document.getElementById('discount');
        this.afterDiscountInput = document.getElementById('afterDiscount');
        this.rustProductPriceInput = document.getElementById('RustEditProductPriceInput');
    }
    setEventHandlers() {
        this.discountInput.addEventListener('input', this.discountInputEventHandler);
    }
    discountInputEventHandler(event) {
        const value = event.target.value;
        console.log(value);

        if (value < 0 || value > 100) {
            toastr.error(`Discount can't be less than 0 percent or more than 100 percent.`);
        }

        this.render();
    }
    render() {
        if (this.discountInput.value < 0 || this.discountInput.value > 100) {
            this.afterDiscountInput.value = this.curency;
        } else {
            const percentResult = ((this.rustProductPriceInput.value / 100) * this.discountInput.value);
            const result = this.rustProductPriceInput.value - percentResult;
            this.afterDiscountInput.value = this.curency + ' ' + result.toFixed(2);
        }
    }
}

const rustProduct = new RustProduct();
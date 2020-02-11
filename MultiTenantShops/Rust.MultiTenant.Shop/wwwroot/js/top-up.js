'use strict';

class TopUpForm {
    constructor() {
        this.topUpBtn;

        this.dollarsInput;
        this.dollarsInputValue;

        this.topUpResult;
        this.topUpResultHiden;

        this.centsInput;
        this.centsInputValue;

        this.agree;

        this.dollarsInputEventHandler = this.dollarsInputEventHandler.bind(this);
        this.centsInputEventHandler = this.centsInputEventHandler.bind(this);
        this.agreeClickEventHandler = this.agreeClickEventHandler.bind(this);
    }
    init() {
        this.setVariables();
        this.setEventListeners();
    }
    setVariables() {
        this.topUpBtn = document.getElementById('top-up-btn');
        this.dollarsInput = document.getElementById('dollars-input');
        this.centsInput = document.getElementById('cents-input');
        this.topUpResult = document.getElementById('topup-result');
        this.agree = document.getElementById('agree');
        this.topUpResultHiden = document.getElementById('topup-result-hiden');

        this.dollarsInputValue = this.dollarsInput.value;
        this.centsInputValue = this.centsInput.value;
    }
    setEventListeners() {
        this.dollarsInput.addEventListener('input', this.dollarsInputEventHandler);
        this.centsInput.addEventListener('input', this.centsInputEventHandler);
        this.agree.addEventListener('click', this.agreeClickEventHandler);
    }
    dollarsInputEventHandler() {
        const max = this.dollarsInput.getAttribute("max");

        if (this.dollarsInput.value.length > max.length) {
            this.dollarsInput.value = this.dollarsInputValue;
            toastr.warning(`Please enter correct numbers`);
        }

        if (+this.dollarsInput.value > +max) {
            toastr.warning(`Max value for this field is: ${max}`);
            this.dollarsInput.value = this.dollarsInputValue;
        }

        if(+this.dollarsInput.value === 0) {
            //this.dollarsInput.value = this.dollarsInputValue;
            toastr.warning(`Minimum value is:  $1.00`); 
        }

        let parsedValue = parseInt(this.dollarsInput.value, 10);

        this.dollarsInputValue = parsedValue;

        this.render();
    }
    centsInputEventHandler() {
        if (this.centsInput.value.length > 2) {
            this.centsInput.value = this.centsInputValue;
        }

        this.centsInputValue = this.centsInput.value;

        this.render();
    }
    agreeClickEventHandler() {
        this.render();  
    }
    switchOnButton() {
        this.topUpBtn.removeAttribute('disabled');
    }
    switchOffButton() {
        this.topUpBtn.setAttribute('disabled', 'disabled');
    }
    render() {
        if (this.centsInputValue !== '' && this.dollarsInputValue !== '' && !isNaN(this.centsInputValue) && !isNaN(this.dollarsInputValue)) {
            this.switchOnButton();

            if (this.centsInputValue.length === 1) {
                this.centsInputValue += '0';
            }

            
            const topUpResultValue = `${this.dollarsInputValue}.${(this.centsInputValue)}`;
            this.topUpResultHiden.value = topUpResultValue;
            this.topUpResult.value = topUpResultValue;

            if (this.agree.checked !== true) {
                this.switchOffButton();
            } else {
                this.switchOnButton();
            }
            
        } else {
            this.switchOffButton();
            this.topUpResult.value = '';
        }
    }
}

function initialize() {
    const topUpForm = new TopUpForm();
    topUpForm.init();
}

initialize();
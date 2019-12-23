'use strict';

window.onload = function () {
    document.getElementById("password").oninput = function fun(event) {
        let formChildren = event.target.form.children;
        let passInput1 = document.getElementById("password");
        let passInput2 = document.getElementById("confirmPassword");

        if (passInput1.value !== passInput2.value) {
            passInput1.classList.add("bg-danger");
            passInput2.classList.add("bg-danger");
        } else {
            passInput1.classList.remove("bg-danger");
            passInput2.classList.remove("bg-danger");
        }
    }

    document.getElementById("confirmPassword").oninput = function fun(event) {
        let formChildren = event.target.form.children;
        let passInput1 = document.getElementById("password");
        let passInput2 = document.getElementById("confirmPassword");

        if (passInput1.value !== passInput2.value) {
            passInput1.classList.add("bg-danger");
            passInput2.classList.add("bg-danger");
        } else {
            passInput1.classList.remove("bg-danger");
            passInput2.classList.remove("bg-danger");
        }
    }
}
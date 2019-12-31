'use strict';

document.getElementById('password').addEventListener("input", canPresRegisterButton);
document.getElementById('confirmPassword').addEventListener("input", canPresRegisterButton);

let passInput1 = document.getElementById("password");
let passInput2 = document.getElementById("confirmPassword");

let passwordsHaveToBeTheSameDiv = document.getElementById('PasswordsHaveToBeTheSame');
let registerButton = document.getElementById('register');

function canPresRegisterButton() {
    if (passInput1.value !== passInput2.value) {
        passInput1.classList.add('bg-danger');
        passInput2.classList.add('bg-danger');
        registerButton.setAttribute("disabled", "disabled");
        passwordsHaveToBeTheSameDiv.style.display = 'block';
    } else if (passInput1.value === passInput2.value) {
        passInput1.classList.remove('bg-danger');
        passInput2.classList.remove('bg-danger');
        registerButton.removeAttribute("disabled");
        passwordsHaveToBeTheSameDiv.style.display = 'none';
    }
}
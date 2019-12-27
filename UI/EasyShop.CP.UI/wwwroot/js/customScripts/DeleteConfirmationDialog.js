'use strict';

function deleteConfirmationDialog(id, isDeleteClicked) {
    let deleteButton = 'confirmButton_' + id;
    let confirmDeleteSpan = 'confirmSpan_' + id;

    if (isDeleteClicked) {
        $('#' + deleteButton).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteButton).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
function deleteConfirmationDialog(id, isDeleteClicked) {
    let deleteButton = 'deleteButton_' + id;
    let confirmDeleteSpan = 'confirmDeleteSpan_' + id;

    if (isDeleteClicked) {
        $('#' + deleteButton).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteButton).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
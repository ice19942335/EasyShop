function deleteConfirmationDialog(shopId, isDeleteClicked) {
    let deleteButton = 'deleteButton_' + shopId;
    let confirmDeleteSpan = 'confirmDeleteSpan_' + shopId;

    if (isDeleteClicked) {
        $('#' + deleteButton).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteButton).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
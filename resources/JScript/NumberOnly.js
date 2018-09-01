function numbersonly(evt) {
    debugger;
    var charCode = (evt.fwhich) ? evt.which : event.keyCode;
    if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
        return false;

    return true;
}




function confirmationDelete() {
    if (confirm('Are you sure you want to delete ?')) {
        return true;
    } else {
        return false;
    }
}



function confirmationSubmit() {
    if (confirm('Are you sure you want to submit ?')) {
        return true;
    } else {
        return false;
    }
}

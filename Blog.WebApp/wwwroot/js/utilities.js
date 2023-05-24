function isValidEmail(email) {
    var regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}

function isValidPhoneNumber(phoneNumber) {
    var regex = /^(0\d{9,10})$/;
    return regex.test(phoneNumber);
}
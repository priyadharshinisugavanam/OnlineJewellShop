var isPasswordValid = false;
function ValidatePassword() {
    var cardnum = document.getElementById("Password").value;
    var regex = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9])(?!.*\s).{8,15}$/;
    var number = regex.test(cardnum);

    if (number) {
        document.getElementById("Valid").style.display = "none";
        isPasswordValid = true;
    }
    else {
        document.getElementById("Valid").style.display = "block"
        isPasswordValid = false;
    }
}

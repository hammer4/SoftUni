function simpleEmailValidation([email]) {
    let regex = /^[A-Za-z0-9]+@[a-z]+.[a-z]+$/;
    if(regex.test(email)) {
        console.log("Valid");
    } else {
        console.log("Invalid");
    }
}

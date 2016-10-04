function formFiller(input) {
    let username = input.shift();
    let email = input.shift();
    let phone = input.shift();
    let form = input;

    for(let line of form) {
        console.log(line.replace(/<![A-Za-z]+!>/g, username).replace(/<@[A-Za-z]+@>/g, email).replace(/<\+[A-Za-z]+\+>/g, phone));
    }
}

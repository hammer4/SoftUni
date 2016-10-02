function printEveryNthElementFromAnArray(input) {
    let step = Number(input.pop());

    input.filter((element, index) => index % step == 0).forEach(element => console.log(element));
}

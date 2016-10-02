function processOddNumbers(arr) {
    arr = arr.map(Number);

    console.log(arr.filter((num, index) => index % 2 == 1).map(num => num * 2).reverse().join(" "));
}

function binaryLogarithm(arr) {
    arr = arr.map(Number);

    for(let number of arr) {
        console.log(Math.log2(number))
    }
}
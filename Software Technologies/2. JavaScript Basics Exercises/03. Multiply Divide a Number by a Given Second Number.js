function multiplyOrDivideTwoNumbers(arr) {
    let n = Number(arr[0]);
    let x = Number(arr[1]);

    if(n > x) {
        console.log(n / x);
    } else {
        console.log(n * x);
    }
}
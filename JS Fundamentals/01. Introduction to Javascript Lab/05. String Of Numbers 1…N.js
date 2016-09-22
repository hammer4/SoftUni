function stringOfNumbers1ToN(arr) {
    let lastNum = Number(arr[0]);
    let result = '';
    for(let i = 1; i<= lastNum; i++) {
        result += i;
    }

    console.log(result);
}
;
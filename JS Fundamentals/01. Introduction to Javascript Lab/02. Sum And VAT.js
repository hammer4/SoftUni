function calculateSumAndVAT(arr) {
    let sum = 0;

    for(let price of arr) {
        sum += Number(price);
    }

    console.log(`sum = ${sum}`);
    console.log(`VAT = ${sum * 0.2}`);
    console.log(`total = ${sum * 1.2}`);
}

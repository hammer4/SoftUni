function primeNumberChecker([number]) {
    number = Number(number);

    let isPrime = true;

    for(let i=2; i<=Math.sqrt(number); i++) {
        if(number % i == 0) {
            isPrime = false;
        }
    }

    return isPrime && number > 1;
}

console.log(primeNumberChecker(['4']));
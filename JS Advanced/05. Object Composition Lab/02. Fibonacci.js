function fibonaci(count) {
    let fib = (() => {
        let f0=0, f1=1;
        return () => {
            let oldf0 = f0, oldf1 = f1;
            f0 = oldf1;
            f1 = oldf0 + oldf1;
            return oldf1;
        }
    })();

    let fibNumbers = [];
    for(let i=1; i<=count; i++){
        fibNumbers.push(fib());
    }

    return fibNumbers;
}

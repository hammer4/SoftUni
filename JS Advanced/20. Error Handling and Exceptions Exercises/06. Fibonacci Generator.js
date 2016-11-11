function* fibonacciGenerator() {
    let current = 1;
    let next = 1;

    while(true){
        yield current;
        [current, next] = [next, current+next];
    }
}


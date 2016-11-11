function* randomGenerator(seed) {
    let number = seed;
    number = Math.pow(number, 2)%(4871 * 7919);

    while (true) {
        yield number % 100;
        number = Math.pow(number, 2)%(4871 * 7919);
    }
}


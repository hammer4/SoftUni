function rectangleOfStars([count = 5]) {
    count = Number(count);

    function printStars(number = count) {
        console.log('*' + ' *'.repeat(number - 1));
    }

    for(let i = 0; i<count; i++) {
        printStars();
    }
}

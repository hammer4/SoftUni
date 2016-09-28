function triangleOfStars([count]) {
    count = Number(count);

    for(let i=1; i<=count; i++) {
        printStars(i);
    }

    for(let i=count-1; i>=1; i--) {
        printStars(i);
    }

    function printStars(number) {
        console.log('*'.repeat(number));
    }
}

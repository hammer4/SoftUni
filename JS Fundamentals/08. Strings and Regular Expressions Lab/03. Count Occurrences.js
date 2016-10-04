function countOccurences([str, text]) {
    let count = 0;
    let index = 0;
    while(text.indexOf(str, index) > -1) {
        count++;
        index = text.indexOf(str, index) + 1;
    }

    console.log(count);
}

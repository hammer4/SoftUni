function matchTheDates(input) {
    let regex = /\b(\d{1,2})-([A-Z]{1}[a-z]{2})-(\d{4}\b)/g;
    let validDates =[];
    for(let sentence of input) {
        while(match = regex.exec(sentence)) {
            console.log(`${match[0]} (Day: ${match[1]}, Month: ${match[2]}, Year: ${match[3]})`);
        }
    }
}

function printLines(arr) {
    for(let line of arr) {
        if(line == "Stop") {
            return;
        }

        console.log(line);
    }
}
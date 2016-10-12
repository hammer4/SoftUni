function ewoksFans(input) {
    let ewoksFans = [];
    let ewoksHaters = [];

    for(let dateString of input){
        let tokens = dateString.split(".").map(Number);
        let day = tokens[0];
        let month = tokens[1];
        let year = tokens[2];

        if(day == 1 && month == 1 && year == 1900){
            continue;
        }

        if(year >= 1900 && year < 2015){
            let date = new Date(year, month-1, day);
            let movieStart = new Date(1973, 4, 25);

            if(date < movieStart){
                ewoksHaters.push(date);
            } else {
                ewoksFans.push(date);
            }
        }
    }

    let hatersSorted = ewoksHaters.sort((a, b) => a - b);
    let fansSorted = ewoksFans.sort((a, b) => b - a);

    if(fansSorted.length == 0 && hatersSorted.length == 0){
        console.log("No result");
        return;
    }
    if(fansSorted.length > 0) {
        console.log(`The biggest fan of ewoks was born on ${fansSorted[0].toDateString()}`)
    }
    if(hatersSorted.length > 0){
        console.log(`The biggest hater of ewoks was born on ${hatersSorted[0].toDateString()}`)
    }
}

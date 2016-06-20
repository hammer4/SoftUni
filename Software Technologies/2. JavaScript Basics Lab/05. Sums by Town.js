function sumsByTown(arr) {
    let sums = {};
    for(let i=0; i<arr.length; i++) {
        var obj = JSON.parse(arr[i]);
        if (sums.hasOwnProperty(obj.town)) {
            sums[obj.town] += obj.income;
        }
        else {
            sums[obj.town] = obj.income;
        }
    }

    let towns = Object.keys(sums).sort();

    for(let town of towns) {
        console.log(`${town} -> ${sums[town]}`);
    }
}

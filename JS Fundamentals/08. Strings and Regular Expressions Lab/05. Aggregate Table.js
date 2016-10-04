function aggregateTable(input) {
    let towns =[];
    let sum = 0;

    for(let line of input) {
        let tokens = line.split('|').filter(token => token != '');
        let town = tokens[0].trim();
        let value = Number(tokens[1].trim());
        towns.push(town);
        sum += value;
    }

    console.log(towns.join(", "));
    console.log(sum);
}

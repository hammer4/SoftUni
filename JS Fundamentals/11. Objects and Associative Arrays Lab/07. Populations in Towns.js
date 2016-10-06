function populationsInTowns(input) {
    let map = new Map();

    for(let line of input) {
        let tokens = line.split(/\s+<->\s+/);
        let town = tokens[0];
        let population = Number(tokens[1]);

        if(! map.has(town)) {
            map.set(town, 0);
        }

        map.set(town, map.get(town) + population);
    }

    for(let city of map){
        console.log(`${city[0]} : ${city[1]}`)
    }
}

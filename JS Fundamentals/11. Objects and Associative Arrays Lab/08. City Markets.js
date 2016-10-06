function cityMarkets(input) {
    let map = new Map();

    for(let line of input) {
        let townTokens = line.split(/\s+->\s+/);
        let town = townTokens[0];
        let product = townTokens[1];
        let income = townTokens[2].split(/\s+:\s+/).map(Number).reduce((a, b) => a *b);

        if(! map.has(town)) {
            map.set(town, new Map());
        }
        if(! map.get(town).has(product)) {
            map.get(town).set(product, 0);
        }
        map.get(town).set(product, map.get(town).get(product) + income);
    }

    for(let [town, product] of map) {
        console.log(`Town - ${town}`);

        for(let [product, income] of map.get(town)) {
            console.log(`$$$${product} : ${income}`);
        }
    }
}

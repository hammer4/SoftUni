function storeCatalogue(input) {
    let map = new Map();

    for(let line of input){
        let tokens = line.split(" : ");
        let product = tokens[0];
        let price = tokens[1];
        map.set(product, price);
    }

    let initials = new Set();
    Array.from(map.keys()).forEach(k => initials.add(k[0]));


    for(let char of Array.from(initials.keys()).sort()) {
        console.log(char);

        for(let product of Array.from(map.keys()).sort()){
            if(product.startsWith(char)) {
                console.log(`  ${product}: ${map.get(product)}`);
            }
        }
    }
}

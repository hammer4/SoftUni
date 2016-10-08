function cappyJuice(input) {
    let quantities = {};
    let bottles = {};

    for(let line of input) {
        let tokens = line.split(" => ");
        let fruit = tokens[0];
        let quantity = Number(tokens[1]);

        if(! quantities.hasOwnProperty(fruit)) {
            quantities[fruit] = 0;
        }

        quantities[fruit] += quantity;
        if(quantities[fruit] >= 1000) {
            bottles[fruit] = parseInt(quantities[fruit]/1000);
        }
    }

    for(let key of Object.keys(bottles)) {
        console.log(`${key} => ${bottles[key]}`);
    }
}

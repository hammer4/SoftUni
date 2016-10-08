function autoEngineeringCompany(input) {
    let cars = new Map();

    for(let line of input){
        let tokens = line.split(" | ");
        let brand = tokens[0];
        let model = tokens[1];
        let count = Number(tokens[2]);

        if(! cars.get(brand)){
            cars.set(brand, new Map());
        }
        if(! cars.get(brand).get(model)){
            cars.get(brand).set(model, 0);
        }

        cars.get(brand).set(model, cars.get(brand).get(model) + count);
    }

    for(let [brand, modelCount] of cars){
        console.log(brand);

        for(let [model, count] of modelCount){
            console.log(`###${model} -> ${count}`);
        }
    }
}

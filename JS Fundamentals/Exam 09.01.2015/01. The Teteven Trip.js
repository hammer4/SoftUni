function theTetevenTrip(input) {
    for(let line of input){
        let tokens = line.split(" ");
        let car = tokens[0];
        let fuelType = tokens[1];
        let road = tokens[2];
        let luggageWeight = Number(tokens[3]);

        let baseConsumption = 10;
        let consumption = baseConsumption;

        switch (fuelType){
            case "gas": consumption *= 1.2; break;
            case "diesel": consumption *= 0.8; break;
        }

        consumption += luggageWeight * 0.01;
        let totalConsumption;
        let extraSnowConsumption = 0.3 * consumption;
        if(road == "1"){
            totalConsumption = 110*(consumption / 100);
            totalConsumption += 10*(extraSnowConsumption / 100);
        } else {
            totalConsumption = 95 * (consumption / 100);
            totalConsumption += 30*(extraSnowConsumption / 100);
        }

        console.log(`${car} ${fuelType} ${road} ${Math.round(totalConsumption)}`);
    }
}

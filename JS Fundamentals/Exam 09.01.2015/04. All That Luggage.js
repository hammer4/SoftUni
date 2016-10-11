function allThatLuggage(input) {
    let luggages = {};
    let sortingMethod = input.pop().split(/\.*\*{1}\.*/).filter(x => x != "")[0];

    for(let line of input){
        let tokens = line.split(/\.*\*{1}\.*/);
        let ownerName = tokens[0];
        let luggageName = tokens[1];
        let isFood = tokens[2] == "true";
        let isDrink = tokens[3] == "true";
        let isFragile = tokens[4] == "true";
        let weight = Number(tokens[5]);
        let transferredWith = tokens[6];
        let typeofLuggage = "other";

        if(isFood){
            typeofLuggage = "food";
        }

        if(isDrink){
            typeofLuggage = "drink";
        }


        if(! luggages.hasOwnProperty(ownerName)){
            luggages[ownerName] = {};
        }
        luggages[ownerName][luggageName] = {
            kg: weight,
            fragile: isFragile,
            type : typeofLuggage,
            transferredWith: transferredWith
        }
    }

    if(sortingMethod == "luggage name"){
        for(let owner of Object.keys(luggages)){
            luggages[owner] = sortObject(luggages[owner]);
        }

        function sortObject(obj) {
            return Object.keys(obj).sort().reduce(function (result, key) {
                result[key] = obj[key];
                return result;
            }, {});
        }
    }

    if(sortingMethod == "weight"){
        for(let owner of Object.keys(luggages)){
            luggages[owner] = sortObjectbyWeight(luggages[owner]);
        }

        function sortObjectbyWeight(obj) {
            return Object.keys(obj).sort((k1, k2) => obj[k1]['kg'] - obj[k2]['kg']).reduce(function (result, key) {
                result[key] = obj[key];
                return result;
            }, {});
        }
    }

    console.log(JSON.stringify(luggages));
}

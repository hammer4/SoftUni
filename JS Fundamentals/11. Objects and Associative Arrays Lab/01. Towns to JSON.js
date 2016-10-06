function townsToJSON(input) {
    let towns = [];
    let regex = /\s*\|\s*/;

    for(let line of input.splice(1)) {
        let tokens = line.split(regex);
        let townObj = { Town: tokens[1], Latitude: Number(tokens[2]), Longitude: Number(tokens[3])};
        towns.push(townObj);
    }

    console.log(JSON.stringify(towns));
}

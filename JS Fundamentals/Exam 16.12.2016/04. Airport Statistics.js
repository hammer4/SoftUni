function airportStatistics(flights) {
    let landed = [];
    let towns = {};

    for(let flight of flights){
        let [id, town, passengers, type] = flight.split(" ");
        passengers = Number(passengers);

        if(type == "depart"){
            if(landed.includes(id)){
                if(! towns.hasOwnProperty(town)){
                    towns[town] = {
                        arrivals: 0,
                        departures: 0,
                        planes : new Set()
                    };
                }
                towns[town].departures += passengers;
                landed.splice(landed.indexOf(id), 1);
                towns[town].planes.add(id);
            }
        } else {
            if(! landed.includes(id)){
                if(! towns.hasOwnProperty(town)){
                    towns[town] = {
                        arrivals: 0,
                        departures: 0,
                        planes : new Set()
                    };
                }
                towns[town].arrivals += passengers;
                landed.push(id);
                towns[town].planes.add(id);
            }
        }
    }

    landed = landed.sort((a, b) => a.localeCompare(b)).map(p => `- ${p}`);
    console.log("Planes left:");
    landed.forEach(p => console.log(p));

    function sort(a, b) {
        return towns[b].arrivals - towns[a].arrivals || a.localeCompare(b);
    }

    let townsSortedKeys = Object.keys(towns).sort((a, b) => sort(a, b));

    for(let town of townsSortedKeys){
        let planes = Array.from(towns[town].planes).sort((a, b) => a.localeCompare(b)).map(p => `-- ${p}`);

        console.log(town);
        console.log(`Arrivals: ${towns[town].arrivals}`);
        console.log(`Departures: ${towns[town].departures}`);
        console.log("Planes:");
        planes.forEach(p => console.log(p));
    }
}

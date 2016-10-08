function systemComponents(input) {
    let systems = new Map();

    for(let line of input) {
        let tokens = line.split(/\s*\|\s*/);
        let system = tokens[0];
        let component = tokens[1];
        let subcomponent = tokens[2];

        if(! systems.get(system)){
            systems.set(system, new Map());
        }
        if(! systems.get(system).get(component)){
            systems.get(system).set(component, [])
        }
        systems.get(system).get(component).push(subcomponent);
    }

    let systemsSorted = Array.from(systems.keys()).sort((s1, s2) => sortSystems(s1, s2));

    for(let system of systemsSorted) {
        console.log(system);
        let componentsSorted = Array.from(systems.get(system).keys()).sort((c1, c2) => sortComponents(system, c1, c2));

        for(let component of componentsSorted) {
            console.log(`|||${component}`);
            systems.get(system).get(component).forEach(sc => console.log(`||||||${sc}`))
        }
    }

    function sortSystems(s1, s2) {
        if(systems.get(s1).size != systems.get(s2).size) {
            return systems.get(s2).size - systems.get(s1).size;
        } else {
            return s1.toLowerCase().localeCompare(s2.toLowerCase());
        }
    }

    function sortComponents(system, c1, c2) {
        return systems.get(system).get(c2).length - systems.get(system).get(c1).length;
    }
}

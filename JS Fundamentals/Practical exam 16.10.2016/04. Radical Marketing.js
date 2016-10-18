function radicalMarketing(input) {
    let persons = new Set();
    let subscribers = new Map();
    let subscribedTo = new Map();

    for(let line of input){
        let tokens = line.split("-");
        if(tokens.length == 1){
            if(!persons.has(tokens[0])) {
                persons.add(tokens[0]);
                subscribedTo.set(tokens[0], []);
                subscribers.set(tokens[0], []);
            }
        } else {
            let subscriber = tokens[0];
            let subscribee = tokens[1];

            if(persons.has(subscriber) && persons.has(subscribee) && subscribee != subscriber){
                if(!subscribers.get(subscribee).some(s => s == subscriber)){
                    subscribers.get(subscribee).push(subscriber);
                }

                if(!subscribedTo.get(subscriber).some(s => s==subscribee)){
                    subscribedTo.get(subscriber).push(subscribee);
                }
            }
        }
    }

    let sorted = Array.from(persons).sort((a, b) => subscribers.get(b).length - subscribers.get(a).length || subscribedTo.get(b).length - subscribedTo.get(a).length);

    let first = sorted[0];

    console.log(first);
    for(let i=0; i<subscribers.get(first).length; i++){
        console.log(`${i+1}. ${subscribers.get(first)[i]}`);
    }
}

function cars(commands) {
    let map = new Map();
    let carManager = {
        create: function ([name, , parent]){
            parent = parent ? map.get(parent) : null;
            let newObj = Object.create(parent);
            map.set(name, newObj);
            return newObj;
        },
        set: function ([name, key, value]) {
            let obj = map.get(name);
            obj[key] = value;
        },
        print: function ([name]) {
            let obj = map.get(name);
            let allProperties = []
            Object.keys(obj).forEach(key => allProperties.push(`${key}:${obj[key]}`));
            while(Object.getPrototypeOf(obj)) {
                Object.keys(Object.getPrototypeOf(obj)).forEach(key => allProperties.push(`${key}:${Object.getPrototypeOf(obj)[key]}`));
                obj = Object.getPrototypeOf(obj);
            }
            console.log(allProperties.join(', '))
        }
    };

    for(let cmd of commands){
        let tokens = cmd.split(' ');
        let action = tokens.shift();
        carManager[action](tokens);
    }
}

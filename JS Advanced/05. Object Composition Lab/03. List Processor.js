function listProcessor(commands) {
    let commandProcessor = (function () {
       let list = [];
        return {
            add: newItem => list.push(newItem),
            remove: item => list = list.filter(el => el != item),
            print: () => console.log(list)
        }
    })();

    for(let cmd of commands){
        [cmdName, arg] = cmd.split(" ");
        commandProcessor[cmdName](arg);
    }
}

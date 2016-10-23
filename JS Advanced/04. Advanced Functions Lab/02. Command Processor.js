function processCommands(commands) {
    let commandProcessor = (function () {
      let text = "";
        return {
            append: newText => text += newText,
            removeStart: count => text = text.slice(count),
            removeEnd: count => text = text.slice(0, text.length-count),
            print: () => console.log(text)
        }
    }());

    for(let cmd of commands){
        let[cmdName, arg] = cmd.split(' ');
        commandProcessor[cmdName](arg);
    }
}

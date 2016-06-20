function addRemoveElements(arr) {
    let array = new Array();
    for(let command of arr) {
        let tokens = command.split(' ');
        let action = tokens[0];
        let argument = Number(tokens[1]);
        switch (action) {
            case 'add':
                array.push(argument);
                break;
            case 'remove':
                array.splice(argument, 1);
                break;
        }
    }

    for(let i of array) {
        console.log(i);
    }
}

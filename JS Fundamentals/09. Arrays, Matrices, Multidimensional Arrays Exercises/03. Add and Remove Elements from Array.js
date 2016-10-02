function addAndRemoveElementsFromArray(input) {
    let result = [];
    let number = 1;

    for(let command of input) {
        if(command == "add") {
            result.push(number);
        } else {
            result.pop();
        }

        number++;
    }

    if(result.length == 0) {
        console.log("Empty");
    } else {
        result.forEach(element => console.log(element));
    }
}
function parachute(input) {
    let jumperRow, jumperCol;
    for(let i=0; i<input.length; i++){
        if(jumperRow != undefined && jumperCol != undefined){
            jumperRow++;
            let movesToLeft = input[i].split("<").length - 1;
            let movesToRight = input[i].split(">").length - 1;
            jumperCol += movesToRight - movesToLeft;

            if(input[jumperRow][jumperCol] == "_"){
                console.log("Landed on the ground like a boss!");
                console.log(`${jumperRow} ${jumperCol}`);
                return;
            } else if(input[jumperRow][jumperCol] == "~") {
                console.log("Drowned in the water like a cat!");
                console.log(`${jumperRow} ${jumperCol}`);
                return;
            } else if(input[jumperRow][jumperCol] == "/" || input[jumperRow][jumperCol] == "\\" || input[jumperRow][jumperCol] == "|"){
                console.log("Got smacked on the rock like a dog!");
                console.log(`${jumperRow} ${jumperCol}`);
                return;
            }

        }

        if(input[i].indexOf("o") != -1){
            jumperRow = i;
            jumperCol = input[i].indexOf("o");
        }
    }
}

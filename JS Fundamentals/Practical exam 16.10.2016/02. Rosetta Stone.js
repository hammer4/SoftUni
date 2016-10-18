function rosettaStone(input) {
    let templateMatrixLength = Number(input.shift());
    let templateMatrix = [];

    for(let i=0; i<templateMatrixLength; i++){
        templateMatrix.push(input.shift().split(" ").map(Number));
    }

    let encodedMatrix = [];

    for(let i=0; i<input.length; i++){
        encodedMatrix.push(input[i].split(" ").map(Number));
    }

    for(let i=0; i<encodedMatrix.length; i++){
        for(let j=0; j<encodedMatrix[i].length; j++){
            encodedMatrix[i][j] += templateMatrix[i%templateMatrix.length][j%templateMatrix[0].length];
            encodedMatrix[i][j] %= 27;

            if(encodedMatrix[i][j] == 0){
                encodedMatrix[i][j] = " ";
            } else {
                encodedMatrix[i][j] = String.fromCharCode(64 + encodedMatrix[i][j]);
            }
        }
    }

    let encodedMessage = "";

    for(let row of encodedMatrix){
        for(let char of row){
            encodedMessage += char;
        }
    }

    console.log(encodedMessage.trim());
}

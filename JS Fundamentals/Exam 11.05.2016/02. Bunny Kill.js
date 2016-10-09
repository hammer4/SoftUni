function bunnyKill(input) {
    let bombCoordinates = input.pop().split(' ');
    let matrix = [];
    let killedBunnies = 0;
    let damageDone = 0;

    for(let line of input){
        matrix.push(line.split(' ').map(Number));
    }

    for(let coordinate of bombCoordinates){
        let tokens = coordinate.split(",").map(Number);
        let row = tokens[0];
        let col = tokens[1];

        if(matrix[row][col] > 0) {
            killedBunnies++;
            let damage = matrix[row][col];
            damageDone += damage;

            for(let i= Math.max(0, row-1); i<=Math.min(matrix.length-1, row+1); i++){
                for(let j= Math.max(0, col-1); j<= Math.min(matrix[i].length-1, col+1); j++){
                    matrix[i][j] -= damage;
                    if(matrix[i][j] < 0){
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }

    for(let row=0; row<matrix.length; row++){
        for(let col=0; col<matrix[row].length; col++){
            if(matrix[row][col] > 0){
                killedBunnies++;
                damageDone += matrix[row][col];
            }
        }
    }

    console.log(damageDone);
    console.log(killedBunnies);
}

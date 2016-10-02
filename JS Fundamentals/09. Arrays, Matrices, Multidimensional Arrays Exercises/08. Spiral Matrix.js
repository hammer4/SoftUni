function spiralMatrix(input) {
    input = input[0].split(" ").map(Number);
    let rows = input[0];
    let cols = input[1];
    let matrix = [];

    for(let i=0; i<rows; i++) {
        matrix.push([]);
    }

    let startRow = 0, startCol = 0, endRow = rows - 1, endCol = cols - 1;
    let number = 1;

    while(startRow<=endRow || startCol<=endCol) {
        for(let i = startCol; i<=endCol; i++) {
            matrix[startRow][i] = number++;

        }

        for(let i = startRow + 1; i<=endRow; i++) {
            matrix[i][endCol] = number++;
        }

        for(let i = endCol - 1; i>=startCol; i--) {
            matrix[endRow][i] = number++;
        }

        for(let i =endRow - 1; i>startRow; i--) {
            matrix[i][startCol] = number++;
        }


        startRow++;
        startCol++;
        endRow--;
        endCol--;
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}

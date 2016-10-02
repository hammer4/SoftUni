function diagonalSums(input) {
    let matrix = input.map(rows => rows.split(" "). map(Number));

    let main = 0, secondary = 0;

    for(let row = 0; row < matrix.length; row++) {
        main += matrix[row][row];
        secondary += matrix[row][matrix[row].length - row - 1];
    }

    console.log(`${main} ${secondary}`);
}

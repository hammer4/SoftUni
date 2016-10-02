function orbit(input) {
    let dimensions = input[0].split(" ").map(Number);
    let position = input[1].split(" ").map(Number);
    let rows = dimensions[0];
    let cols = dimensions[1];
    let starRow = position[0];
    let starCol = position[1];

    let matrix = [];
    for(let i=0; i<rows; i++) {
        matrix.push([]);
    }

    for(let row = 0; row< rows; row++) {
        for(let col=0; col<cols; col++) {
            matrix[row][col] = Math.max(Math.abs(row - starRow), Math.abs(col - starCol)) + 1;
        }
    }

    console.log(matrix.map(row => row.join(" ")).join("\n"));
}

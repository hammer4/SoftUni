function magicMatrices(input) {
    let matrix = input.map(row => row.split(" ").map(Number));
    let sum = matrix[0].reduce((a,b) => a+b);
    let isMagic = true;

    for(let i=1; i<matrix.length; i++) {
        if(sum != matrix[i].reduce((a,b) => a+b)) {
            isMagic = false;
        }
    }

    for(let col=0; col<matrix[0].length; col++) {
        let sumCol = 0;
        for(let row=0; row<matrix.length; row++) {
            sumCol += matrix[row][col];
        }

        if(sumCol != sum) {
            isMagic = false;
        }
    }

    console.log(isMagic);
}
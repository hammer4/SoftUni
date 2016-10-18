function arithmephile(input) {
    input = input.map(Number);
    let biggestProduct = Number.NEGATIVE_INFINITY;

    for(let i=0; i<input.length; i++){
        if(input[i] >= 0 && input[i]< 10 && input[i] % 1 == 0){
            let product = 1;
            for(let j = i+1; j<= i+input[i]; j++){
                if(input[j] != undefined) {
                    product *= input[j];
                }
            }

            if(product > biggestProduct){
                biggestProduct = product;
            }
        }
    }

    console.log(biggestProduct);
}

function productOf3Numbers(arr) {
    let x = Number(arr[0]);
    let y = Number(arr[1]);
    let z = Number(arr[2]);

    if(x==0 || y==0 || z==0) {
        console.log("Positive");
        return;
    }

    let negativeCounter = 0;
    if(x < 0) {
        negativeCounter++;
    }
    if(y < 0) {
        negativeCounter++;
    }
    if(z < 0) {
        negativeCounter++;
    }

    if(negativeCounter % 2 == 0) {
        console.log("Positive");
    } else {
        console.log("Negative");
    }
}
function treasureLocator(input) {
    input = input.map(Number);

    let checkTokelau = (x, y) => x >= 8 && x <= 9 && y >= 0 && y <= 1;
    let checkTuvalu = (x, y) => x >= 1 && x <= 3 && y >= 1 && y <= 3;
    let checkSamoa = (x, y) => x >= 5 && x <= 7 && y >= 3 && y <= 6;
    let checkTonga = (x, y) => x >= 0 && x <= 2 && y >= 6 && y <= 8;
    let checkCook = (x, y) => x >= 4 && x <= 9 && y >= 7 && y <= 8;

    for(let i=0; i<input.length; i = i+2) {
        let x = input[i];
        let y = input[i+1];

        if(checkTokelau(x, y)) {
            console.log("Tokelau");
        } else if (checkTuvalu(x, y)) {
            console.log("Tuvalu");
        } else if(checkSamoa(x, y)) {
            console.log("Samoa");
        } else if (checkTonga(x, y)) {
            console.log("Tonga");
        } else if(checkCook(x, y)) {
            console.log("Cook");
        } else {
            console.log("On the bottom of the ocean");
        }
    }
}

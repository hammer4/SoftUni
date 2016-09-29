function cookingByNumbers(input) {
    var number = Number(input[0]);

    let chop = x => x/2;
    let dice = x => Math.sqrt(x);
    let spice = x => ++x;
    let bake = x => x*3;
    let fillet = x => x - x * 0.2;

    for(let i=1; i<=5; i++) {
        switch (input[i]) {
            case "chop":
                number = chop(number);
                console.log(number);
                break;
            case "dice":
                number = dice(number);
                console.log(number);
                break;
            case "spice":
                number = spice(number);
                console.log(number);
                break;
            case "bake":
                number = bake(number);
                console.log(number);
                break;
            case "fillet":
                number = fillet(number);
                console.log(number);
                break;
        }
    }
}

cookingByNumbers([9, 'dice', 'spice', 'chop', 'bake', 'fillet']);
function figureOf4Squares([num]) {
    num = Number(num);
    let length = num % 2 == 0 ? num - 1 : num;

    for(let i = 1; i<= length; i++) {
        if(i == 1 || i == length || (length +1)/i == 2) {
            console.log("+" + "-".repeat(num-2) + "+" + "-".repeat(num-2) + "+");
        } else {
            console.log("|" + " ".repeat(num-2) + "|" + " ".repeat(num-2) + "|");
        }
    }
}

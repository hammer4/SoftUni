function kitodarTheMiner(input) {
    let silver=0;
    let gold =0;
    let diamonds = 0;

    for(let line of input){
        let tokens = line.split(" - ");

        let isValidMine = tokens[0].trim().split(" ")[0] == "mine";
        if(tokens.length == 2) {

            if (isValidMine) {
                let subTokens = tokens[1].split(":");

                if(subTokens.length == 2) {
                    let oreType = subTokens[0].trim();
                    let quantity = parseInt(subTokens[1].trim()) ? Number(subTokens[1].trim()) : 0;

                    switch (oreType) {
                        case "gold":
                            gold += quantity;
                            break;
                        case "silver":
                            silver += quantity;
                            break;
                        case "diamonds":
                            diamonds += quantity;
                            break;
                    }
                }
            }
        }
    }

    console.log(`*Silver: ${silver}`);
    console.log(`*Gold: ${gold}`);
    console.log(`*Diamonds: ${diamonds}`);
}

function uncleScroogesBag(arr) {
    var coins = 0;

    for (var index = 0; index < arr.length; index++) {
        var tokens = arr[index].split(" ");
        var type = tokens[0].toLowerCase();

        if (type == "coin") {
            if (tokens[1] % 1 === 0 && tokens[1] > 0) {
                var value = parseInt(tokens[1]);
                coins += value;
            }
        }
    }

    var gold = parseInt(coins / 100);
    coins %= 100;
    var silver = parseInt(coins / 10);
    coins %= 10;
    var bronze = coins;

    console.log("gold : " + gold);
    console.log("silver : " + silver);
    console.log("bronze : " + bronze);
}

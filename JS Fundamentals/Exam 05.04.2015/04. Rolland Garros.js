function rollandGarros(arr) {
    var matches = new Array();
    var players = new Array();

    for (var index in arr) {
        var tokens = arr[index].split(/(?:vs.|:)+/g);
        for (var i in tokens) {
            tokens[i] = tokens[i].trim();
            tokens[i] = tokens[i].replace(/\s+/g, " ");
        }

        var player1 = tokens[0];
        var player2 = tokens[1];
        var result = tokens[2];

        matches.push({
            player1 : player1,
            player2 : player2,
            result : result
        });

        var player1Added = false;
        var player2Added = false;

        for (var j in players) {
            if (players[j]['name'] == player1) {
                player1Added = true;
            }
            if (players[j]['name'] == player2) {
                player2Added = true;
            }
        }

        if (!player1Added) {
            players.push({
                "name" : player1,
                "matchesWon" : 0,
                "matchesLost" : 0,
                "setsWon" : 0,
                "setsLost" : 0,
                "gamesWon" : 0,
                "gamesLost" : 0
            });
        }

        if (!player2Added) {
            players.push({
                "name" : player2,
                "matchesWon" : 0,
                "matchesLost" : 0,
                "setsWon" : 0,
                "setsLost" : 0,
                "gamesWon" : 0,
                "gamesLost" : 0
            });
        }
    }


    for (var i in matches) {
        var sets = matches[i].result.split(" ");
        var gamesForPlayer1 = 0;
        var gamesForPlayer2 = 0;
        var setsForPlayer1 = 0;
        var setsForPlayer2 = 0;
        var matchForPlayer1 = 0;
        var matchForPlayer2 = 0;

        for (var j in sets) {
            gamesForPlayer1 += parseInt(sets[j][0]);
            gamesForPlayer2 += parseInt(sets[j][2]);

            if (parseInt(sets[j][0]) > parseInt(sets[j][2])) {
                setsForPlayer1++;
            }
            else {
                setsForPlayer2++;
            }
        }

        if (setsForPlayer1 > setsForPlayer2) {
            matchForPlayer1++;
        }
        else {
            matchForPlayer2++;
        }

        for (var p in players) {
            if (players[p]["name"] == matches[i].player1) {
                players[p]["matchesWon"] += matchForPlayer1;
                players[p]["matchesLost"] += matchForPlayer2;
                players[p]["setsWon"] += setsForPlayer1;
                players[p]["setsLost"] += setsForPlayer2;
                players[p]["gamesWon"] += gamesForPlayer1;
                players[p]["gamesLost"] += gamesForPlayer2;
            }

            if (players[p]["name"] == matches[i].player2) {
                players[p]["matchesWon"] += matchForPlayer2;
                players[p]["matchesLost"] += matchForPlayer1;
                players[p]["setsWon"] += setsForPlayer2;
                players[p]["setsLost"] += setsForPlayer1;
                players[p]["gamesWon"] += gamesForPlayer2;
                players[p]["gamesLost"] += gamesForPlayer1;
            }
        }
    }

    var sortedPlayers = players.sort(function (a, b) {
        if (a.matchesWon < b.matchesWon) {
            return 1;
        } else if(a.matchesWon > b.matchesWon){
            return -1;
        }

        if (a.setsWon < b.setsWon) {
            return 1;
        } else if (a.setsWon > b.setsWon){
            return -1;
        }

        if (a.gamesWon < b.gamesWon) {
            return 1;
        } else if (a.gamesWon > b.gamesWon){
            return -1;
        }

        if (a.name > b.name) {
            return 1;
        } else {
            return -1;
        }
    });


    var resultArray = []
    for (var i in sortedPlayers) {
        resultArray.push(JSON.stringify(sortedPlayers[i]));
    }

    console.log("[" + resultArray.join(",") + "]");
}
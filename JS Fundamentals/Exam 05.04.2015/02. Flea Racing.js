function fleaRacing(arr) {
    var participants = [];
    var numberOfJumps = parseInt(arr[0]);
    var trackLength = parseInt(arr[1]);

    for (var i = 0; i < arr.length - 2; i++) {
        var tokens = arr[i + 2].split(/,\s/);
        var name = tokens[0];
        var jump = parseInt(tokens[1]);
        participants.push({
            name : name,
            jump : jump,
            distance : 0
        });
    }

    for (var i = 0; i < numberOfJumps; i++) {
        for (var j = 0; j < participants.length; j++) {
            participants[j]['distance'] += participants[j]['jump'];
            if (participants[j]['distance'] >= trackLength - 1) {
                participants[j]['distance'] = trackLength - 1;
                var winner = participants[j]['name'];
                printFinalState(participants, trackLength, winner);
                return;
            }
        }
    }

    var longestDistance = 0;
    winner = participants[participants.length - 1]['name'];

    for (var i = participants.length - 1; i >= 0; i--) {
        if (participants[i]['distance'] > longestDistance) {
            longestDistance = participants[i]['distance'];
            winner = participants[i]['name'];
        }
    }

    printFinalState(participants, trackLength, winner);

    function printFinalState(participants, trackLength, winner) {
        for (var i = 0; i < trackLength; i++) {
            process.stdout.write("#");
        }
        console.log();

        for (var i = 0; i < trackLength; i++) {
            process.stdout.write("#");
        }
        console.log();

        for (var i in participants) {
            for (var j = 0; j < participants[i]['distance']; j++) {
                process.stdout.write(".");
            }

            process.stdout.write(participants[i]['name'][0].toUpperCase());

            for (var j = participants[i]['distance']+1; j < trackLength; j++) {
                process.stdout.write(".");
            }
            console.log();
        }

        for (var i = 0; i < trackLength; i++) {
            process.stdout.write("#");
        }
        console.log();

        for (var i = 0; i < trackLength; i++) {
            process.stdout.write("#");
        }
        console.log();
        console.log("Winner: " + winner);
    }
}
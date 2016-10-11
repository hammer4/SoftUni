function goshkoTheRabbit(arr) {
    var rabbit = {
        x : 0,
        y : 0,
        carrots : 0,
        cabbage : 0,
        lettuce : 0,
        turnip : 0,
        wallHits : 0
    };

    var directions = arr[0].split(', ');

    var matrix = new Array(arr.length - 1);

    var path = [];

    for (var i = 0; i < arr.length - 1; i++) {
        var row = arr[i + 1].split(", ");
        matrix[i] = new Array(row.length);
        for (var j = 0; j < row.length; j++) {
            matrix[i][j] = row[j];
        }
    }

    for (var i in directions) {
        switch (directions[i]) {
            case "right":
                if (rabbit.y < matrix[0].length - 1) {
                    rabbit.y++;
                    collectVegetables();
                    path.push(matrix[rabbit.x][rabbit.y]);
                }
                else {
                    rabbit.wallHits++;
                }
                break;
            case "down":
                if (rabbit.x < matrix.length - 1) {
                    rabbit.x++;
                    collectVegetables();
                    path.push(matrix[rabbit.x][rabbit.y]);
                }
                else {
                    rabbit.wallHits++;
                }
                break;
            case "left":
                if (rabbit.y > 0) {
                    rabbit.y--;
                    collectVegetables();
                    path.push(matrix[rabbit.x][rabbit.y]);
                }
                else {
                    rabbit.wallHits++;
                }
                break;
            case "up":
                if (rabbit.x > 0) {
                    rabbit.x--;
                    collectVegetables();
                    path.push(matrix[rabbit.x][rabbit.y]);
                }
                else {
                    rabbit.wallHits++;
                }
                break;
        }
    }

    console.log('{"&":' + rabbit.lettuce + ',"*":' + rabbit.cabbage + ',"#":' + rabbit.turnip + ',"!":' + rabbit.carrots + ',"wall hits":' + rabbit.wallHits + '}');
    if (path.length > 0) {
        console.log(path.join("|"));
    }
    else {
        console.log("no");
    }
    function collectVegetables() {
        var x = rabbit.x;
        var y = rabbit.y;

        if (matrix[x][y].length > 2) {
            for (var i = 0; i < matrix[x][y].length - 2; i++) {
                var cell = matrix[x][y][i] + matrix[x][y][i + 1] + matrix[x][y][i + 2];
                if (cell == '{!}') {
                    rabbit.carrots++;
                }
                else if (cell == '{*}') {
                    rabbit.cabbage++;
                }
                else if (cell == '{&}') {
                    rabbit.lettuce++;
                }
                else if (cell == '{#}') {
                    rabbit.turnip++;
                }
            }

            matrix[x][y] = matrix[x][y].replace(/{(!|#|\*|\&)}/g, '@');
        }
    }
}

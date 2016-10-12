function magicGrid(arr) {
    var encryptedText = arr[0];
    var magicNumber = parseInt(arr[1]);
    var matrix = new Array(arr.length - 2);

    for (var i = 0; i < arr.length - 2; i++) {
        var input = arr[i + 2].split(" ");
        matrix[i] = new Array(input.length);
        for (var j = 0; j < arr.length - 2; j++) {
            matrix[i][j] = parseInt(input[j]);
        }
    }

    var key;
    for (var i = 0; i < matrix.length; i++) {
        for (var j = 0; j < matrix[i].length; j++) {
            for (var k = 0; k < matrix.length; k++) {
                for (var l = 0; l < matrix[k].length; l++) {
                    if (matrix[i][j] + matrix[k][l] === magicNumber && (i != k || j != l)) {
                        key = i + j + k + l;
                    }
                }
            }
        }
    }

    var decryptedText = "";
    for (var i = 0; i < encryptedText.length; i++) {
        var char = encryptedText.charCodeAt(i);
        if (i % 2 == 0) {
            char += key;
        } else {
            char -= key;
        }
        decryptedText = decryptedText.concat(String.fromCharCode(char));
    }

    console.log(decryptedText);
}
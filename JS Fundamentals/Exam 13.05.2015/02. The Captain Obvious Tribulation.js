function theCaptainObviousTribulation(arr) {
    var words = arr[0].split(/[\s,.:!?]+/g).filter(function (word) {
        return word != "";
    }).map(function (string) {
        return string.toLowerCase();
    });

    var wordsCount = [];
    for (var i in words) {
        if (wordsCount[words[i]] != undefined) {
            wordsCount[words[i]]++;
        } else {
            wordsCount[words[i]] = 1;
        }
    }

    var repeatedWords = [];

    for (key in wordsCount) {
        if (wordsCount[key] >= 3) {
            repeatedWords.push(key);
        }
    }

    if (repeatedWords.length == 0) {
        console.log("No words");
        return;
    }

    var regex = /\S*(.)+?(\?|\.|\!)/g;
    var sentences = arr[1].match(regex).map(function (string) {
        return string.trim();
    });


    var sentencesCounter = 0;
    for (var k in sentences) {
        var wordsInSentence = sentences[k].split(/[\s,.:!?]+/g).map(function (string) {
            return string.toLowerCase();
        });
        var wordsCounter = 0;
        for (var i in repeatedWords) {
            for (var j in wordsInSentence) {
                if (wordsInSentence[j] == repeatedWords[i]) {
                    wordsCounter++
                    break;
                }
            }
        }

        if (wordsCounter >= 2) {
            console.log(sentences[k]);
            sentencesCounter++;
        }
    }

    if (sentencesCounter == 0) {
        console.log("No sentences");
    }
}
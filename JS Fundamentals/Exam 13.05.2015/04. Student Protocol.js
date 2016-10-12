function studentProtocol(arr) {
    var exams = {};
    for (var i = 0; i < arr.length; i++) {
        var input = arr[i].split(/(?:-|:)+/g).map(function (string) {
            return string.trim();
        });

        var name = input[0];
        var subject = input[1];
        var score = parseInt(input[2]);

        if (score >= 0 && score <= 400) {
            if (!exams.hasOwnProperty(subject)) {
                exams[subject] = [];
                exams[subject].push({
                    name: name,
                    result: score,
                    makeUpExams : 0
                });
            } else {
                var studentExists = false;
                for (var j in exams[subject]) {
                    if (exams[subject][j].name == name) {
                        exams[subject][j].makeUpExams++;
                        studentExists = true;
                        if (exams[subject][j].result < score) {
                            exams[subject][j].result = score;
                        }
                    }
                }

                if (!studentExists) {
                    exams[subject].push({
                        name: name,
                        result : score,
                        makeUpExams : 0
                    });
                }
            }
        }
    }

    for (var subject in exams) {
        exams[subject] = exams[subject].sort(function (a, b) {
            if (a.result != b.result) {
                return b.result - a.result;
            } else  {
                if (a.makeUpExams != b.makeUpExams) {
                    return a.makeUpExams - b.makeUpExams;
                } else {
                    return a.name > b.name;
                }
            }
        });
    }

    console.log(JSON.stringify(exams));
}
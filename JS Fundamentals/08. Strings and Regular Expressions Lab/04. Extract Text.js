function extractText([str]) {
    let result = [];
    let start = str.indexOf('(');
    let end = str.indexOf(')',start);

    while (start > -1 && end > -1) {
        result.push(str.substring(start+1, end));
        start = str.indexOf('(', end);
        end = str.indexOf(')', start);
    }

    console.log(result.join(", "));
}

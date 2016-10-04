function expressionSplit([code]) {
    code.split(/[\s(),;\.]/).filter(w => w != "").forEach(w => console.log(w));
}

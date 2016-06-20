function extractCapitalCaseWords(arr) {
    let capitalCaseWords = [];
    for(let sentence of arr) {
        let words = sentence.split(/\W+/).filter(word => word != "");

        for(let word of words) {
            if(word == word.toUpperCase()) {
                capitalCaseWords.push(word);
            }
        }
    }

    console.log(capitalCaseWords.join(", "));
}

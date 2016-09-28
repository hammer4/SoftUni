function wordsUppercase([str]) {
    var strToUpper = str.toUpperCase();

    function extractWords() {
        return strToUpper.split(/\W+/);
    }

    var words = extractWords();
    words = words.filter(w => w != '');
    return words.join(', ');
}
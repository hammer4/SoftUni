function extractUniqueWords(input) {
    let set = new Set();

    for(let line of input) {
        let words = line.toLowerCase().split(/\W+/).filter(w => w != "");
        for(let word of words) {
            set.add(word);
        }
    }

    console.log(Array.from(set.keys()).join(", "));
}

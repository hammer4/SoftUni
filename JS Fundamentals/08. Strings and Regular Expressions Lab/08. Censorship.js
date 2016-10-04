function censorship(input) {
    let text = input.shift();
    let forbiddenWords = input;
    for(let word of forbiddenWords) {
        text = text.split(word).join("-".repeat(word.length));
    }

    return text;
}

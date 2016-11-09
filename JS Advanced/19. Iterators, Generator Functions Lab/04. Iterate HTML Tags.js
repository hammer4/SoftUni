function* iterateHtmlTags(html) {
    let regex = /<[^>]+>/g;
    let match;
    while(match = regex.exec(html)){
        let tag = match[0];
        yield tag;
    }
}
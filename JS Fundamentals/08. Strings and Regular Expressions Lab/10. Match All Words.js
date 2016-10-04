function matchAllWords([text]) {
    console.log(text.split(/\W+/).filter(w => w!="").join("|"));
}

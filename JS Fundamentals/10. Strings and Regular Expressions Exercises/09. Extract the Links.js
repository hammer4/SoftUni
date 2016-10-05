function extractTheLinks(input) {
    let links = [];
    let regex = /www\.[A-Za-z0-9\-]+(\.[a-z]+)+/g;

    for(let sentence of input) {
        let match = null;
        let index = 0;
        while(match = regex.exec(sentence)) {
            console.log(match[0]);
        }
    }
}

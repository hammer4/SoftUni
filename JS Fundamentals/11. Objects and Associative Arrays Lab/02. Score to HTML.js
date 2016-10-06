function scoreToHTML(input) {
    let json = input[0];
    let objArr = JSON.parse(json);
    let html = '<table>\n';
    html += '  <tr><th>name</th><th>score</th></tr>\n';

    for(let obj of objArr){
        html += `  <tr><td>${htmlEscape(obj.name)}</td><td>${obj.score}</td></tr>\n`;
    }

    html += '</table>';

    console.log(html);


    function htmlEscape(text) {
        let map = { '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

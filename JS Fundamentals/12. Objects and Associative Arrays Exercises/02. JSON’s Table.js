function jsonTable(input) {
    let html = '<table>\n';
    for(let line of input) {
        let obj = JSON.parse(line);
        html += '    <tr>\n';
        html += `       <td>${htmlEscape(obj.name)}</td>\n`;
        html += `       <td>${htmlEscape(obj.position)}</td>\n`
        html += `       <td>${obj.salary}</td>\n`;
        html += '    <tr>\n';
    }
    html += '</table>';

    console.log(html);

    function htmlEscape(text) {
        let map = { '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

function fromJSONToHTMLTable(input) {
    let objArr = JSON.parse(input[0]);
    let html = '<table>\n';
    html += '  <tr>';
    Object.keys(objArr[0]).forEach(k => html += `<th>${k}</th>`);
    html += '</tr>\n';

    for(let obj of objArr) {
        html += '  <tr>';
        Object.keys(obj).forEach(k => html += `<td>${htmlEscape(String(obj[k]))}</td>`);
        html += '</tr>\n';
    }
    
    html += '</table>';
    
    console.log(html);

    function htmlEscape(text) {
        let map = { '"': '&quot;', '&': '&amp;',
            "'": '&#39;', '<': '&lt;', '>': '&gt;' };
        return text.replace(/[\"&'<>]/g, ch => map[ch]);
    }
}

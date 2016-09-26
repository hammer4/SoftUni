function multiplicationTable([number]) {
    number = Number(number);
    let html = "";
    html += '<table border="1">\n';
    html += '\t<tr><th>x</th>';

    for(let i = 1; i<= number; i++) {
        html += `<th>${i}</th>`;
    }

    html += '</tr>\n';

    for(let i=1; i <= number; i++) {
        html += `\t<tr><th>${i}</th>`;

        for(let j=1; j<= number; j++) {
            html += `<td>${i * j}</td>`
        }

        html += '</tr>\n';
    }

    html += '</table>\n';

    console.log(html);
}

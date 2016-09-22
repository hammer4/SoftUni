function colorfulNames([number]) {
    number = Number(number);
    let html = '<ul>\n';
    for(let i = 1; i<= number; i++) {
        let color = i % 2 == 0 ? "blue" : "green";
        html += `\t<li><span style="color: ${color}">${i}</span></li>\n`;
    }
    html += "</ul>";
    return html;
}

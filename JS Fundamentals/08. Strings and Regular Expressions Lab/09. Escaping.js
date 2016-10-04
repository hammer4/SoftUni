function escaping(input) {
    let forbidden = ["&", "<", ">", '"'];
    let allowed = ["&amp;", "&lt;", "&gt;", "&quot;"];

    let html = "<ul>\n";

    for(let line of input) {
        html += "  <li>";
        for(let i in forbidden) {
            line = line.split(forbidden[i]).join(allowed[i]);
        }
        html += line + "</li>\n";
    }

    html += "</ul>";

    return html;
}

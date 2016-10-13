function daggerAndSwords(input) {
    let html = '<table border="1">\n';
    html += '<thead>\n';
    html += '<tr><th colspan="3">Blades</th></tr>\n';
    html += '<tr><th>Length [cm]</th><th>Type</th><th>Application</th></tr>\n';
    html += '</thead>\n';
    html += '<tbody>\n';

    for(let line of input){
        let length, type, application;

        length = parseInt(line);
        if(length > 10) {
            type = length > 40 ? "sword" : "dagger";

            switch (length % 5){
                case 1: application = "blade"; break;
                case 2: application = "quite a blade"; break;
                case 3: application = "pants-scraper"; break;
                case 4: application = "frog-butcher"; break;
                case 0: application = "*rap-poker"; break;
            }

            html += `<tr><td>${length}</td><td>${type}</td><td>${application}</td></tr>\n`;
        }
    }

    html += '</tbody>\n';
    html += '</table>\n';

    console.log(html);
}

let Article = require('./article.js');

class TableArticle extends Article{
    constructor(title, content){
        super(title, content);
        this.headings = null;
        this.data = null;
    }

    loadData(headings, data){
        this.headings = headings;
        this.data = data;
    }

    getElementString(){
        let output = `<div class="article">\n`;
        output += `\t<div class="article-title">${this.title}</div>\n`;
        output += `\t<p>${this.content}</p>\n`;
        output += `\t<div class="table">\n`;
        output += `\t\t<table class="data">\n`;
        output += `\t\t\t<tr>`;

        for(let heading of this.headings){
            output += `<th>${heading}</th>`;
        }

        output += `</tr>\n`;

        for(let obj of this.data){
            output += `\t\t\t<tr>`;

            for(let property of Object.keys(obj)){
                output += `<td>${obj[property]}`;
            }

            output += `</tr>\n`;
        }

        output += `\t\t</table>\n`;
        output += `\t</div>\n`;
        output += `</div>`;

        return output;
    }
}

module.exports = TableArticle;
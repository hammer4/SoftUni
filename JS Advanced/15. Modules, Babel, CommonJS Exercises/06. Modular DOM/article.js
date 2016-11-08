let BaseElement = require('./base-element.js');

class Article extends BaseElement{
    constructor(title, content){
        super();
        this.title = title;
        this.content = content;
        this.timestamp = new Date();
    }

    getElementString(){
        let output = `<div class="article">\n`;
        output += `\t<div class="article-title">${this.title}</div>\n`;
        output += `\t<p>${this.content}</p>\n`;
        output += `</div>`;

        return output;
    }
}

module.exports = Article;
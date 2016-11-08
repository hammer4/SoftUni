let Article = require('./article.js');

class ImageArticle extends Article{
    constructor(title, content, image){
        super(title, content);
        this.image = image;
    }

    getElementString(){
        let output = `<div class="article">\n`;
        output += `\t<div class="article-title">${this.title}</div>\n`;
        output += `\t<div class="image"><img src="${this.image}"></div>\n`;
        output += `\t<p>${this.content}</p>\n`;
        output += `</div>`;
        
        return output;
    }
}

module.exports = ImageArticle;
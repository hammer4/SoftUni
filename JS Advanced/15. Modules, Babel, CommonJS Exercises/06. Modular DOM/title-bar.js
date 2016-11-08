let BaseElement = require('./base-element.js');

class TitleBar extends BaseElement{
    constructor(title){
        super();
        this.title = title;
        this.links = [];
    }

    addLink(href, name){
        this.links.push({href:href, name:name});
    }

    getElementString(){
        let output = `<header class="header">\n`;
        output += `\t<div><span class="title">${this.title}</span></div>\n`;
        output += `\t<div>\n`;
        output += `\t\t<nav class="menu">\n`;

        for(let link of this.links){
            output += `\t\t\t<a class="menu-link" href="${link.href}">${link.name}</a>\n`;
        }

        output += `\t\t</nav>\n`;
        output += `\t</div>\n`;
        output += `</header>`;

        return output;
    }
}

module.exports = TitleBar;
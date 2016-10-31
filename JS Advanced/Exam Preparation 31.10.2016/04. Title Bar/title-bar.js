class TitleBar{
    constructor(title){
        this.title = title;
        this.menulinks = [];
    }

    addLink(href, name){
        this.menulinks.push($('<a>').attr('href', href).text(name).addClass('menu-link'));
    }

    appendTo(selector){
        $(selector).append($('<header>').addClass('header').append($('<div>').addClass('header-row').append($('<a>').addClass('button').text('&#9776;').click(toggleMenu)).append($('<span>').addClass('title').text(this.title))).append($('<div>').addClass('drawer').append($('<nav>').addClass('menu'))));

        for(let link of this.menulinks){
            $('.menu').append(link);
        }

       function toggleMenu(){
            $('.drawer').toggle();
        }
    }
}

let header = new TitleBar('Title Bar Problem');
header.addLink('/', 'Home');
header.addLink('about', 'About');
header.addLink('results', 'Results');
header.addLink('faq', 'FAQ');
header.appendTo('#container');

let BaseElement = require('./base-element.js');
let TitleBar = require('./title-bar.js');
let Footer = require('./footer.js');
let Article = require('./article.js');
let ImageArticle = require('./image-article.js');
let TableArticle = require('./table-article.js');
/*
let tbar = new TitleBar('Modular DOM');
tbar.addLink('/', 'Home');
tbar.addLink('about', 'About');
tbar.addLink('results', 'Results');
tbar.addLink('faq', 'FAQ');
tbar.appendTo('#head');

let footer = new Footer('2016 The Shoemaker Company');
footer.appendTo('#wrapper');

let a1 = new ImageArticle('What is Lorem Ipsum?', "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", 'src/lorem.png');
a1.appendTo('#content');

let a2 = new Article('Where does it come from?', `Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of "de Finibus Bonorum et Malorum" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, "Lorem ipsum dolor sit amet..", comes from a line in section 1.10.32.`);
a2.appendTo('#content');

let data = [
    { orderid: 'CRA9938',
        status: 'delivered',
        shipto: 'Baku',
        latlong: '53.80 33.21' },
    { orderid: 'KNQ5876',
        status: 'processing',
        shipto: 'Yerevan',
        latlong: '50.25 31.37' },
    { orderid: 'JZH6615',
        status: 'processing',
        shipto: 'London',
        latlong: '54.74 -1.79' },
    { orderid: 'FMU7330',
        status: 'delivered',
        shipto: 'Brussels',
        latlong: '63.22 34.78' }];

let a3 = new TableArticle('Why do we use it?',"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).");
a3.loadData(['Order ID', 'Status', 'Ship To', 'Lat Long'], data);
a3.appendTo('#content');
*/

// Export modules
result.BaseElement = BaseElement;
result.TitleBar = TitleBar;
result.Footer = Footer;
result.Article = Article;
result.ImageArticle = ImageArticle;
result.TableArticle = TableArticle;


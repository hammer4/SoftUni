let books = [
  { id: 1,
    image: 'http://speakingjs.com/speakingjs_cover.jpg',
    title: 'Speaking JavaScript: An In-Depth Guide for Programmers',
    description: `This book has been written for programmers, by a programmer. 
    In order to understand it, you should already know object-oriented programming, 
    for example, via a mainstream programming language such as Java, PHP, C++, Python, 
    Ruby, Objective-C, Swift, C#, or Perl. Thus, the book’s target audience is programmers 
    who want to learn JavaScript quickly and properly, and JavaScript programmers who want 
    to deepen their skills and/or look up specific topics`,
    author: 1,
    price: 10.55,
    comments: [1, 2, 3],
    date: '2015-03-25T12:00:00Z'
  },
  { id: 2,
    image: 'http://exploringjs.com/es6/images/cover.jpg',
    title: 'Exploring ES6',
    description: `Is the most comprehensive book on ECMAScript 6 (ECMAScript 2015).
    Is a book for people who already know JavaScript.`,
    author: 1,
    price: 15.45,
    comments: [4, 5],
    date: '2015-03-25T13:00:00Z'
  },
  { id: 3,
    image: 'http://exploringjs.com/es2016-es2017/images/cover.jpg',
    title: 'Exploring ES2016 and ES2017',
    description: `Covers the latest versions of JavaScript as they are created.
    Is a book for people who already know JavaScript..`,
    author: 1,
    price: 9.30,
    comments: [6, 7],
    date: '2015-03-25T20:00:00Z'
  },
  { id: 4,
    image: 'https://images-na.ssl-images-amazon.com/images/I/51QXP7FDJ2L._SX376_BO1,204,203,200_.jpg',
    title: 'JavaScript for Kids: A Playful Introduction to Programming',
    description: `True to the title, this book is a whimsical exploration of very basic programming
     concepts, but don’t let that fool you. Books for kids aren’t just for kids. If you have never
      touched code before, this is a good place to start, even if you’re all grown up. 
      Diving in the deep end before you learn how to swim can be a frustrating experience. 
      It’s better to start your practice with some easy wins.`,
    author: 2,
    price: 22.30,
    comments: [8, 9],
    date: '2015-03-25T19:00:00Z'
  },
  { id: 5,
    image: 'https://images-na.ssl-images-amazon.com/images/I/51zFTdNilAL._SX377_BO1,204,203,200_.jpg',
    title: 'Eloquent JavaScript: A Modern Introduction to Programming',
    description: `This book is a work of art. It walks you through the essential concepts with a clear 
    roadmap using clear language. It’s masterfully composed and edited, and unlike most programming books, 
    it’s full of exercises for you to practice. If I were teaching the basics of programming in high school 
    or college, I would use this as a text book.`,
    author: 3,
    price: 35.30,
    comments: [],
    date: '2015-03-25T17:00:00Z'
  }
]

let comments = [
  {
    id: 1,
    message: 'Very good book',
    book: 1
  },
  {
    id: 2,
    message: 'Not bad, very advanced',
    book: 1
  },
  {
    id: 3,
    message: 'I liked it',
    book: 1
  },
  {
    id: 4,
    message: 'Superb book',
    book: 2
  },
  {
    id: 5,
    message: 'I didn\'t like it...',
    book: 2
  },
  {
    id: 6,
    message: 'Wonderful',
    book: 3
  },
  {
    id: 7,
    message: 'Great book',
    book: 3
  },
  {
    id: 8,
    message: 'Dovolen sym',
    book: 4
  },
  {
    id: 9,
    message: 'Mnogo neshta sa pokazani',
    book: 4
  }
]

let authors = [
  {
    id: 1,
    name: 'Dr. Axel Rauschmayer',
    image: 'http://speakingjs.com/axel_head.jpg',
    books: [1, 2, 3]
  },
  {
    id: 2,
    name: 'Nick Morgan',
    image: 'http://www.azquotes.com/public/pictures/authors/df/8e/df8e2429b0fea3323ca39ab58bd785fd/556ec843ec87b_nick_morgan.jpeg',
    books: [4]
  },
  {
    id: 3,
    name: 'Marijn Haverbeke',
    image: 'https://pbs.twimg.com/profile_images/2033010624/pic_400x400.jpg',
    books: [5]
  }
]

let users = []

export default {
  books,
  authors,
  comments,
  users
}

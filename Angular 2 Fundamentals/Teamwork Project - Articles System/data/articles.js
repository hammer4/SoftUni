const articles = {}
let currentId = 0

module.exports = {
  total: () => Object.keys(articles).length,
  save: (article) => {
    const id = ++currentId
    article.id = id

    let newArticle = {
      id,
      name: article.name,
      author: article.author,
      details: article.details,
      year: article.year,
      image: article.image,
      createdOn: new Date(),
      createdBy: article.createdBy,
      likes: [],
      reviews: []
    }


    articles[id] = newArticle
  },
  all: (page, search) => {
    const pageSize = 10

    let startIndex = (page - 1) * pageSize
    let endIndex = startIndex + pageSize

    return Object
      .keys(articles)
      .map(key => articles[key])
      .filter(article => {
        if (!search) {
          return true
        }

        const articleName = article.name.toLowerCase()
        const articleAuthor = article.author.toLowerCase()
        const searchTerm = search.toLowerCase()

        return articleAuthor.indexOf(searchTerm) >= 0 ||
          articleName.indexOf(searchTerm) >= 0
      })
      .sort((a, b) => b.id - a.id)
      .slice(startIndex, endIndex)
  },
  findById: (id) => {
    return articles[id]
  },
  addReview: (id, rating, comment, user) => {
    const review = {
      rating,
      comment,
      user,
      createdOn: new Date()
    }

    articles[id].reviews.push(review)
  },
  allReviews: (id) => {
    return articles[id]
      .reviews
      .sort((a, b) => b.createdOn - a.createdOn)
      .slice(0)
  },
  like: (id, user) => {
    const likes = articles[id].likes

    if (likes.indexOf(user) >= 0) {
      return false
    }

    likes.push(user)

    return true
  },
  byUser: (user) => {
    return Object
      .keys(articles)
      .map(key => articles[key])
      .filter(article => article.createdBy === user)
      .sort((a, b) => b.id - a.id)
  },
  delete: (id) => {
    delete articles[id]
  }
}

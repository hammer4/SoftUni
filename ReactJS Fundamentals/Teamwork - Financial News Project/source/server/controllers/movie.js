const Article = require('../models/Article')
const Vote = require('../models/Vote')

module.exports = {
  add: {
    post: (req, res) => {
      let inputData = req.body
      let articleData = {
        name: inputData.name,
        description: inputData.description
        // genres: inputData.genres
      }

      Article.create(articleData).then(article => {
        if (!article) {
          return res.status(500)
            .send({message: 'Cannot write news in database'})
        }

        res.status(200).send({message: `${article.name} added!`})
      })
    }
  },
  topTen: {
    get: (req, res) => {
      Article.find().sort({score: -1}).limit(5).then(article => {
        if (!article) {
          return res.status(400)
            .send({message: 'No articles. Care to add some?'})
        }

        res.status(200).send(article)
      })
    }
  },
  fiveRecent: {
    get: (req, res) => {
      Article.find().sort({dateCreated: -1}).limit(5).then(article => {
        if (!article) {
          return res.status(400).send({message: 'No articles. Care to add some?'})
        }

        res.status(200).send(article)
      })
    }
  },
  search: {
    get: (req, res) => {
      let query = req.query.query
      console.log(query)
      Article.find(
        {$text: {$search: query}},
        {matchScore: {$meta: 'textScore'}}
      ).sort({
        matchScore: {$meta: 'textScore'},
        score: -1
      }).then(movies => {
        if (movies.length === 0) {
          return res.status(404)
            .send({message: 'Sorry! News not found...'})
        }

        res.status(200).send(article)
      })
    }
  },
  getUserRated: {
    get: (req, res) => {
      let userId = req.params.userId

      Vote.find({userId}).sort({score: -1}).populate('movie').then(votes => {
        console.log('[Article controller] gerUserRated() votes: ', votes)
        // Check if necessary.
        let articles = []
        votes.forEach(v => articles.push(v.movie)) // Filter only the news, since we don't need vote information.

        res.status(200).send(articles)
      })
    }
  }
}

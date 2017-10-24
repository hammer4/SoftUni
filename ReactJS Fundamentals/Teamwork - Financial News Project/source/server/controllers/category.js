const Category = require('../models/Category')

module.exports = {
  add: (req, res) => {
    let categoryData = {
      articles: [],
      name: req.body.name
    }

    Category.create(categoryData).then(category => {
      res.status(200).send({category})
    })
  },

  all: (req, res) => {
    Category.find().then(categories => {
      res.status(200).send(categories)
    })
  }
}

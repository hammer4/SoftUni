const Category = require('../data/Category')
const Thread = require('../data/Thread')

module.exports = {
  addGet: (req, res) => {
    res.render('category/add')
  },

  addPost: (req, res) => {
    let categoryReq = req.body

    Category.create({
      name: categoryReq.name
    }).then(() => {
      res.redirect('/')
    }).catch(() => {
      res.render('category/add', categoryReq)
    })
  },

  deleteGet: (req, res) => {
    Category.find().then(categories => {
      res.render('category/delete', {
        categories: categories
      })
    })
  },

  deletePost: (req, res) => {
    let categoryId = req.body.category

    Category.findByIdAndRemove(categoryId).then(() => {
      res.redirect('/')
    })
  },

  all: (req, res) => {
    Category.find().then(categories => {
      res.render('category/all', {
        categories: categories
      })
    })
  },

  getThreads: (req, res) => {
    let id = req.params.id

    Thread.find({category: id}).then(threads => {
      Category.findById(id).then(category => {
        res.render('category/threads-per-category', {
          threads: threads,
          category: category
        })
      })
    })
  }
}

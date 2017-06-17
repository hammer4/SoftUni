const Image = require('../data/Image')
const User = require('../data/User')

module.exports = {
  addGet: (req, res) => {
    res.render('image/add')
  },

  addPost: (req, res) => {
    let description = req.body.description
    let url = req.body.url
    if (description.length > 500) {
      res.redirect('/')
      return
    }

    let tagRegex = /(^|[ .,!?])#([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let tags = []

    let match = tagRegex.exec(description)
    while (match) {
      tags.push(match[2].toLowerCase())
      match = tagRegex.exec(description)
    }

    let handleRegex = /(^|[ .,!?])@([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let handles = []

    match = handleRegex.exec(description)
    while (match) {
      handles.push(match[2])
      match = handleRegex.exec(description)
    }

    Image.create({
      description: description,
      url: url,
      owner: req.user._id,
      tags: tags,
      handles: handles
    }).then(() => {
      res.redirect('/')
    })
  },

  showByTag: (req, res) => {
    let tag = req.params.tagName.toLowerCase()

    Image.find({tags: {$in: [tag]}}).populate('owner').sort('-date').limit(100).then(images => {
      for (let image of images) {
        image.views++
        image.save()
      }
      res.render('image/tag', {
        tag: tag,
        images: images
      })
    })
  },

  like: (req, res) => {
    let id = req.params.id
    Image.findById(id).then(image => {
      image.likes = image.likes + 1
      image.save().then(image => {
        User.findByIdAndUpdate(req.user._id, {$addToSet: {likedImages: image._id}}).then((user) => {
          res.redirect(`/`)
        })
      })
    })
  },

  dislike: (req, res) => {
    let id = req.params.id
    Image.findById(id).then(image => {
      image.likes = image.likes - 1
      image.save().then(image => {
        User.findByIdAndUpdate(req.user._id, {$pull: {likedImages: {$in: [image._id]}}}).then((user) => {
          res.redirect(`/`)
        })
      })
    })
  },

  editGet: (req, res) => {
    let id = req.params.id

    Image.findById(id).then(image => {
      res.render('image/edit', {
        image: image
      })
    })
  },

  editPost: (req, res) => {
    let id = req.params.id
    let description = req.body.description
    let url = req.body.url

    let tagRegex = /(^|[ .,!?])#([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let tags = []

    let match = tagRegex.exec(description)
    while (match) {
      tags.push(match[2].toLowerCase())
      match = tagRegex.exec(description)
    }

    let handleRegex = /(^|[ .,!?])@([-_0-9A-Za-z]+)(?=$|[ .,!?])/gim
    let handles = []

    match = handleRegex.exec(description)
    while (match) {
      handles.push(match[2])
      match = handleRegex.exec(description)
    }

    Image.findById(id).then(tweet => {
      tweet.description = description
      tweet.url = url
      tweet.tags = tags
      tweet.handles = handles
      tweet.save().then(() => {
        res.redirect('/')
      })
    })
  },

  deleteGet: (req, res) => {
    let id = req.params.id

    Image.findById(id).then(image => {
      res.render('image/delete', {
        image: image
      })
    })
  },

  deletePost: (req, res) => {
    let id = req.params.id

    Image.findByIdAndRemove(id).then(() => {
      res.redirect('/')
    })
  }
}

const Image = require('../data/Image')

module.exports = {
  index: (req, res) => {
    Image.find().populate('owner').sort('-date').limit(100).then(images => {
      for (let image of images) {
        image.views++
        image.save()
      }
      res.render('home/index', {
        images: images
      })
    })
  }
}

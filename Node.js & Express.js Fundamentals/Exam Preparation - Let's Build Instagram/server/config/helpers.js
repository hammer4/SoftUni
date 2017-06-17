module.exports = {
  custIf: (a, op, b, options) => {
    if (op === '==' && a == b) return options.fn(this)
    if (op === '===' && a.toString() === b.toString()) return options.fn(this)
    if (op === '>' && a > b) return options.fn(this)
    if (op === '<' && a < b) return options.fn(this)

    return options.inverse(this)
  },

  hasLiked: (user, imageId, options) => {
    if (user.likedImages.indexOf(imageId) > -1) return options.fn(this)

    return options.inverse(this)
  }
}

module.exports = {
  custIf: (a, op, b, options) => {
    if (op === '==' && a == b) return options.fn(this)
    if (op === '===' && a.toString() === b.toString()) return options.fn(this)
    if (op === '>' && a > b) return options.fn(this)
    if (op === '<' && a < b) return options.fn(this)
    if (op === '!==' && a.toString() !== b.toString()) return options.fn(this)

    return options.inverse(this)
  },

  hasLiked: (user, messageId, options) => {
    if (user.likedMessages.indexOf(messageId) > -1) return options.fn(this)

    return options.inverse(this)
  },

  hasBlocked: (userOne, userTwo, options) => {
    if (userOne.blockedUsers.indexOf(userTwo._id) > -1) return options.fn(this)

    return options.inverse(this)
  }
}

const Answer = require('../data/Answer')
const Thread = require('../data/Thread')

module.exports = {
  addPost: (req, res) => {
    let id = req.params.id
    let answerReq = req.body
    if (!req.user.isBlocked) {
      Answer.create({
        thread: id,
        author: req.user._id,
        content: answerReq.content
      }).then((answer) => {
        Thread.findById(id).populate('author').then(thread => {
          thread.answers.push(answer._id)
          thread.lastAnswerDate = answer.date
          thread.save().then(thread => {
            Answer.find({thread: thread._id.toString()}).populate('author').sort('date').then(answers => {
              if (req.user) {
                res.render('thread/view', {
                  thread: thread,
                  answers: answers,
                  hasLiked: req.user.likedThreads.indexOf(thread._id) > -1
                })
              } else {
                res.render('thread/view', {
                  thread: thread,
                  answers: answers
                })
              }
            })
          })
        })
      })
    } else {
      res.redirect('/')
    }
  },
  editGet: (req, res) => {
    let id = req.params.id
    Answer.findById(id).populate('author').populate('thread').then(answer => {
      res.render('answer/edit', {answer: answer})
    })
  },
  editPost: (req, res) => {
    let id = req.params.id
    let answerReq = req.body
    Answer.findById(id).populate('thread').then(answer => {
      answer.content = answerReq.content
      answer.save().then(() => {
        res.redirect(`/post/${answer.thread._id}/${answer.thread.title}`)
      })
    })
  },
  deleteGet: (req, res) => {
    let id = req.params.id
    Answer.findById(id).populate('author').populate('thread').then(answer => {
      res.render('answer/delete', {answer: answer})
    })
  },
  deletePost: (req, res) => {
    let id = req.params.id
    Answer.findByIdAndRemove(id).populate('thread').then(answer => {
      Thread.findByIdAndUpdate(answer.thread._id, {$pull: {answers: {$in: [id]}}}).then(() => {
        res.redirect(`/post/${answer.thread._id}/${answer.thread.title}`)
      })
    })
  }
}

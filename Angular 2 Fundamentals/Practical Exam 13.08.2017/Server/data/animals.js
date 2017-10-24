const animals = {}
let currentId = 0

module.exports = {
  total: () => Object.keys(animals).length,
  save: (animal) => {
    const id = ++currentId
    animal.id = id

    let newAnimal = {
      id,
      name: animal.name,
      age: animal.age,
      color: animal.color,
      type: animal.type,
      price: animal.price,
      image: animal.image,
      createdOn: new Date(),
      createdBy: animal.createdBy,
      reactions: {
        like: [],
        love: [],
        haha: [],
        wow: [],
        sad: [],
        angry: []
      },
      comments: []
    }

    if (animal.breed) {
      newAnimal.breed = animal.breed
    }

    animals[id] = newAnimal
  },
  all: (page, search) => {
    const pageSize = 10

    let startIndex = (page - 1) * pageSize
    let endIndex = startIndex + pageSize

    return Object
      .keys(animals)
      .map(key => animals[key])
      .filter(animal => {
        if (!search) {
          return true
        }

        const animalName = animal.name.toLowerCase()
        const animalType = animal.type.toLowerCase()
        const searchTerm = search.toLowerCase()

        return animalName.indexOf(searchTerm) >= 0 ||
          animalType.indexOf(searchTerm) >= 0
      })
      .sort((a, b) => b.id - a.id)
      .slice(startIndex, endIndex)
  },
  findById: (id) => {
    return animals[id]
  },
  addComment: (id, message, user) => {
    const comment = {
      message,
      user,
      createdOn: new Date()
    }

    animals[id].comments.push(comment)
  },
  allComments: (id) => {
    return animals[id]
      .comments
      .sort((a, b) => b.createdOn - a.createdOn)
      .slice(0)
  },
  reaction: (id, type, user) => {
    const reactions = animals[id].reactions
    const reactionType = reactions[type];

    if (reactionType === undefined) {
      return false
    }

    if (reactionType.indexOf(user) >= 0) {
      return false
    }

    reactionType.push(user)

    return true
  },
  byUser: (user) => {
    return Object
      .keys(animals)
      .map(key => animals[key])
      .filter(animal => animal.createdBy === user)
      .sort((a, b) => b.id - a.id)
  },
  delete: (id) => {
    delete animals[id]
  }
}

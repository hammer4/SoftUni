const pets = {}

module.exports = {
  save: (pet) => {
    const id = Object.keys(pets).length + 1
    pet.id = id

    let newPet = {
      id,
      name: pet.name,
      image: pet.image,
      age: pet.age,
      type: pet.type,
      createdOn: new Date(),
      comments: []
    }

    if (pet.breed) {
      newPet.breed = pet.breed
    }

    pets[id] = newPet
  },
  all: (page) => {
    const pageSize = 10

    let startIndex = (page - 1) * pageSize
    let endIndex = startIndex + pageSize

    return Object
      .keys(pets)
      .map(key => pets[key])
      .sort((a, b) => b.id - a.id)
      .slice(startIndex, endIndex)
  },
  findById: (id) => {
    return pets[id]
  },
  addComment: (id, message, user) => {
    const comment = {
      message,
      user,
      createdOn: new Date()
    }

    pets[id].comments.push(comment)
  },
  allComments: (id) => {
    return pets[id]
      .comments
      .sort((a, b) => b.createdOn - a.createdOn)
      .slice(0)
  }
}

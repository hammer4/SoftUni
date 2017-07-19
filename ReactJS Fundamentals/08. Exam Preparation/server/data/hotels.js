const hotels = {}

module.exports = {
  save: (hotel) => {
    const id = Object.keys(hotels).length + 1
    hotel.id = id

    let newHotel = {
      id,
      name: hotel.name,
      location: hotel.location,
      description: hotel.description,
      numberOfRooms: hotel.numberOfRooms,
      image: hotel.image,
      createdOn: new Date(),
      reviews: []
    }

    if (hotel.parkingSlots) {
      newHotel.parkingSlots = hotel.parkingSlots
    }

    hotels[id] = newHotel
  },
  all: (page) => {
    const pageSize = 10

    let startIndex = (page - 1) * pageSize
    let endIndex = startIndex + pageSize

    return Object
      .keys(hotels)
      .map(key => hotels[key])
      .sort((a, b) => b.id - a.id)
      .slice(startIndex, endIndex)
  },
  findById: (id) => {
    return hotels[id]
  },
  addReview: (id, rating, comment, user) => {
    const review = {
      rating,
      comment,
      user,
      createdOn: new Date()
    }

    hotels[id].reviews.push(review)
  },
  allReviews: (id) => {
    return hotels[id]
      .reviews
      .sort((a, b) => b.createdOn - a.createdOn)
      .slice(0)
  }
}

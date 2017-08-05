let cars = [
  {
    id: 1,
    image: 'https://www.lamborghini.com/en-en/sites/en-en/files/DAM/lamborghini/model/aventador/aventador-coupe/left.jpg',
    make: 'Lamborghini',
    model: 'Aventador',
    description: `The Lamborghini Aventador is a mid-engined sports car produced by the Italian manufacturer Lamborghini.
Launched on 28 February 2011 at the Geneva Motor Show, five months after its initial unveiling in Sant'Agata Bolognese, the vehicle, internally codenamed LB834, was designed to replace the then-decade-old Murciélago as the new flagship model.
Soon after the Aventador unveiling, Lamborghini announced that it had already sold over 12 of the production vehicles, with deliveries starting in the second half of 2011.[8] By March 2016, Lamborghini had already built 5,000 Aventadors, taking five years to achieve this milestone`,
    owner: 1,
    price: 300000,
    engine: '6.5 L L539 V12',
    date: '2015-03-25T12:00:00Z',
    ownerName: '',
    comments: []
  },
  {
    id: 2,
    image: 'https://images.honestjohn.co.uk/imagecache/file/fit/730x700/media/5571135/Ferrari%20Testarossa%20(3).jpg',
    make: 'Ferrari',
    model: 'Testarossa',
    description: `The Ferrari Testarossa (Type F110) is a 12-cylinder mid-engine sports car manufactured by Ferrari, which went into production in 1984 as the successor to the Ferrari Berlinetta Boxer. The Pininfarina-designed car was originally produced from 1984 to 1991, with two model revisions following the ending of Testarossa production and the introduction of the 512 TR and F512 M which were produced from 1992 to 1996. Almost 10,000 Testarossas, 512 TRs, and F512 Ms were produced, making it one of the most-produced Ferrari models, despite its high price and exotic design. In 1995, the F512 M retailed for $220,000 (£136,500)`,
    owner: 2,
    price: 200000,
    engine: '4.9 L F12 291 kW (390 hp)',
    date: '2015-03-25T20:00:00Z',
    ownerName: '',
    comments: []
  },
  {
    id: 3,
    image: 'http://www.mercedes-w140.info/blog/wp-content/uploads/2012/08/Mercedes-W140-1.jpg',
    make: 'Mercedes',
    model: 'W140',
    description: `The Mercedes-Benz W140 is a series of flagship vehicles that were manufactured by the German automotive company Mercedes-Benz. On November 16, 1990, Mercedes-Benz unveiled the W140 S-Class via press release, later appearing in several February and March editions of magazines.[3] The W140 made its public debut at the Geneva Motor Show in March 1991, with the first examples rolling off the production line in April 1991 and North American examples on August 6, 1991. Short (SE) and long (SEL) wheelbase sedans were offered initially, as well as the coupé (SEC=S-Klasse-Einspritzmotor(Fuel injection engine)-Coupé) body style C140 from October 1992. Like all Mercedes-Benz lines, the W140 S-Class was rationalized in late 1993 using the new "letter-first" nomenclature. The SE, SEL, and SEC cars were renamed the S-Class, with alphanumerical designations inverted. For example, the 500 SE became the S 500, and the 500 SEL became the S 500 L. In 1996 the coupé models following a mid-life update were separated into the CL-Class. The W140 series S-Class was superseded by the W220 S-Class sedan and C215 CL-Class coupe in 1999 after an eight-year production run.`,
    owner: 3,
    price: 90000,
    engine: '6.0 48V V12',
    date: '2015-03-25T13:00:00Z',
    ownerName: '',
    comments: []
  },
  {
    id: 4,
    image: 'https://i.ytimg.com/vi/MeZkNzIGjhY/maxresdefault.jpg',
    make: 'Audi',
    model: 'S8',
    description: `The Audi A8 is a four-door, full-size, luxury sedan manufactured and marketed by the German automaker Audi since 1994. Succeeding the Audi V8, and now in its third generation, the A8 has been offered with both front- or permanent all-wheel drive—and in short- and long-wheelbase variants. The first two generations employed the Volkswagen Group D platform, with the current generation deriving from the MLB platform. After the original model's 1994 release, Audi released the second generation in late 2002, and the third and current iteration in late 2009.
Notable for being the first mass-market car with an aluminium chassis, all A8 models have used this construction method co-developed with Alcoa and marketed as the Audi Space Frame.
A mechanically-upgraded, high-performance version of the A8 debuted in 1996 as the Audi S8. Produced exclusively at Audi's Neckarsulm plant, unlike the donor A8 model, the S8 has been available only in short-wheelbase form and is fitted standard with Audi's quattro all-wheel drive system.`,
    owner: 1,
    price: 190000,
    engine: '3,993 cc (243.7 cu in) V8 twin turbo',
    date: '2015-04-25T20:00:00Z',
    ownerName: '',
    comments: []
  },
  {
    id: 5,
    image: 'https://hips.hearstapps.com/roa.h-cdn.co/assets/14/47/4000x2000/546b3eccc3ea8_-_bmw850csi015-lg.jpg?resize=480:*',
    make: 'BMW',
    model: '850csi',
    description: `As a top-of-the-range sports tourer, the 850CSi took over from the prototype M8. The 850CSi used the same engine as the 850i, which was tuned so significantly that BMW assigned it a new engine code: S70B56. The modifications included a capacity increase to 5.6 liters and power increase to 380 PS (279 kW; 375 hp).`,
    owner: 2,
    price: 150000,
    engine: '280 kW (381 PS; 375 hp)',
    date: '2015-03-26T20:00:00Z',
    ownerName: '',
    comments: []
  },
  {
    id: 6,
    image: 'https://i.ytimg.com/vi/8ZvDbD40IhI/maxresdefault.jpg',
    make: 'Toyota',
    model: 'Supra',
    description: `The Toyota Supra is a sports car/grand tourer that was produced by Toyota Motor Corporation from 1978 to 2002. The styling of the Toyota Supra was derived from the Toyota Celica, but it was both longer and wider.[2] Starting in mid-1986, the A70 Supra became a separate model from the Celica. In turn, Toyota also stopped using the prefix Celica and began just calling the car Supra.[3] Owing to the similarity and past of the Celica's name, it is frequently mistaken for the Supra, and vice versa. First, second, and third generation Supras were assembled at Tahara plant in Tahara, Aichi while the fourth generation Supra was assembled at the Motomachi plant in Toyota City.`,
    owner: 1,
    price: 85000,
    engine: '2.0-liter 210 PS (154 kW)',
    date: '2015-03-27T20:00:00Z',
    ownerName: '',
    comments: []
  }
]

let owners = [
  {
    id: 1,
    name: 'Pesho Dimitrov',
    image: 'https://www.residentadvisor.net/images/profiles/pesho.jpg',
    carsLength: 0,
    cars: []
  },
  {
    id: 2,
    name: 'Gosho Petrov',
    image: 'https://media.licdn.com/mpr/mpr/shrinknp_200_200/p/8/005/013/19c/0d7bb85.jpg',
    carsLength: 0,
    cars: []
  },
  {
    id: 3,
    name: 'Stamat Ivanov',
    image: 'https://a2-images.myspacecdn.com/images03/21/132291e86d8646eb9ed51f9886c0c9b4/300x300.jpg',
    carsLength: 0,
    cars: []
  }
]

let comments = [
  {
    id: 1,
    car: 1,
    content: 'Very nice car. So much power'
  },
  {
    id: 2,
    car: 1,
    content: 'What a beast'
  },
  {
    id: 3,
    car: 1,
    content: 'I wish I had one of these'
  },
  {
    id: 4,
    car: 2,
    content: 'Italian monster'
  },
  {
    id: 5,
    car: 2,
    content: 'Retro power'
  },
  {
    id: 6,
    car: 3,
    content: 'Classic'
  },
  {
    id: 7,
    car: 3,
    content: 'The best limousine'
  },
  {
    id: 8,
    car: 4,
    content: 'Audi is the best'
  },
  {
    id: 9,
    car: 4,
    content: 'If I win the lottery I would buy one'
  }
]

const data = {
  getLatestCars: () => {
    return new Promise((resolve, reject) => {
      resolve(cars.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime()).slice(0, 7))
    })
  },

  getAllCars: () => {
    return new Promise((resolve, reject) => {
      cars.forEach(car => car.ownerName = owners.find(o => o.id === car.owner).name)
      resolve(cars.sort((a, b) => new Date(b.date).getTime() - new Date(a.date).getTime()))
    })
  },

  getCarById: (id) => {
    return new Promise((resolve, reject) => {
      let car = cars.find(car => car.id === id)
      car.ownerName = owners.find(owner => owner.id === car.owner).name
      car.comments = comments.filter(c => c.car === id)
      resolve(car)
    })
  },

  getAllOwners: () => {
    return new Promise((resolve, reject) => {
      owners.forEach(owner => owner.carsLength = cars.filter(c => c.owner === owner.id).length)
      resolve(owners.sort((a, b) => a.name.localeCompare(b.name)))
    })
  },

  getOwnerById: (id) => {
    return new Promise((resolve, reject) => {
      let owner = owners.find(owner => owner.id === id)
      owner.cars = cars.filter(car => car.owner === id)
      resolve(owner)
    })
  },

  createOwner: (owner) => {
    return new Promise((resolve, reject) => {
      owner.id = owners.length + 1
      owners.push(owner)
      resolve(owner)
    })
  },

  createCar: (car) => {
    return new Promise((resolve, reject) => {
      car.id = cars.length + 1
      car.date = new Date().toISOString()
      car.ownerName = ''
      car.comments = []
      car.owner = Number(car.owner)
      cars.push(car)
      resolve(car)
    })
  },

  createComment: (car, content) => {
    return new Promise((resolve, reject) => {
      car = Number(car);
      let id = comments.length + 1;
      comments.push({
        id: id,
        car: car,
        content: content
      });

      resolve(car);
    })
  },

  updateOwner: (updatedOwner) => {
    return new Promise((resolve, reject) => {
      let oldOwner = owners.find(owner => owner.id === updatedOwner.id)
      oldOwner.name = updatedOwner.name
      oldOwner.image = updatedOwner.image
      resolve(oldOwner)
    })
  },

  updateCar: (updatedCar) => {
    return new Promise((resolve, reject) => {
      let oldCar = cars.find(car => car.id === updatedCar.id)
      oldCar.description = updatedCar.description
      oldCar.engine = updatedCar.engine
      oldCar.image = updatedCar.image
      oldCar.make = updatedCar.make
      oldCar.model = updatedCar.model
      oldCar.owner = Number(updatedCar.owner)
      oldCar.price = updatedCar.price
      resolve(oldCar)
    })
  },

  getCommentById: (id) => {
    return new Promise((resolve, reject) => {
      resolve(comments.find(c => c.id === id))
    })
  },

  updateComment: (id, content) => {
    return new Promise((resolve, reject) => {
      let comment = comments.find(c => c.id === id)
      comment.content = content
      resolve(comment)
    })
  }
}

export default data

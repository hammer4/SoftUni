let database = require('./database');
let instanodeDb = require('./instanode-db');

database().then(()=> {

    // TODO: run these blocks one by one. Only one at a time.

    // instanodeDb.saveImage({
    //     url: 'https://ocdn.eu/images/pulscms/MTc7MDMsMmU0LDAsMSwx/9dadb605867c4a3728b85330993d786a.jpg',
    //     description: 'Mnogo qk traktor',
    //     tags: ['traktor', 'lamborghini', 'power']
    // });

    // instanodeDb.saveImage({
    //     url: 'http://i3.mirror.co.uk/incoming/article7785047.ece/ALTERNATES/s1200/Jurgen-Klopp.jpg',
    //     description: 'Jurgen Klopp laughs',
    //     tags: ['Jurgen Klopp', 'smile', 'Liverpool']
    // });

    // instanodeDb.saveImage({
    //     url: 'http://avto-russia.ru/autos/lamborghini/photo/lamborghini_aventador_1280x1024.jpg',
    //     description: 'Aventador on the road',
    //     tags: ['lamborghini', 'aventador']
    // });

    // instanodeDb.findByTagName('lamborghini').then((images) => {
    //     for (let image of images) {
    //         console.log(image);
    //     }
    // })

    instanodeDb.filter({limit: 2}).then((images) => {
        for(let image of images) {
            console.log(image);
        }
    })
})
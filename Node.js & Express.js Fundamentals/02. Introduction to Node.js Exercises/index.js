const storage = require('./storage');

storage.put("first", "some value");
storage.put("second", true);
storage.put("third", 3);

let someValue = storage.get('first');
console.log(someValue);

storage.update('first', 'another value');
let anotherValue = storage.get('first');
console.log(anotherValue);

storage.delete('first');
// storage.get('first');

storage.clear();
// storage.get('second');

storage.put("second", true);
storage.put("third", 3);

storage.save().then(() => {
    storage.clear();

    storage.load().then(() => {
        let afterLoadValue = storage.get('second');
        console.log(afterLoadValue);
    }).catch(err => console.log(err));
}).catch(err => console.log(err));
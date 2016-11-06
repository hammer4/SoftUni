let Entity = require('./entity');

class Dog extends Entity{
    constructor(name){
        super(name);
    }

    saySomething(){
        return `${this.name} barks!`;
    }
}

module.exports = Dog;
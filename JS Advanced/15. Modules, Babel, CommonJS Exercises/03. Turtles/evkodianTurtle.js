let Turtle = require('./turtle');

class EvkodianTurtle extends Turtle{
    constructor(name, age, gender, evkodiumValue){
        super(name, age, gender);
        this._evkodium = evkodiumValue;
    }

    get evkodium(){
        let value = this._evkodium;
        let density = this.gender == "male" ? this.age * 3 : this.age * 2;

        return {
            value: value,
            density: density
        }
    }

    toString(){
        return super.toString() + `\nEvkodium: ${this.evkodium.value * this.evkodium.density}`;
    }
}

module.exports = EvkodianTurtle;
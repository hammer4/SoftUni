class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat){
        if(otherRat instanceof Rat) {
            this.unitedRats.push(otherRat);
        }
    }

    getRats(){
        return this.unitedRats;
    }

    toString(){
        let string = `${this.name}\n`;
        for (let rat of this.unitedRats){
            string += `##${rat.name}\n`;
        }
    }
}
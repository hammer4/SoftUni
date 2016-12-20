class Player{
    constructor(nickName){
        this.nickName = nickName;
        this._scores = [];
    }

    addScore(num){
        if(!isNaN(parseFloat(num)) && isFinite(num)){
            this._scores.push(Number(num));
        }
        return(this);
    }

    get scoreCount(){
        return this._scores.length;
    }

    get highestScore(){
        return this._scores.sort((a, b) => b-a)[0];
    }

    get topFiveScore(){
        return this._scores.sort((a, b) => b-a).slice(0, 5);
    }

    toString(){
        return `${this.nickName}: [${this._scores.sort((a, b) => b-a)}]`;
    }
}

let peter = new Player("Peter"); console.log('Highest score: ' + peter.highestScore); console.log(`Top 5 score: [${peter.topFiveScore}]`); console.log('' + peter); console.log('Score count: ' + peter.scoreCount); peter.addScore(450); peter.addScore('200'); console.log('Highest score: ' + peter.highestScore); console.log(`Top 5 score: [${peter.topFiveScore}]`); console.log('' + peter); peter.addScore(2000); peter.addScore(300); peter.addScore(50); peter.addScore(700); peter.addScore(700);
console.log('Highest score: ' + peter.highestScore); console.log(`Top 5 score: [${peter.topFiveScore}]`); console.log('' + peter); console.log('Score count: ' + peter.scoreCount); console.log(); let maria = new Player("Maria") .addScore(350) .addScore(779) .addScore(180); console.log('Highest score: ' + maria.highestScore); console.log(`Top 5 score: [${maria.topFiveScore}]`); console.log('' + maria);
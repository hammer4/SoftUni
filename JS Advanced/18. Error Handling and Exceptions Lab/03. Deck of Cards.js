function deckOfCards(cards) {
    class Card{
        constructor(face, suit){
            this.face = face;
            this.suit = suit;
        }

        get face(){
            return this._face;
        }
        set face(newFace){
            const validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
            if(! validFaces.includes(newFace)){
                throw new Error("Invalid card face: " + newFace);
            }

            this._face = newFace;
        }

        get suit(){
            return this._suit;
        }
        set suit(newSuit){
            const validSuits = ['C', 'D', 'H', 'S'];
            if(! validSuits.includes(newSuit)){
                throw new Error("Invalid card suit: " + newSuit);
            }

            this._suit = newSuit;
        }

        toString(){
            let suitToChar = {
                'C': "\u2663",
                'D': "\u2666",
                'H': "\u2665",
                'S': "\u2660"
            };

            return this.face + suitToChar[this.suit];
        }
    }

    let deck = [];
    for(let cardStr of cards){
        let face = cardStr.substring(0, cardStr.length - 1);
        let suit = cardStr.substr(cardStr.length - 1, 1);

        try {
            deck.push(new Card(face, suit));
        } catch(err) {
            console.log("Invalid card: " + cardStr);
            return;
        }
    }

    console.log(deck.join(" "));
}

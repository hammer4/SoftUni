function cardDeckBuilder(selector) {
    function addCard(face, suit) {
        switch (suit){
            case "C": suit = "\u2663"; break;
            case "D": suit = "\u2666"; break;
            case "H": suit = "\u2665"; break;
            case "S": suit = "\u2660"; break;
        }
        $(selector).append($('<div>').addClass("card").text(`${face} ${suit}`).click(reverseCards));

        function reverseCards() {
            let cardsArray = $(selector + " div.card").toArray();
            cardsArray.reverse();
            $(selector + " div.card").remove();

            for(let card of cardsArray){
                $(selector).append($(card).click(reverseCards));
            }
        }
    }

    return {addCard};
}
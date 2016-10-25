function monkeyPatcher(action) {
    let that = this;
    let obj = (() => {
        function upvote() { that.upvotes++}
        function  downvote() {that.downvotes++}
        function score() {
            let obfuscated = that.upvotes + that.downvotes > 50;
            let votesToAdd = Math.ceil(0.25 * Math.max(that.upvotes, that.downvotes));
            let rating;
            if(that.upvotes/(that.upvotes+that.downvotes) > 0.66){
                rating = "hot";
            } else if((that.upvotes > 100 || that.downvotes > 100) && that.upvotes >= that.downvotes){
                rating = "controversial";
            } else if(that.downvotes > that.upvotes){
                rating = "unpopular";
            } else {
                rating = "new";
            }

            if(that.upvotes + that.downvotes < 10){
                rating = "new";
            }

            if(obfuscated){
                return [that.upvotes + votesToAdd, that.downvotes + votesToAdd, that.upvotes - that.downvotes, rating];
            } else {
                return [that.upvotes, that.downvotes, that.upvotes - that.downvotes, rating];
            }
        }
        return {upvote, downvote, score};
    })();

    return obj[action]();
}

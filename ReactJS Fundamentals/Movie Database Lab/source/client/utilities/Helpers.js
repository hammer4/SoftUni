export default class Helpers {
    static formatMovieRating (score, votes) {
        let rating = score/votes

        if (isNaN(rating)) {
            rating = 0
        }

        if (rating %1 !== 0) {
            rating = rating.toFixed(1)
        }

        return rating
    }
}
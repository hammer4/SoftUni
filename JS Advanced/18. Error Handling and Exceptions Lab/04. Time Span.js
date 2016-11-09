class TimeSpan{
    constructor(hours, minutes, seconds){
        if(! Number.isInteger(hours)){
            throw new RangeError("Invalid hours: " + hours);
        }
        if(! Number.isInteger(minutes)){
            throw new RangeError("Invalid minutes: " + minutes);
        }
        if(! Number.isInteger(seconds)){
            throw  new RangeError("Invalid seconds: " + seconds);
        }

        this._seconds = seconds + 60 * minutes + 60 * 60 * hours;
    }

    toString(){
        let seconds = this._seconds % 60;
        let minutes = Math.trunc(this._seconds / 60) % 60;
        let hours = Math.trunc(this._seconds / (60 * 60));

        seconds = ("0" + seconds).slice(-2);
        minutes = ("0" + minutes).slice(-2);

        return `${hours}:${minutes}:${seconds}`;
    }
}

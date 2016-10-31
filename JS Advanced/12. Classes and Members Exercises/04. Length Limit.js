class Stringer{
    constructor(string, length){
        this.innerString = string;
        this.innerLength = length;
    }

    increase(length){
        this.innerLength += length;
        if(this.innerLength < 3){
            this.innerLength = 0;
        }
    }

    decrease(length){
        this.innerLength -= length;
        if(this.innerLength < 3){
            this.innerLength = 0;
        }
    }

    toString(){
        if(this.innerLength == 0){
            return "...";
        }

        if(this.innerString.length > this.innerLength){
            this.innerString = this.innerString.substr(0, this.innerLength) + "...";
        }
        return this.innerString;
    }
}

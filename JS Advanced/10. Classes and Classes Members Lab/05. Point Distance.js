class Point{
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(a, b){
        return Math.sqrt(Math.pow(a.x - b.x, 2) + Math.pow(a.y -b.y, 2));
    }
}


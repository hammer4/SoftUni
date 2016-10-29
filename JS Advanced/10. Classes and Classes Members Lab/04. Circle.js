class Circle{
    constructor(radius){
        this.radius = radius;
    }

    get diameter(){
        return this.radius * 2;
    }
    set diameter(diameter){
        this.radius = diameter / 2;
    }

    get area(){
        return Math.pow(this.radius, 2) * Math.PI;
    }
}


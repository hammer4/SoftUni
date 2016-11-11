function parseData(recipes) {
    class Candy{
        constructor(topping, filling, spice){
            this.topping = topping;
            this.filling = filling;
            this.spice = spice;
        }

        get topping(){
            return this._topping;
        }
        set topping(newTopping){
            let validToppings = ["milk chocolate", "white chocolate", "dark chocolate"];
            if(! validToppings.includes(newTopping)){
                throw new TypeError("Invalid topping.");
            }

            this._topping = newTopping;
        }

        get filling(){
            return this._filling;
        }
        set filling(newFilling){
            if(newFilling === null){
                this._filling = newFilling;
            } else {
                let tokens = newFilling.split(",");
                let validFillings = ['hazelnut', 'caramel', 'strawberry', 'blueberry', 'yogurt', 'fudge'];
                if (tokens.length > 3 || tokens.some(t => !validFillings.includes(t))) {
                    throw new TypeError("Invalid filling");
                }
            }
            this._filling = newFilling;
        }

        get spice(){
            return this._spice;
        }
        set spice(newSpice){
            let invalidSpices = ['poison', 'asbestos'];

            if(invalidSpices.includes(newSpice)){
                throw new TypeError("Invalid spice");
            }

            this._spice = newSpice;
        }
    }

    let candys = [];
    for(let recipe of recipes){

        try{
            let tokens = recipe.split(":");
            if(tokens.length !== 3){
                throw new Error("Invalid input.")
            }
            for(let i =0; i < tokens.length; i++){
                if(tokens[i] == ""){
                    tokens[i] = null;
                }
            }
            let candy = new Candy(tokens[0], tokens[1], tokens[2]);
            candys.push(candy);
        } catch(error){

        }
    }

    return candys;
}


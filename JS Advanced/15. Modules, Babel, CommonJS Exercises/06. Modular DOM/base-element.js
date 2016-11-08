class BaseElement{
    constructor(){
        if(new.target == BaseElement){
            throw new Error("Cannot make instance of abstract class BaseElement")
        }
        this.element = null;
    }

    appendTo(selector){
        this.createElement();
        $(selector).append(this.element);
    }

    createElement(){
        this.element = this.getElementString();
    }

    getElementString(){
        return undefined;
    }
}

module.exports = BaseElement;
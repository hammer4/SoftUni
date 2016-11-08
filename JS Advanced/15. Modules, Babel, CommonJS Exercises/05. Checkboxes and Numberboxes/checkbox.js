class Checkbox{
    constructor(label, selector){
        this._label = label;
        this.selector = selector;
        this.value = $(selector).is(':checked');
        let that = this;
        $(selector).change(function () {
            that.value = $(this).is(':checked');
        });
    }

    get label(){
        return this._label;
    }

    get elements(){
        return $(this.selector);
    }
    
    get value(){
        return this._value;
    }
    set value(newValue){
        if(typeof newValue != 'boolean'){
            throw new Error("Value must be boolean");
        }
        
        this._value = newValue;
        this.elements.prop('checked', newValue)
    }
}

module.exports = Checkbox;
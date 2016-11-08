class Numberbox{
    constructor(label, selector, minValue, maxValue){
        this._label = label;
        this.selector = selector;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.value = this.minValue;
        let that = this;
        $(selector).on('input change', function(){
            that.value = $(this).val();
        });
    }

    get label(){
        return this._label;
    }

    get elements(){
        return $(this.selector)
    }
    
    get value(){
        return this._value;
    }
    set value(newValue){
        if(Number(newValue) < this.minValue || Number(newValue) > this.maxValue || Number(newValue) % 1 != 0){
            throw new Error("Number too small or too big");
        }

        this._value = Number(newValue);
        this.elements.val(newValue);
    }
}

module.exports = Numberbox;
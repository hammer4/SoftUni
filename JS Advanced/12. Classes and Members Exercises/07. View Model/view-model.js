class Textbox {
    constructor(selector, invalidSymbolsRegex){
        this.selector = selector;
        this._invalidSymbols = invalidSymbolsRegex;
        this._elements = $(this.selector);
        $(this.selector).on('input', function () {
            $('*[type=text]').val(this.value);
        });

    }

    get value(){
        return this.elements.val();
    }
    set value(newValue){
        this.elements.val(newValue);
    }

    get elements(){
        return this._elements;
    }

    isValid(){
        return ! this.value.match(this._invalidSymbols);
    }
}


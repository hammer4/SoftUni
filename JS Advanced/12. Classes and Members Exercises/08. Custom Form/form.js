(function() {

    class Textbox {
        constructor(selector, invalidSymbolsRegex){
            this.selector = selector;
            this._invalidSymbols = invalidSymbolsRegex;
            this._elements = $(this.selector);
            let that = this;
            $(this.selector).on('input', function () {
                that.value = this.value;
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

    class Form {
        constructor(...textboxes){
            if(textboxes.some(t => !(t instanceof Textbox))){
                throw new Error("Some of the constructor arguments are not a Textbox");
            } else {
                this._textboxes = textboxes;
                this._element = $('<div>').addClass('form');
                for(let textbox of textboxes){
                    this._element.append($(textbox.selector));
                }
            }
        }

        submit(){
            let allValid = true;
            for(let textbox of this._textboxes){
                if(textbox.isValid()){
                    $(textbox.selector).css('border', '2px solid green');
                } else {
                    $(textbox.selector).css('border', '2px solid red');
                    allValid = false;
                }
            }
            return allValid;
        }

        attach(selector){
            $(selector).append($(this._element));
        }
    }

    return {
        Textbox: Textbox,
        Form: Form
    }
}());

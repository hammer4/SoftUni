function objectIterator(obj) {
    let arrayOfKeys = Array.from(Object.keys(obj)).sort();
    let index = arrayOfKeys.length - 1;

    return {
        next: function () {
            if(index >= 0){
                return {
                    value: arrayOfKeys[index--],
                    done: false
                };
            } else {
                return{
                    done: true
                };
            }
        }
    }
}


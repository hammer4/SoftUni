function reverseIterator(arr) {
    let index = arr.length - 1;

    return {
        next: function () {
            if(index >= 0){
                return {
                    value: arr[index--],
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
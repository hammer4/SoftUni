function aggregateElements(arr) {
    let elements = arr.map(Number);

    function aggregate(array, initVal, func) {
        let val = initVal;

        for(let i = 0; i< arr.length; i++) {
            val = func(val, array[i]);
        }

        console.log(val);
    }

    aggregate(elements, 0, (a, b) => a + b);
    aggregate(elements, 0, (a, b) => a + 1/b);
    aggregate(elements, "", (a, b) => a + b);
}

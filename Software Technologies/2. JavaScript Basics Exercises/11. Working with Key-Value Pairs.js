function workingWithKeyValuePairs(arr) {
    let object = {};
    for(let i=0; i<arr.length-1; i++) {
        let tokens = arr[i].split(' ');
        let key = tokens[0];
        let value = tokens[1];
        object[key] = value;
    }

    if(object.hasOwnProperty(arr[arr.length-1])) {
        console.log(object[arr[arr.length-1]]);
    } else {
        console.log("None");
    }
}

function uniqueSequences(input) {
    let arraysSet = [];

    for(let line of input) {
        let arr = JSON.parse(line);
        arraysSet.push(arr.map(Number).sort((a, b) => b - a));
    }

    let uniqueArrays = [];

    for(let i=0; i<arraysSet.length; i++) {
        let haveEqual = false;

        for(let j= i+1; j<arraysSet.length; j++) {

            if(compareArrays(arraysSet[i], arraysSet[j])){
                arraysSet.splice(j, 1);
                j--;
            }
        }
    }


    arraysSet.sort((a, b) => a.length - b.length);
    arraysSet.forEach(a => console.log("[" + a.join(", ") + "]"));

    function compareArrays(arr1, arr2) {
        if(arr1.length != arr2.length) {
            return false;
        } else {
            for(let i=0; i<arr1.length; i++) {
                if(arr1[i] != arr2[i]){
                    return false;
                }
            }
            return true;
        }
    }
}

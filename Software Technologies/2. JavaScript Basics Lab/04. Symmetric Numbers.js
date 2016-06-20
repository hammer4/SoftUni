function symmetricNumbers(arr) {
    let end = Number(arr[0]);
    for(let i=1; i<=end; i++) {
        if(isSymetricNumber("" + i)){
            console.log((i));
        }
    }

    function isSymetricNumber(num) {
        for(let i=0; i<num.length; i++) {
            if(num[i] != num[num.length - 1 - i]) {
                return false;
            }
        }

        return true;
    }
}

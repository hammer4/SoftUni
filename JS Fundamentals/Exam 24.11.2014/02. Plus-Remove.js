function plusRemove(input) {
    let arr = [];
    let result = [];
    for(let line of input){
        arr.push(line.toLowerCase());
        result.push(Array.from(line));
    }

    for(let i=0; i<arr.length-2; i++){
        for(j=1; j<arr[i].length; j++){
            if(arr[i+1][j-1] != undefined && arr[i+1][j] != undefined && arr[i+1][j+1] != undefined && arr[i+2][j] != undefined) {
                if (arr[i][j] == arr[i + 1][j - 1] && arr[i][j] == arr[i + 1][j] && arr[i][j] == arr[i + 1][j + 1] && arr[i][j] == arr[i + 2][j]) {
                    result[i][j] = result[i + 1][j - 1] = result[i + 1][j] = result[i + 1][j + 1] = result[i + 2][j] = " ";
                }
            }
        }
    }

    for(let i=0; i<result.length; i++){
        result[i] = result[i].filter(ch => ch != " ");
    }

    for(let line of result){
        line = line.join("");
        console.log(line);
    }

}

function xRemove(input) {
    let arr = [];
    let result = [];
    for(let line of input){
        arr.push(line.toLowerCase());
        result.push(Array.from(line));
    }

    for(let i=0; i<arr.length-2; i++){
        for(j=0; j<arr[i].length; j++){
            if(arr[i][j+2] != undefined && arr[i+1][j+1] != undefined && arr[i+2][j] != undefined && arr[i+2][j+2] != undefined) {
                if (arr[i][j] == arr[i][j +2] && arr[i][j] == arr[i + 1][j+1] && arr[i][j] == arr[i + 2][j] && arr[i][j] == arr[i + 2][j+2]) {
                    result[i][j] = result[i][j + 2] = result[i + 1][j + 1] = result[i + 2][j] = result[i + 2][j + 2] = " ";
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

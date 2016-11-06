function mapSort(map, sortFn) {
    if(! sortFn){
        sortFn = function (a, b) {
            return a[0].toString().localeCompare(b[0].toString())
        }
    }
    let newMap = new Map();
    Array.from(map.entries()).sort(sortFn).forEach(e => newMap.set(e[0], map.get(e[0])));

    return newMap;
}


module.exports = mapSort;

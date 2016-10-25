function sortArray(array, method) {
    let ascendingComparator = (a, b) => a-b;
    let descendingComparator = (a, b) => b-a;

    let sortingStrategies = {
        asc: ascendingComparator,
        desc: descendingComparator
    };

    return array.sort(sortingStrategies[method]);
}

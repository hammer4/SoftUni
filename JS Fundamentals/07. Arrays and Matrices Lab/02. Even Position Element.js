function evenPositionElements(arr) {
    return arr.filter((num, index) => index % 2 == 0).join(' ');
}

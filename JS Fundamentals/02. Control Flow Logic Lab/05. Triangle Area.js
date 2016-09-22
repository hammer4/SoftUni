function triangleArea(arr) {
    arr = arr.map(Number);
    let sideA = arr[0], sideB = arr[1], sideC = arr[2];
    let semiperimeter = (sideA + sideB + sideC)/2;
    let area = Math.sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
    console.log(area);
}

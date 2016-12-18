function spiceMustFlow([currentYield]) {
    currentYield = Number(currentYield);
    let harvest = 0;
    let daysCount = 0;

    while (currentYield >= 100){
        harvest += currentYield;
        daysCount++;
        currentYield -= 10;
        harvest -= 26;
    }

    if(daysCount > 0){
        harvest -= 26;
    }

    console.log(daysCount);
    console.log(harvest);
}

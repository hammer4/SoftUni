function buildAWall(arr) {
    arr = arr.map(x => Number(x));
    let totalCost = 0;
    let dailyConcreteUsage = [];
    arr = arr.filter(x => x < 30)

    while(arr.length){
        let dailyUsage = 0;
        arr.forEach(x => dailyUsage += 195);
        arr = arr.map(x => x+=1).filter(x => x != 30);
        dailyConcreteUsage.push(dailyUsage);
        totalCost += dailyUsage*1900;
    }

    console.log(dailyConcreteUsage.join(", "));
    console.log(`${totalCost} pesos`);
}

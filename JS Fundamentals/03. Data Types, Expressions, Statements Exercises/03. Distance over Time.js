function distanceOverTime([speed1, speed2, timeInSeconds]) {
    let distance1 = (speed1 / 3.6) * timeInSeconds;
    let distance2 = (speed2 / 3.6) * timeInSeconds;

    console.log(Math.abs(distance1 - distance2));
}

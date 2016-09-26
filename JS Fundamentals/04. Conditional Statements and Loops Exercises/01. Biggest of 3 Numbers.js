function biggestOf3Numbers([num1, num2, num3]) {
    [num1, num2, num3] = [num1, num2, num3].map(Number);
    console.log(Math.max(num1, num2, num3));
}

function matchMultiplication([input]) {
    input = input.replace(/(-?\d+)\s*\*\s*(-?\d+(\.\d+)?)/g, (match, num1, num2) => Number(num1) * Number(num2));
    console.log(input);
}
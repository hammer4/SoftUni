function restaurantBill(input) {
    let products = input.filter((el, index) => index % 2 == 0);
    let sum = input.filter((el, index) => index % 2 == 1).map(Number).reduce((a, b) => a+b);
    console.log(`You purchased ${products.join(", ")} for a total sum of ${sum}`);
}

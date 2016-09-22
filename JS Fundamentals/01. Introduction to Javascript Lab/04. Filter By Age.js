function filterByAge(arr) {
    let minAge = Number(arr[0]);
    let person1 = {name: arr[1], age: Number(arr[2])};
    let person2 = {name: arr[3], age: Number(arr[4])};

    if(person1.age >= minAge) {
        console.log(person1);
    }

    if(person2.age >= minAge) {
        console.log(person2);
    }
}

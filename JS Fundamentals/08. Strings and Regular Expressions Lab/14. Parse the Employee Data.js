function parseTheEmployeeData(input) {
    let regex = /^([A-Z][a-zA-Z]*) - ([1-9][0-9]*) - ([a-zA-Z0-9\- ]+)$/;
    for(let employee of input) {
        let match = regex.exec(employee);
        if(match) {
            console.log(`Name: ${match[1]}`);
            console.log(`Position: ${match[3]}`);
            console.log(`Salary: ${match[2]}`);
        }
    }
}

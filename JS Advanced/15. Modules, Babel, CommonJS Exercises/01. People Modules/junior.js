let Employee = require('./employee');

class Junior extends Employee{
    constructor(name, age){
        super(name, age);
        this.tasks.push("is working on a simple task.");
    }
}

module.exports = Junior;
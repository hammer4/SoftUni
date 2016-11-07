class Employee{
    constructor(name, age){
        if(new.target == Employee){
            throw new Error("Cannot make instance of abstract class Employee.");
        }
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    work(){
        let currentTask = this.tasks.shift();
        console.log(`${this.name} ` + currentTask);
        this.tasks.push(currentTask);
    }

    getSalary(){
        return this.salary;
    }

    collectSalary(){
        console.log(`${this.name} received ${this.getSalary()} this month.`)
    }
}

module.exports = Employee;
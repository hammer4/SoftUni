let Employee = require('./employee');

class Branch{
    constructor(id, branchName, companyName){
        this.id = id;
        this.branchName = branchName;
        this.companyName = companyName;
        this.listOfEmployees = [];
    }

    get employees(){
        return this.listOfEmployees;
    }

    hire(employee){
        this.listOfEmployees.push(employee);
    }

    toString(){
        let output = `@ ${this.companyName}, ${this.branchName}, ${this.id}\n` + `Employed:`;
        if(this.employees.length == 0){
            output += "\nNone...";
        } else {
            this.employees.forEach(e => output += `\n** ${e.toString()}`);
        }
        
        return output;
    }
}

module.exports = Branch;
function usersModule(input) {
    let sortingCriteria = input.shift();
    let sortingTokens = sortingCriteria.split("^");
    let studentSortingCriteria = sortingTokens[0];

    let obj = {
        students: [],
        trainers: []
    };

    let inputObjSorted = {
        students: [],
        trainers: []
    };

    for(let line of input){
        let inputObj = JSON.parse(line);

        if(inputObj.role == "student"){
            inputObjSorted.students.push(inputObj)
        } else {
            inputObjSorted.trainers.push(inputObj)
        }
    }

    if(studentSortingCriteria == "level"){
        inputObjSorted.students = inputObjSorted.students.sort((a, b) => a.level - b.level || a.id - b.id)
    } else {
        inputObjSorted.students = inputObjSorted.students.sort((a, b) => a.firstname.localeCompare(b.firstname) || a.lastname.localeCompare(b.lastname));
    }
    inputObjSorted.trainers = inputObjSorted.trainers.sort((a, b) => a.courses.length - b.courses.length || a.lecturesPerDay - b.lecturesPerDay);

    for(let student of inputObjSorted.students){
        let ob = {};
        ob['id'] = student.id;
        ob['firstname'] = student.firstname;
        ob['lastname'] = student.lastname;
        ob['averageGrade'] = (student.grades.map(Number).reduce((a, b) => a+b) / student.grades.length).toFixed(2);
        ob['certificate'] = student.certificate;
        obj.students.push(ob);
    }

    for(let trainer of inputObjSorted.trainers){
        let ob ={};
        ob['id'] = trainer.id;
        ob['firstname'] = trainer.firstname;
        ob['lastname'] = trainer.lastname;
        ob['courses'] = trainer.courses;
        ob['lecturesPerDay'] = trainer.lecturesPerDay;
        obj.trainers.push(ob);
    }

    console.log(JSON.stringify(obj));
}

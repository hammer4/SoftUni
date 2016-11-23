function students() {
    let baseSurviceUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/students";
    let kinveyUsername = "guest";
    let kinveyPassword = "guest";
    let base64Auth = btoa(kinveyUsername + ":" + kinveyPassword);

    loadStudents();

    function loadStudents() {
        let request = {
            url: baseSurviceUrl,
            method: "GET",
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.get(request)
            .then(displayStudents);
    }

    function displayStudents(students) {
        $('#results').find('tr').nextAll().remove();
        students = students.sort((a,b) => a.ID - b.ID);
        for(let student of students){
            $("#results")
                .append($('<tr>')
                    .append($('<td>').text(student.ID))
                    .append($('<td>').text(student.FirstName))
                    .append($('<td>').text(student.LastName))
                    .append($('<td>').text(student.FacultyNumber))
                    .append($('<td>').text(student.Grade))
                );
        }
    }

    $('#addStudent').click(function (ev) {
        ev.preventDefault();
        let ID = Number($('#ID').val());
        let FirstName = $('#FirstName').val();
        let LastName = $('#LastName').val();
        let FacultyNumber = $('#FacultyNumber').val();
        let Grade = Number($('#Grade').val());

        let facultyNumberRegex = /^\d+$/;

        if(FirstName.trim() != "" && LastName.trim() != "" && facultyNumberRegex.test(FacultyNumber)){
            let request = {
                url: baseSurviceUrl,
                method: "POST",
                headers: {
                    "Authorization": "Basic " + base64Auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify({
                    ID: ID,
                    FirstName: FirstName,
                    LastName: LastName,
                    FacultyNumber: FacultyNumber,
                    Grade: Grade
                })
            };

            $.ajax(request)
                .then(loadStudents);
        }
    });
}
function validate() {
    $('#company').on('change', showHideCompany);

    $('#submit').on('click', function (ev) {
        ev.preventDefault();
        let usernameRegex = /^[a-zA-Z0-9]{3,20}$/;
        let passwordRegex = /^\w{5,15}$/;
        let emailRegex = /@.*\./;
        let companyNumberRegex = /^[1-9]{1}[0-9]{3}$/;

        let allFieldsValid = true;

        if($('#username').val().match(usernameRegex)){
            $('#username').css('border', 'none');
        } else {
            $('#username').css('border-color', 'red');
            allFieldsValid = false;
        }

        if($('#password').val().match(passwordRegex)){
            $('#password').css('border', 'none');
        } else {
            $('#password').css('border-color', 'red');
            allFieldsValid = false;
        }

        if($('#email').val().match(emailRegex)){
            $('#email').css('border', 'none');
        } else {
            $('#email').css('border-color', 'red');
            allFieldsValid = false;
        }

        if($('#confirm-password').val().match(passwordRegex) && $('#confirm-password').val().localeCompare($('#password').val()) == 0){
            $('#confirm-password').css('border', 'none');
        } else {
            $('#confirm-password').css('border-color', 'red');
            allFieldsValid = false;
        }

        if($('#company').is(':checked')){
            if($('#companyNumber').val().match(companyNumberRegex)){
                $('#companyNumber').css('border', 'none');
            } else {
                $('#companyNumber').css('border-color', 'red');
                allFieldsValid = false;
            }
        }

        if(allFieldsValid){
            $('#valid').css('display', 'block');
        } else {
            $('#valid').css('display', 'none');
        }

    });

    function showHideCompany() {
            if($(this).is(':checked')){
                $('#companyInfo').css('display', 'block');
            } else {
                $('#companyInfo').css('display', 'none')
            }
    }
}

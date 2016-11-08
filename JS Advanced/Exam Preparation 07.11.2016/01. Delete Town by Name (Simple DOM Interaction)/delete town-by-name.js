function attachEvents() {
    $('#btnDelete').click(function () {
        let townToDelete = $('#townName').val();
        let allTowns = $('#towns option').toArray();
        if(allTowns.some(function(t){ return $(t).text() == townToDelete})){
            $('#towns option').filter(function(){
                return $.trim($(this).text()) ==  townToDelete;
            }).remove();

            $('#result').text(townToDelete + " deleted.");
        } else {
            $('#result').text(townToDelete + " not found.");
        }

        $('#townName').val('');
    })
}
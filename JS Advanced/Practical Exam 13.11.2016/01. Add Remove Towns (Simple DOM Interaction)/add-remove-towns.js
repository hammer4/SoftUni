function attachEvents() {
    $('#btnDelete').click(deleteTown);
    
    function deleteTown() {
        if($('#towns option:selected')){
            $('#towns option:selected').remove();
        }
    }

    $('#btnAdd').click(addTown);

    function addTown() {
        if($('#newItem').val()){
            let townToAdd = $('#newItem').val();

            $('#towns').append($('<option>').text(townToAdd));
        }

        $('#newItem').val('');
    }
}
function attachEvents() {
    $('#items li').on('click', select);

    function select() {
        if($(this).attr('data-selected')){
            $(this).removeAttr('data-selected');
            $(this).css('background', "");
        } else {
            $(this).attr("data-selected", true);
            $(this).css('background',"#DDD");
        }
    }

    $('#showTownsButton').on('click', function () {
        $('#selectedTowns').text($('#items li[data-selected]').toArray().map(li => li.textContent).join(', '));
    })
}
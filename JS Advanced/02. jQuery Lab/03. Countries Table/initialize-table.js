function initializeTable() {
    $('#createLink').on('click', createCountry);

    function addCountry(country, capital) {
        let tr = $('<tr>')
            .append($('<td>').text(country))
            .append($('<td>').text(capital))
            .append($('<td>')
                .append($('<a href="#">[Up]</a>').on('click', moveUp))
                .append($('<a href="#">[Down]</a>').on('click', moveDown))
                .append($('<a href="#">[Delete]</a>').on('click', deleteRow)));

        tr.appendTo($('#countriesTable'));
    }

    addCountry('Bulgaria', 'Sofia');
    addCountry('Germany', 'Berlin');
    addCountry('Russia', 'Moscow');
    fixRowLinks();

    function createCountry() {
        let country = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();

        let tr = $('<tr>')
            .append($('<td>').text(country))
            .append($('<td>').text(capital))
            .append($('<td>')
                .append($('<a href="#">[Up]</a>').on('click', moveUp))
                .append($('<a href="#">[Down]</a>').on('click', moveDown))
                .append($('<a href="#">[Delete]</a>').on('click', deleteRow)));

        tr.appendTo($('#countriesTable'));

        $('#newCountryText').val("");
        $('#newCapitalText').val("");
        fixRowLinks();
    }

    function deleteRow() {
        $(this).parent().parent().fadeOut(function () {
            $(this).remove();
        })
        fixRowLinks();
    }

    function moveUp() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.prev().before(row);
            row.fadeIn();
            fixRowLinks();
        });
    }

    function moveDown() {
        let row = $(this).parent().parent();
        row.fadeOut(function () {
            row.next().after(row);
            row.fadeIn();
            fixRowLinks();
        });
    }

    function fixRowLinks() {
        $('#countriesTable a').css('display', 'inline');
        $('#countriesTable tr:nth-child(3) td a:contains("Up")').css('display', 'none');
        $('#countriesTable tr:last-child td a:contains("Down")').css('display', 'none');
    }
}
function tableBuilder(selector) {
    function createTable(columnNames){
        $(selector)
            .html($('<table>')
                .append($('<tr>')));

        for(let columnName of columnNames){
            $(selector + ' table tr:first').append($('<th>').text(columnName));
        }

        $(selector + ' table tr:first').append($('<th>').text("Action"));
    }
    
    function fillData(dataRows) {
        for(let row of dataRows){
            $(selector + " table").append($('<tr>'));

            for(let data of row){
                $(selector + " table tr:last").append($('<td>').text(data));
            }

            $(selector + " table tr:last").append($('<td>').append($('<button>').click(deleteRow).text("Delete")));
        }

        function deleteRow() {
            $(this).parent().parent().remove();
        }
    }

    return {createTable, fillData};
}
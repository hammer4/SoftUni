function increment(string) {
    let selector = $(string);

    selector.append($('<textarea>').addClass('counter').attr('disabled', true).val('0'))
        .append($('<button>').addClass('btn').attr('id', 'incrementBtn').text('Increment').on('click', increaseValue))
        .append($('<button>').addClass('btn').attr('id', 'addBtn').text('Add').on('click', appendToList))
        .append($('<ul>').addClass('results'));

    function increaseValue() {
        $('.counter').val(Number($('.counter').val()) + 1);
    }
    
    function appendToList() {
        $('.results').append($('<li>').text($('.counter').val()));
    }
}
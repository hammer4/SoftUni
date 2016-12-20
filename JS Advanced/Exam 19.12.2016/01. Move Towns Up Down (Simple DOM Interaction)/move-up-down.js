function move(num) {
    let selected = $('#towns :selected');
    let action = num > 0 ? moveDown : moveUp;
    action(selected);

    function moveUp(option) {
        $(option).insertBefore(option.prev());
    }

    function moveDown(option) {
        $(option).insertAfter(option.next());
    }
}
function addItem() {
    let text = document.getElementById('newItemText').value;
    var li = document.createElement('li');
    li.appendChild(document.createTextNode(text));
    document.getElementById('items').appendChild(li);
}
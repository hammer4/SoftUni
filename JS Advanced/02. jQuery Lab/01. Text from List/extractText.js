function extractText() {
    $('#result').text($('#items li').toArray().map(li => li.textContent).join(", "));
}
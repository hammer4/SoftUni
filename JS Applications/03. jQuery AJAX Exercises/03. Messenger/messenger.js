function attachEvents() {
    let baseServiceUrl = "https://messanger-6eff2.firebaseio.com/messenger";

    function loadMessages() {
        $.get(baseServiceUrl + ".json")
            .then(displayMessages);
    }

    function displayMessages(messages) {
        $('#messages').empty();
        let orderedMessages = {};
        messages = Object.keys(messages).sort((a,b) => a.timestamp - b.timestamp).forEach(k => orderedMessages[k] = messages[k]);
        for(let message of Object.keys(orderedMessages)){
            $('#messages').append(`${orderedMessages[message]['author']}: ${orderedMessages[message]['content']}\n`);
        }
    }

    function createMessage() {
        let data = {
            author:$('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        };

        $.post(baseServiceUrl + ".json", JSON.stringify(data))
            .then(loadMessages)
    }
    
    $('#submit').click(createMessage);
    $('#refresh').click(loadMessages);

    loadMessages();
}
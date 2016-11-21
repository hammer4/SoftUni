function secretKnock() {
    let baseServiceUrl = "https://baas.kinvey.com/appdata/kid_BJXTsSi-e/knock?query=";
    let kinveyUsername = "guest";
    let kinveyPassword = "guest";
    //let base64Auth = new Buffer(kinveyUsername + ":" + kinveyPassword).toString('base64');
    let base64Auth = btoa(kinveyUsername + ":" + kinveyPassword);
    let authHeaders = {"Authorization":"Basic " + base64Auth};
    let currentMessage = "Knock Knock.";
    console.log(currentMessage);
    getNext(currentMessage);

    function getNext(message) {
        let request = {
            url: baseServiceUrl + message,
            headers: authHeaders,
            method: "GET"
        };

        $.ajax(request)
            .then(function (object) {
                if(object.answer){
                    console.log(object.answer);
                }
                if(object.message){
                    console.log(object.message);
                    currentMessage = object.message;
                    getNext(currentMessage);
                }
            });
    }
}

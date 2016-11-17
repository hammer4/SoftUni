function schedule() {
    let nextStopId = "depot";
    let currentStopName = undefined;

    function depart() {
        $('#depart').attr("disabled", true);

        $.get("https://judgetests.firebaseio.com/schedule/" + nextStopId + ".json")
            .then(nextStop)
            .catch(displayError);
    }

    function nextStop(nextStop) {
        $('.info').text(`Next stop ${nextStop.name}`);
        currentStopName = nextStop.name;
        nextStopId = nextStop.next;
        $('#arrive').removeAttr("disabled");
    }

    function arrive() {
        $('#arrive').attr("disabled", true);
        $('.info').text(`Arriving at ${currentStopName}`);
        $('#depart').removeAttr("disabled");
    }
    
    function displayError() {
        $('.info').text("Error");
        $('#arrive').attr("disabled", true);
        $('#depart').attr("disabled", true);
    }

    return {
        depart,
        arrive
    };
}

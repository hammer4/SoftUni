function timer() {
    let time=0, intervalId, isRunning = false;
    $('#start-timer').on('click', function () {
        if(! isRunning){
            intervalId = setInterval(incrementTime, 1000);
            isRunning = true;
        }
    });

    $('#stop-timer').on('click', function () {
        clearInterval(intervalId);
        isRunning = false;
    });

    function incrementTime() {
        time++;
        $('#hours').text(("0" + Math.trunc(time/3600)).slice(-2));
        $('#minutes').text(("0" + Math.trunc((time/60)%60)).slice(-2));
        $('#seconds').text(("0" + Math.trunc(time%60)).slice(-2));
    }
}
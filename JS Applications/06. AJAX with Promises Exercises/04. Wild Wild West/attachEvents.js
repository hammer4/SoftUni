function attachEvents() {
    let baseUrl = "https://baas.kinvey.com/appdata/kid_Skc2_emfl/players";
    let base64Auth = btoa("guest:guest");

    $('#addPlayer').click(addPlayer);
    
    loadPlayers();

    function loadPlayers() {
        let request = {
            method: "GET",
            url: baseUrl,
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };
        
        $.ajax(request).then(displayPlayers);
        
        function displayPlayers(players) {
            $('#players').empty();
            for(let player of players){
                $('#players')
                    .append($('<div>').addClass("player").attr("data-id", player._id)
                        .append($('<div>').addClass("row")
                            .append($('<label>').text("Name:"))
                            .append($('<label>').addClass("name").text(player.name)))
                        .append($('<div>').addClass("row")
                            .append($('<label>').text("Money:"))
                            .append($('<label>').addClass("money").text(player.money)))
                        .append($('<div>').addClass("row")
                            .append($('<label>').text("Bullets:"))
                            .append($('<label>').addClass("bullets").text(player.bullets)))
                        .append($('<button>').addClass("play").text("Play").click(function(){prepareCanvas(player)}))
                        .append($('<button>').addClass("delete").text("Delete").click(deletePlayer))
                    );
            }
        }
    }

    function prepareCanvas(player) {
        $('#save').trigger('click');

        $('#canvas').css('display', 'block');
        $('#save').css('display', 'inline-block');
        $('#reload').css('display', 'inline-block');
        loadCanvas(player);
    }

    function addPlayer() {
        let name = $('#addName').val();
        let money = 500;
        let bullets = 6;

        let request = {
            url: baseUrl,
            method: "POST",
            headers: {
                "Authorization": "Basic " + base64Auth,
                "Content-type": "application/json"
            },
            data: JSON.stringify({
                name: name,
                money: money,
                bullets: bullets
            })
        };

        $.ajax(request).then(function(){
            loadPlayers();
            $('#addName').val('');
        });
    }

    function deletePlayer() {
        let playerId = $(this).parent().attr("data-id");

        let request = {
            method: "DELETE",
            url: baseUrl + "/" + playerId,
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request).then(loadPlayers);
    }
}
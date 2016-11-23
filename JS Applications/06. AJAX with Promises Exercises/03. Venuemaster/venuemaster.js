function attachEvents() {
    let baseUrl = "https://baas.kinvey.com/";
    let appId = "kid_BJ_Ke8hZg";
    let base64Auth = btoa("guest:pass");
    
    $('#getVenues').click(loadVenues);

    function loadVenues() {
        let date = $('#venueDate').val();

        let request = {
            url: baseUrl + "rpc/" + appId + "/custom/calendar?query=" + date,
            method: "POST",
            headers : {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request).then(function (venueIds) {
            for(let venueId of venueIds){
                let request = {
                    method: "GET",
                    url: baseUrl + "appdata/" + appId + "/venues/" + venueId,
                    headers: {
                        "Authorization": "Basic " + base64Auth
                    }
                };

                $.ajax(request).then(displayVenue);
            }
        })
    }

    function displayVenue(data) {
        $('#venue-info')
            .append($('<div>').addClass("venue").attr('id', data._id)
                .append($('<span>').addClass("venue-name").text(data.name)
                    .append($('<input>').addClass("info").attr("type", "button").val("More info").click(showInfo)))
                .append($('<div>').addClass("venue-details").css("display", "none")
                    .append($('<table>')
                        .append($('<tr>')
                            .append($('<th>').text("Ticket Price"))
                            .append($('<th>').text("Quantity"))
                            .append($('<th>')))
                        .append($('<tr>')
                            .append($('<td>').addClass("venue-price").text(`${data.price} lv`))
                            .append($('<td>')
                                .append($('<select>').addClass("quantity")
                                    .append($('<option>').val("1").text("1"))
                                    .append($('<option>').val("2").text("2"))
                                    .append($('<option>').val("3").text("3"))
                                    .append($('<option>').val("4").text("4"))
                                    .append($('<option>').val("5").text("5"))))
                            .append($('<td>')
                                .append($('<input>').addClass("purchase").attr("type", "button").val("Purchase").click(purchase)))))
                    .append($('<span>').addClass("head").text("Venue description:"))
                    .append($('<p>').addClass("description").text(data.description))
                    .append($('<p>').addClass("description").text(`Starting time: ${data.startingHour}`))
                )
            );
    }

    function showInfo() {
        $('.venue-details').hide();
        $(this).parent().parent().find('.venue-details').show();
    }

    function purchase() {
        let id = $(this).parent().parent().parent().parent().parent().attr('id');
        let name = $(this).parent().parent().parent().parent().parent().find(".venue-name").text();
        let qty = Number($(this).parent().parent().find(".quantity").val());
        let price = Number($(this).parent().parent().find(".venue-price").text().substring(0, $(this).parent().parent().find(".venue-price").text().length-2));

        $('#venue-info').html(`<span class="head">Confirm purchase</span>
<div class="purchase-info">
  <span>${name}</span>
  <span>${qty} x ${price}</span>
  <span>Total: ${qty * price} lv</span>
  <input type="button" value="Confirm">
</div>
`);

        $('#venue-info input').click(function () {
            let request = {
                method: "POST",
                url: baseUrl + "rpc/" + appId + "/custom/purchase?venue=" + id + "&qty=" + qty,
                headers: {
                    "Authorization": "Basic " + base64Auth
                }
            };
            
            $.ajax(request).then(function (data) {
                $('#venue-info').html("You may print this page as your ticket" + data.html);
            })
        })
    }
}
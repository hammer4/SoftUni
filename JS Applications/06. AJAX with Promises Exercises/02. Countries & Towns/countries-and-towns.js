function countriesAndTowns() {
    let baseUrl = "https://baas.kinvey.com/appdata/kid_B1EfX0bze/";
    let base64Auth = btoa("guest:guest");

    attachEvents();
    loadCountries();

    function attachEvents() {
        $('#btnAddCountry').click(addCountry);
        $('#btnEditCountry').click(editCountry);
        $('#btnDeleteCountry').click(deleteCountry);
        $('#addCountry').click(function () {
            $('.add:first').fadeIn();
        });
        $('#addTown').click(function () {
            $('.add:last').fadeIn();
        });
        $('#btnAddTown').click(addTown);
        $('#btnListTowns').click(loadTowns);
        $('#btnEditTown').click(editTown);
        $('#btnDeleteTown').click(deleteTown);
    }

    function addCountry() {
        let countryName = $('#newCountry').val();

        if(! $('#countries option').toArray().some(c => $(c).text() == countryName)){
            let request = {
                method: "POST",
                url: baseUrl + "countries",
                headers: {
                    "Authorization": "Basic " + base64Auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify({
                    name: countryName
                })
            };

            $.ajax(request)
                .then(function(){
                    $('.add:first').fadeOut();
                    loadCountries();
                    $('#newCountry').val('');
                });
        } else {
            $('#errorDiv').text("Country already in the list.");
            $('#errorDiv').fadeIn();
            $('.add:first').fadeOut();
            setTimeout(function () {
                $('#errorDiv').fadeOut()
            }, 3000);
            $('#newCountry').val('');
        }
    }

    function addTown() {
        let countryName = $('#newTownCountry').val();
        let townName = $('#newTown').val();

        if($('#countries option').toArray().some(c => $(c).text() == countryName)){
            let request = {
                method: "POST",
                url: baseUrl + "towns",
                headers: {
                    "Authorization": "Basic " + base64Auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify({
                    name: townName,
                    country: countryName
                })
            };

            $.ajax(request)
                .then(function(){
                    loadTowns();
                    $('.add:last').fadeOut();
                    $('#newTown').val('');
                    $('#newTownCountry').val('');
                });
        } else {
            $('#errorDiv').text("Country does not exist in the list.");
            $('#errorDiv').fadeIn();
            $('.add:last').fadeOut();
            setTimeout(function () {
                $('#errorDiv').fadeOut()
            }, 3000);
            $('#newTown').val('');
            $('#newTownCountry').val('');
        }
    }

    function loadCountries() {
        let request = {
            method: "GET",
            url: baseUrl + "countries",
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request)
            .then(displayCountries);
    }

    function displayCountries(countries) {
        $('#countries').empty();
        for(let country of countries){
            $('#countries')
                .append($('<option>').val(country._id).text(country.name));
        }
    }


    function loadTowns() {
        let country = $('#countries option:selected').text();

        let request = {
            method: "GET",
            url: baseUrl + "towns",
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request)
            .then(function (towns) {
                $('#towns').empty();
                towns = towns.filter(t => t.country == country);

                for(let town of towns){
                    $('#towns')
                        .append($('<option>').val(town._id).text(town.name));
                }
            });
    }

    function editCountry() {
        let countryToEdit = $('#countries option:selected').val();
        $('#inputEditCountry').val($('#countries option:selected').text());
        $('#editCountry').fadeIn();

        $('#editCoun').click(function () {
            let request = {
                method: "PUT",
                url: baseUrl + "countries/" + countryToEdit,
                headers: {
                    "Authorization": "Basic " + base64Auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify({
                    name: $('#inputEditCountry').val()
                })
            };

            $.ajax(request)
                .then(function () {
                    loadCountries();
                    $('#inputEditCountry').val('');
                    $('#editCountry').fadeOut();
                });
        })
    }

    function editTown() {
        let townToEdit = $('#towns option:selected').val();
        $('#inputEditTownName').val($('#towns option:selected').text());
        $('#inputEditTownCountry').val('');
        $('#editTown').fadeIn();

        $('#editTownn').click(function () {
            let request = {
                method: "PUT",
                url: baseUrl + "towns/" + townToEdit,
                headers: {
                    "Authorization": "Basic " + base64Auth,
                    "Content-type": "application/json"
                },
                data: JSON.stringify({
                    name: $('#inputEditTownName').val(),
                    country: $('#inputEditTownCountry').val()
                })
            };

            $.ajax(request)
                .then(function () {
                    loadTowns();
                    $('#inputEditTownName').val('');
                    $('#inputEditTownCountry').val('');
                    $('#editTown').fadeOut();
                });
        })
    }

    function deleteCountry() {
        let countryToDelete = $('#countries option:selected').val();

        let request = {
            method: "DELETE",
            url: baseUrl + "countries/" + countryToDelete,
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request)
            .then(loadCountries)
    }

    function deleteTown() {
        let townToDelete = $('#towns option:selected').val();

        let request = {
            method: "DELETE",
            url: baseUrl + "towns/" + townToDelete,
            headers: {
                "Authorization": "Basic " + base64Auth
            }
        };

        $.ajax(request)
            .then(loadTowns);
    }
}
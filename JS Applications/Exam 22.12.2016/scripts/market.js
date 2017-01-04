function startApp() {
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_rk5XQ_qHg";
    const kinveyAppSecret = "d93aef2f8fed46d2b5613c7608774d8e";
    const kinveyAppAuthHeaders = {
        "Authorization": "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret)
    };

    sessionStorage.clear();
    showHideMenuLinks();
    showAppHomeView();

    $('#linkMenuAppHome').click(showAppHomeView);
    $('#linkMenuLogin').click(showLoginView);
    $('#linkMenuRegister').click(showRegisterView);

    $('#linkMenuUserHome').click(showUserHomeView);
    $('#linkMenuLogout').click(logoutUser);

    $('#formRegister').submit(registerUser);
    $('#formLogin').submit(loginUser);

    $('#linkMenuShop, #linkUserHomeShop').click(showShop);
    $('#linkMenuCart, #linkUserHomeCart').click(showCart);

    $('#infoBox, #errorBox').click(function () {
        $(this).fadeOut();
    });

    $(document).on({
        ajaxStart: function () {
            $('#loadingBox').show();
        },
        ajaxStop: function () {
            $('#loadingBox').hide();
        }
    });

    function showHideMenuLinks() {
        $('main > div').hide();
        if(sessionStorage.getItem('authToken')){
            $('.useronly').show();
            $('.anonymous').hide();
        } else {
            $('.anonymous').show();
            $('.useronly').hide();
        }
    }

    function showView(viewName) {
        $('main > section').hide();
        $('#' + viewName).show();
    }

    function showAppHomeView() {
        showView('viewAppHome');
    }

    function showLoginView() {
        showView('viewLogin');
    }

    function showRegisterView() {
        showView('viewRegister');
    }

    function showUserHomeView() {
        showView('viewUserHome');
    }

    function showShopView() {
        showView('viewShop');
    }

    function showCartView() {
        showView('viewCart');
    }


    function handleAjaxError(response) {
        let errorMsg = JSON.stringify(response);
        if(response.readyState === 0) {
            errorMsg = "Cannot connect due to network error.";
        }
        if(response.responseJSON && response.responseJSON.description) {
            errorMsg = response.responseJSON.description;
        }

        showError(errorMsg);
    }

    function showInfo(message) {
        $('#infoBox').text(message);
        $('#infoBox').show();
        setTimeout(function () {
            $('#infoBox').fadeOut();
        }, 3000);
    }

    function showError(errorMsg) {
        $('#errorBox').text("Error: " + errorMsg);
        $('#errorBox').show();
    }

    function registerUser(event) {
        event.preventDefault();
        let userData = {
            username: $('#formRegister input[name=username]').val(),
            password: $('#formRegister input[name=password]').val(),
            name: $('#formRegister input[name=name]').val(),
            cart: {}
        };

        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/",
            headers: kinveyAppAuthHeaders,
            data: userData,
            success: registerSuccess,
            error: handleAjaxError
        });

        function registerSuccess(userInfo) {
            $('form input[type=text], form input[type=password]').val('');
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            showUserHomeView();
            showInfo('User registration successful.');
        }
    }

    function saveAuthInSession(userInfo) {
        let userAuth = userInfo._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        let id = userInfo._id;
        sessionStorage.setItem('id', id);
        let username = userInfo.username;
        sessionStorage.setItem('username', username);
        $('#spanMenuLoggedInUser').text("Welcome, " + username + "!");
        $('#viewUserHomeHeading').text("Welcome, " + username + "!");
    }

    function loginUser(event) {
        event.preventDefault();

        let userData = {
            username: $('#formLogin input[name=username]').val(),
            password: $('#formLogin input[name=password]').val()
        };

        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/login",
            headers: kinveyAppAuthHeaders,
            data: userData,
            success: loginSuccess,
            error: handleAjaxError
        });

        function loginSuccess(userInfo) {
            $('form input[type=text], form input[type=password]').val('');
            saveAuthInSession(userInfo);
            showHideMenuLinks();
            showUserHomeView();
            showInfo('Login successful.');
        }
    }

    function logoutUser() {
        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/_logout",
            headers: getKinveyUserAuthHeaders(),
            success: logoutSuccess,
            error: handleAjaxError
        });

        function logoutSuccess() {
            sessionStorage.clear();
            showHideMenuLinks();
            showAppHomeView();
            showInfo("Logout successful.");
        }
    }

    function getKinveyUserAuthHeaders() {
        return {
            "Authorization": "Kinvey " + sessionStorage.getItem('authToken')
        };
    }

    function showShop() {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/products",
            headers: getKinveyUserAuthHeaders(),
            success: showShopSuccess,
            error: handleAjaxError
        });

        function showShopSuccess(products) {
            products = products.sort((a,b) => a._id.localeCompare(b._id));
            $('#shopProducts table tbody').empty();

            for(let product of products){
                let purchaseLink = $('<button>').text('Purchase').click(() => purchaseItem(product));
                $('#shopProducts table tbody')
                    .append($('<tr>')
                        .append($('<td>').text(product.name))
                        .append($('<td>').text(product.description))
                        .append($('<td>').text(product.price.toFixed(2)))
                        .append($('<td>').append(purchaseLink))
                    );
            }

            showShopView();
        }
    }

    function showCart() {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/" + sessionStorage.getItem('id'),
            headers: getKinveyUserAuthHeaders(),
            success: showCartSuccess,
            error: handleAjaxError
        });

        function showCartSuccess(user) {
            $('#cartProducts table tbody').empty();

            if(! user.cart){
                user.cart = {};
            }

            for(let productId of Object.keys(user.cart)){
                let discardLink = $('<button>').text('Discard').click(() => discardItem(user, productId));
                $('#cartProducts table tbody')
                    .append($('<tr>')
                        .append($('<td>').text(user.cart[productId].product.name))
                        .append($('<td>').text(user.cart[productId].product.description))
                        .append($('<td>').text(user.cart[productId].quantity))
                        .append($('<td>').text((Number(user.cart[productId].product.price) * Number(user.cart[productId].quantity)).toFixed(2)))
                        .append($('<td>').append(discardLink))
                    );
            }

            showCartView();
        }
    }

    function purchaseItem(product) {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/" + sessionStorage.getItem('id'),
            headers: getKinveyUserAuthHeaders(),
            success: loadUserSuccess,
            error: handleAjaxError
        });

        function loadUserSuccess(user) {
            if(! user.cart){
                user.cart = {};
            }

            if(! user.cart[product._id]){
                user.cart[product._id] = {};
                user.cart[product._id].product = {};
                user.cart[product._id].product.name = product.name;
                user.cart[product._id].product.description = product.description;
                user.cart[product._id].product.price = product.price;
                user.cart[product._id].quantity = 1;
            } else {
                user.cart[product._id].quantity = Number(user.cart[product._id].quantity) + 1;
            }

            let userdata = user;

            $.ajax({
                method: "PUT",
                url: kinveyBaseUrl + "user/" + kinveyAppKey + "/" + sessionStorage.getItem('id'),
                headers: getKinveyUserAuthHeaders(),
                data: userdata,
                success: updateUserSuccess,
                error: handleAjaxError
            });
            
            function updateUserSuccess() {
                showCart();
                showInfo('Product purchased.')
            }
        }
    }

    function discardItem(user, productId){
        delete user.cart[productId];

        $.ajax({
            method: "PUT",
            url: kinveyBaseUrl + "user/" + kinveyAppKey + "/" + sessionStorage.getItem('id'),
            headers: getKinveyUserAuthHeaders(),
            data: user,
            success: updateUserSuccess,
            error: handleAjaxError
        });

        function updateUserSuccess() {
            showCart();
            showInfo('Product discarded.');
        }
    }
}
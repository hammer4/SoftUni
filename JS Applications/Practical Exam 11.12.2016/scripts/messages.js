function startApp(){
    const kinveyBaseUrl = "https://baas.kinvey.com/";
    const kinveyAppKey = "kid_BJrFWY5ml";
    const kinveyAppSecret = "61431f515ab54f77a2a074c258139c30";
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
    $('#formSendMessage').submit(sendMessage);

    $('#linkMenuMyMessages, #linkUserHomeMyMessages').click(showInbox);
    $('#linkMenuArchiveSent, #linkUserHomeArchiveSent').click(showOutbox);
    $('#linkMenuSendMessage, #linkUserHomeSendMessage').click(loadUsers);

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

    function showMessagesView() {
        showView('viewMyMessages')
    }

    function showArhiveMessagesView() {
        showView('viewArchiveSent');
    }

    function showSendMessageView() {
        showView('viewSendMessage');
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
            name: $('#formRegister input[name=name]').val()
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
        let name = userInfo.name;
        sessionStorage.setItem('name', name);
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
            showInfo("Logout successful");
        }
    }

    function formatDate(dateISO8601) {
        let date = new Date(dateISO8601);
        if (Number.isNaN(date.getDate()))
            return '';
        return date.getDate() + '.' + padZeros(date.getMonth() + 1) +
            "." + date.getFullYear() + ' ' + date.getHours() + ':' +
            padZeros(date.getMinutes()) + ':' + padZeros(date.getSeconds());

        function padZeros(num) {
            return ('0' + num).slice(-2);
        }
    }


    function formatSender(name, username) {
        if (!name)
            return username;
        else
            return username + ' (' + name + ')';
    }

    function showInbox() {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + `/messages?query={"recipient_username":"${sessionStorage.getItem('username')}"}`,
            headers: getKinveyUserAuthHeaders(),
            success: showInboxSuccess,
            error: handleAjaxError
        });

        function showInboxSuccess(messages) {

            $('#myMessages table tbody').empty();
            for(let message of messages){
                $('#myMessages table tbody')
                    .append($('<tr>')
                        .append($('<td>').text(formatSender(message.sender_name, message.sender_username)))
                        .append($('<td>').text(message.text))
                        .append($('<td>').text(formatDate(message._kmd.lmt)))
                    );
            }

            showMessagesView();
        }
    }

    function showOutbox() {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + `/messages?query={"sender_username":"${sessionStorage.getItem('username')}"}`,
            headers: getKinveyUserAuthHeaders(),
            success: showOutboxSuccess,
            error: handleAjaxError
        });
        
        function showOutboxSuccess(messages) {
            $('#sentMessages table tbody').empty();

            for(let message of messages){
                let deleteLink = $('<button>').text('Delete').click(() => deleteMessage(message._id));
                $('#sentMessages table tbody')
                    .append($('<tr>')
                        .append($('<td>').text(message.recipient_username))
                        .append($('<td>').text(message.text))
                        .append($('<td>').text(formatDate(message._kmd.lmt)))
                        .append($('<td>').append(deleteLink))
                    )
            }

            showArhiveMessagesView();
        }
    }

    function deleteMessage(id) {
        $.ajax({
            method: "DELETE",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/messages/" + id,
            headers: getKinveyUserAuthHeaders(),
            success: deleteMessageSuccess,
            error: handleAjaxError
        });

        function deleteMessageSuccess() {
            showOutbox();
            showInfo('Message deleted.');
        }
    }

    function getKinveyUserAuthHeaders() {
        return {
            "Authorization": "Kinvey " + sessionStorage.getItem('authToken')
        };
    }

    function loadUsers() {
        $.ajax({
            method: "GET",
            url: kinveyBaseUrl + "user/" + kinveyAppKey,
            headers: getKinveyUserAuthHeaders(),
            success: loadUsersSuccess,
            error: handleAjaxError
        });
        
        function loadUsersSuccess(users) {
            $('#formSendMessage select').empty();

            for(let user of users){
                let name = null;
                if(user.name){
                    name = user.name;
                }

                $('#formSendMessage select')
                    .append($('<option>').val(user.username).text(formatSender(name, user.username)));
            }
            
            showSendMessageView();
        }
    }

    function sendMessage(event) {
        event.preventDefault();

        let messageData = {
            sender_username: sessionStorage.getItem('username'),
            sender_name: sessionStorage.getItem('name'),
            recipient_username: $('#formSendMessage select').val(),
            text: $('#msgText').val()
        };

        $.ajax({
            method: "POST",
            url: kinveyBaseUrl + "appdata/" + kinveyAppKey + "/messages",
            headers: getKinveyUserAuthHeaders(),
            data: messageData,
            success: sendMessageSuccess,
            error: handleAjaxError
        });
        
        function sendMessageSuccess() {
            $('form input[type=text], form input[type=password]').val('');
            showOutbox();
            showInfo('Message sent.');
        }
    }
}
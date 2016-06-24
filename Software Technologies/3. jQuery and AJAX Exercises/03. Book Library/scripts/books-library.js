const kinveyBaseUrl = "https://baas.kinvey.com/";
const kinveyAppKey = "kid_S1agMOFr";
const kinveyAppSecret = "f54c4354d4fe43268769694d219be58b";

function showView(viewName) {
    $('main > section').hide();
    $('#'+viewName).show();
}

function showHideMenuLinks() {
    $('#linkHome').show();
    if(sessionStorage.getItem('authToken') == null) {
        $('#linkLogin').show();
        $('#linkRegister').show();
        $('#linkListBooks').hide();
        $('#linkCreateBook').hide();
        $('#linkLogout').hide();
    } else {
        $('#linkLogin').hide();
        $('#linkRegister').hide();
        $('#linkListBooks').show();
        $('#linkCreateBook').show();
        $('#linkLogout').show();
    }
}

function showInfo(message) {
    $('#infoBox').text(message);
    $('#infoBox').show();
    setTimeout(function () {
        $('#infoBox').fadeOut()
    }, 3000);
}

function showError(errorMsg) {
    $('#errorBox').text("Error: " + errorMsg);
    $('#errorBox').show();
}

$(function () {
    showHideMenuLinks();
    showView('viewHome');

    $("#linkHome").click(showHomeView);
    $("#linkLogin").click(showLoginView);
    $("#linkRegister").click(showRegisterView);
    $("#linkListBooks").click(listBooks);
    $("#linkCreateBook").click(showCreateBookView);
    $("#linkLogout").click(logout);

    $("#formLogin").submit(login);
    $("#formRegister").submit(register);
    $("#formCreateBook").submit(createBook);
});

function showHomeView() {
    showView('viewHome');
}

function showLoginView() {
    showView('viewLogin');
}

function showCreateBookView() {
    showView('viewCreateBook');
}

function login() {
    const kinveyLoginUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/login";
    const kinveyAuthHeaders = {
        'Authorization' : 'Basic ' + btoa(kinveyAppKey + ":" + kinveyAppSecret),
        'Content-Type': 'application/json'
    };
    let userData = {
        username: $('#loginUser').val(),
        password: $('#loginPass').val()
    };
    $.ajax({
        method: 'POST',
        url: kinveyLoginUrl,
        headers: kinveyAuthHeaders,
        data: JSON.stringify(userData) ,
        success: loginSuccess,
        error: handleAjaxError
    });
    
    function loginSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('Login successful.');
    }
}

function handleAjaxError(response) {
    let errorMsg = JSON.stringify(response);
    if(response.readyState === 0) {
        errorMsg = "Cannot connect due to network error";
    }
    if(response.responseJSON && response.responseJSON.description) {
        errorMsg = response.responseJSON.description;
    }
    showError(errorMsg);
}

function showRegisterView() {
    showView('viewRegister');
}

function register() {
    const kinveyRegisterUrl = kinveyBaseUrl + "user/" + kinveyAppKey + "/";
    const kinveyAuthHeaders = {
        'Authorization': "Basic " + btoa(kinveyAppKey + ":" + kinveyAppSecret),
        'Content-Type': 'application/json'
    };
    let userData = {
        username: $('#registerUser').val(),
        password: $('#registerPass').val()
    };
    $.ajax({
        method: 'POST',
        url: kinveyRegisterUrl,
        headers: kinveyAuthHeaders,
        data: JSON.stringify(userData),
        success: registerSuccess,
        error: handleAjaxError
    });

    function registerSuccess(response) {
        let userAuth = response._kmd.authtoken;
        sessionStorage.setItem('authToken', userAuth);
        showHideMenuLinks();
        listBooks();
        showInfo('User registration successful.')
    }
}

function createBook() {
    let title = $('#bookTitle').val();
    let author = $('#bookAuthor').val();
    let description = $('#bookDescription').val();

    let data = {
        title: title,
        author: author,
        description: description
    };

    const createBookRequestUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';
    let headers = {
        'Authorization': 'Kinvey ' + sessionStorage.getItem('authToken'),
        'Content-Type': 'application/json'
    };

    $.ajax({
        headers: headers,
        method: 'POST',
        url: createBookRequestUrl,
        data: JSON.stringify(data),
        success: addBook,
        error: handleAjaxError
    });

    function addBook() {
        listBooks();
        showInfo('The book have been added.');
    }
}

function listBooks() {
    $('#books').html('');
    let userAuth = 'Kinvey ' + sessionStorage.getItem('authToken');
    let headers = {
        'Authorization': userAuth
    }

    let listBooksRequestUrl = kinveyBaseUrl + 'appdata/' + kinveyAppKey + '/books';

    $.ajax({
        method: 'GET',
        headers: headers,
        url: listBooksRequestUrl
    }).then(function (response) {
        for(let book of response) {
            let div = $('#books');
            let list = document.createElement('ul');
            let title = document.createElement('li');
            let author = document.createElement('li');
            let description = document.createElement('li');

            title.appendChild(document.createTextNode(book.title));
            author.appendChild(document.createTextNode(book.author));
            description.appendChild(document.createTextNode(book.description));
            list.appendChild(title);
            list.appendChild(author);
            list.appendChild(description);
            div.append(list);
            console.log(book);
        }
    });
    showView('viewBooks');
}

function logout() {
    sessionStorage.clear();
    showView('viewHome');
    showHideMenuLinks();
}
function loadCommits() {
    $('#commits').empty();
    let url = "https://api.github.com/repos/" + $('#username').val() + "/" + $('#repo').val() + "/commits";

    $.get(url)
        .then(displayCommits)
        .catch(displayError);

    function displayCommits(commits) {
        for(let commit of commits){
            $('#commits').append($('<li>').text(commit.commit.author.name + ": " + commit.commit.message));
        }
    }
    
    function displayError(err) {
        $('#commits').append($('<li>').text("Error: " + err.status + ' (' + err.statusText + ')'));
    }
}
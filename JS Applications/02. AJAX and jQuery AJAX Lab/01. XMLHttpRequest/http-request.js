function loadRepos() {
    let req = new XMLHttpRequest();
    req.onreadystatechange = function () {
        if(this.readyState == 4 && this.status == 200){
            document.getElementById("res").textContent = this.responseText;
        }
    };

    req.open("GET", "https://api.github.com/users/testnakov/repos", true);
    req.send();
}
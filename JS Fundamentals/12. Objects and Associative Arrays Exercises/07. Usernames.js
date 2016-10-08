function usernames(input) {
    let usernames = new Set();

    for(let username of input){
        usernames.add(username);
    }

    Array.from(usernames.keys()).sort((a, b) => sortUsernames(a, b)).forEach(u => console.log(u));

    function sortUsernames(a, b) {
        if(a.length != b.length) {
            return(a.length - b.length);
        } else {
            return a.localeCompare(b);
        }
    }
}

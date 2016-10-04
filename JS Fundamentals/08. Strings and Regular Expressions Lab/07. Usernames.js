function usernames(input) {
    let users = [];

    for(let email of input) {
        let tokens = email.split('@');
        let username = tokens[0] + '.';
        let domain = tokens[1];
        domain.split('.').forEach(x => username += x[0]);
        users.push(username);
    }

    console.log(users.join(", "));
}

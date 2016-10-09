function ajaxRequestValidator(input) {
    let hashPattern = input.pop();

    for(let i=0; i<input.length; i+=3){
        let method = input[i].split(" ");
        if(method.length != 2 || method[0] != "Method:" || !(method[1] == 'GET' || method[1] == 'POST' || method[1] == 'PUT' || method[1] == 'DELETE')){
            console.log("Response-Code:400");
            continue;
        }

        let auth = input[i+1].split(" ");
        if(auth.length != 3 || auth[0] != "Credentials:" || !(auth[1] == "Basic" || auth[1] == "Bearer")){
            console.log("Response-Code:400");
            continue;
        }
        let authTokenRegex = /^[A-Za-z0-9]+$/;
        if(! auth[2].match(authTokenRegex)){
            console.log("Response-Code:400");
            continue;
        }

        let content = input[i+2].split(" ");
        if(content.length != 2 || content[0] != "Content:"){
            console.log("Response-Code:400");
            continue;
        }
        let contentRegex = /^[a-zA-Z0-9.]+$/;
        if(! content[1].match(contentRegex)){
            console.log("Response-Code:400");
            continue;
        }

        if((method[1] == 'POST' || method[1] == 'PUT' || method[1] == 'DELETE') && auth[1] == "Basic"){
            console.log(`Response-Method:${method[1]}&Code:401`);
            continue;
        }

        let authHashes = [];
        for(let i=0; i<hashPattern.length; i+=2){
            authHashes.push(hashPattern.substr(i, 2));
        }

        let validAuth = false;

        for(let hashPat of authHashes){
            let count = hashPat[0];
            let char=hashPat[1];

            let splittedAuth = auth[2].split(char);
            if(splittedAuth.length - 1 == count){
                validAuth = true;
            }
        }

        if(! validAuth){
            console.log(`Response-Method:${method[1]}&Code:403`);
            continue;
        }

        console.log(`Response-Method:${method[1]}&Code:200&Header:${auth[2]}`);
    }
}

class CheckingAccount{
    constructor(clientId, email, firstName, lastName){
        this.clientId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
        this.products = [];
    }

    get clientId(){
        return this._clientId;
    }
    set clientId(newClientId){
        if(typeof newClientId != "string"){
            throw new TypeError("Client ID must be a 6-digit number");
        }
        let clientIdRegex = /^\d{6}$/;
        if(! clientIdRegex.test(newClientId)){
            throw new TypeError("Client ID must be a 6-digit number");
        }

        this._clientId = newClientId;
    }

    get email(){
        return this._email;
    }
    set email(newEmail){
        let emailRegex = /^\w+@[a-zA-Z.]+$/;
        if(! emailRegex.test(newEmail)){
            throw new TypeError("Invalid e-mail");
        }

        this._email = newEmail;
    }

    get firstName(){
        return this._firstName;
    }
    set firstName(newFirstName){
        if(newFirstName.length < 3 || newFirstName.length > 20){
            throw new TypeError("First name must be between 3 and 20 characters long");
        }
        let firstNameRegex = /^[A-Za-z]+$/;
        if(! firstNameRegex.test(newFirstName)){
            throw new TypeError("First name must contain only Latin characters");
        }

        this._firstName = newFirstName;
    }

    get lastName(){
        return this._lastName;
    }
    set lastName(newLastName){
        if(newLastName.length < 3 || newLastName.length > 20){
            throw new TypeError("Last name must be between 3 and 20 characters long");
        }
        let lastNameRegex = /^[A-Za-z]+$/;
        if(! lastNameRegex.test(newLastName)){
            throw new TypeError("Last name must contain only Latin characters");
        }

        this._lastName = newLastName;
    }
}

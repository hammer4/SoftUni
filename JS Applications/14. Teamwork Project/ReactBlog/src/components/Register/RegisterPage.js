import React, {Component} from 'react';
import RegisterForm from './RegisterForm';
import {register} from '../../models/user';
import observer from '../../models/observer';

export default class RegisterPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: '',
            repeat: '',
            fullName: '',
            email: '',
            phone: '',
            submitDisabled: false };
        this.bindEventHandlers();
    }

    bindEventHandlers() {
        // Make sure event handlers have the correct context
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
        this.onSubmitResponse = this.onSubmitResponse.bind(this);
    }

    onChangeHandler(event) {
        switch (event.target.name) {
            case 'username':
                this.setState({ username: event.target.value });
                break;
            case 'password':
                this.setState({ password: event.target.value });
                break;
            case 'repeat':
                this.setState({ repeat: event.target.value });
                break;
            case 'fullName':
                this.setState({ fullName: event.target.value });
                break;
            case 'email':
                this.setState({ email: event.target.value });
                break;
            case 'phone':
                this.setState({ phone: event.target.value });
                break;
            default:
                break;
        }
    }

    onSubmitHandler(event) {
        event.preventDefault();
        if (this.state.password !== this.state.repeat) {
            observer.showError("Passwords don't match!");
            return;
        }
        if(this.state.username.length < 3){
            observer.showError("Username must be at least 3 symbols long.");
            return;
        }
        if(this.state.password.length < 3){
            observer.showError("Password must be at least 3 symbols long.");
            return;
        }
        this.setState({ submitDisabled: true });
        register(this.state.username,
            this.state.password,
            this.state.fullName,
            this.state.email,
            this.state.phone,
            this.onSubmitResponse);
    }

    onSubmitResponse(response) {
        if (response === true) {
            // Navigate away from register page
            this.context.router.push('/');
            observer.showSuccess("Registration successful!");
        } else {
            // Something went wrong, let the user try again
            let errorMsg = JSON.stringify(response);
            if (response.readyState === 0)
                errorMsg = "Cannot connect due to network error.";
            if (response.responseJSON && response.responseJSON.description)
                errorMsg = response.responseJSON.description;
            observer.showError(errorMsg);
            this.setState({ submitDisabled: false });
        }
    }

    render() {
        return (
            <div>
                <h1>Register</h1>
                <RegisterForm
                    username={this.state.username}
                    password={this.state.password}
                    repeat={this.state.repeat}
                    name={this.state.fullName}
                    email={this.state.email}
                    phone={this.state.phone}
                    submitDisabled={this.state.submitDisabled}
                    onChangeHandler={this.onChangeHandler}
                    onSubmitHandler={this.onSubmitHandler}
                />
            </div>
        );
    }
}

RegisterPage.contextTypes = {
    router: React.PropTypes.object
};
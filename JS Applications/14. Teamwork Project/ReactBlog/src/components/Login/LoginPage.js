import React, {Component} from 'react';
import LoginForm from './LoginForm';
import {login} from '../../models/user';
import observer from '../../models/observer';

export default class LoginPage extends Component {
    constructor(props) {
        super(props);
        this.state = { username: '', password: '', submitDisabled: false };
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
            default:
                break;
        }
    }

    onSubmitHandler(event) {
        event.preventDefault();
        this.setState({ submitDisabled: true });
        login(this.state.username, this.state.password, this.onSubmitResponse);
    }

    onSubmitResponse(response) {
        if (response === true) {
            // Navigate away from login page
            this.context.router.push('/');
            observer.showSuccess("Login successful!")
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
                <h1>Login</h1>
                <LoginForm
                    username={this.state.username}
                    password={this.state.password}
                    submitDisabled={this.state.submitDisabled}
                    onChangeHandler={this.onChangeHandler}
                    onSubmitHandler={this.onSubmitHandler}
                />
            </div>
        );
    }
}

LoginPage.contextTypes = {
    router: React.PropTypes.object
};
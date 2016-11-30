import React, { Component } from 'react';

export default class RegisterView extends Component {
    render() {
        return (
            <form className="register-form" onSubmit={this.submitForm.bind(this)}>
                <h1>Register</h1>
                <label>
                    <div>Username:</div>
                    <input type="text" name="username" required
                           ref={e => this.usernameField = e} />
                </label>
                <label>
                    <div>Password:</div>
                    <input type="password" name="password" required
                           ref={e => this.passwordField = e} />
                </label>
                <div>
                    <input type="submit" value="Register" />
                </div>
            </form>
        );
    }

    submitForm(event) {
        event.preventDefault();
        this.props.onsubmit(
            this.usernameField.value, this.passwordField.value);
    }
}

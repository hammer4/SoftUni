import alt from '../alt';

class UserActions {
    constructor() {
        this.generateActions(
            'registerUserSuccess',
            'registerUserFail',
            'loginUserSuccess',
            'loginUserFail',
            'logoutUserSuccess'
        );
    }

    registerUser (data) {
        let request = {
            url: '/user/register',
            method: 'post',
            data: JSON.stringify(data),
            contentType: 'application/json'
        }
        $.ajax(request)
            .done(() => this.registerUserSuccess())
            .fail(err => {
                console.log('error', err)
                this.registerUserFail(err.responseJSON.message)
            })
        
        return true
    }

    loginUser(data) {
        let request = {
            url: '/user/login',
            method: 'post',
            data: JSON.stringify(data),
            contentType: 'application/json'
        };
        $.ajax(request)
            .done(data => this.loginUserSuccess(data))
            .fail(err => this.loginUserFail(err.responseJSON));

        return true;
    }

    logoutUser() {
        let request = {
            url: '/user/logout',
            method: 'post'
        };
        $.ajax(request)
            .done(() => this.logoutUserSuccess());

        return true;
    }
}

export default alt.createActions(UserActions);
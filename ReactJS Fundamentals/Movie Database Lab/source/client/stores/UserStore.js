import alt from '../alt';
import AppActions from '../actions/UserActions';

class AppStore {
    constructor() {
        this.bindActions(AppActions);

        this.loggedInUserId = '';
        this.username =  '';
        this.roles =  [];
    }

    onLoginUserSuccess(user) {
        this.loggedInUserId = user._id;
        this.username = user.username;
        this.roles = user.roles;
    }

    onLoginUserFail() {
        console.log('Failed login attempt');
    }

    onLogoutUserSuccess() { // Redirect on part 3
        this.loggedInUserId = '';
        this.username =  '';
        this.roles =  [];
    }
}

export default alt.createStore(AppStore);
import React, {Component} from 'react';
import AuthorForm from './AboutForm';
import {loadAuthorsDetails} from '../../models/post'

export default class AboutPage extends Component {
    constructor(props) {
        super(props);
        this.state = {
            fullName: '',
            email: '',
            phone: '',
            submitDisabled: true };
        this.onLoadSuccess = this.onLoadSuccess.bind(this);
    }


    componentDidMount() {
        // Populate form
        loadAuthorsDetails(this.props.params.userId, this.onLoadSuccess);
    }



    onLoadSuccess(response) {

        this.setState({
            fullName: response[0].fullName,
            email: response[0].email,
            phone: response[0].phone,
        });
    }

    render() {
        return (
            <div>
                <h3>About Author</h3>
                <AuthorForm
                            fullName={this.state.fullName}
                            email={this.state.email}
                            phone={this.state.phone}
                />
            </div>

        );
    }
}
import React, {Component} from 'react';
import CreateForm from '../Create/CreateForm';
import {create} from '../../models/post';
import observer from '../../models/observer';

export default class CreatePage extends Component {
    constructor(props) {
        super(props);
        this.state = {title: '', content: '', submitDisabled: false};
        this.bindEventHandlers();
    }

    bindEventHandlers() {
        // Make sure event handlers have the correct context
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onSubmitHandler = this.onSubmitHandler.bind(this);
        this.onSubmitResponse = this.onSubmitResponse.bind(this);
    }

    onChangeHandler(event) {
        event.preventDefault();
        let newState = {};
        newState[event.target.name] = event.target.value;
        this.setState(newState);
    }

    onSubmitHandler(event) {
        event.preventDefault();
        this.setState({submitDisabled: true});
        create(this.state.title, this.state.content, this.onSubmitResponse);
    }

    onSubmitResponse(response) {
        this.context.router.push('/posts');
        observer.showSuccess("Post created!");
    }

    render() {
        return (
            <div>
                <h1>Your New Post</h1>
                <CreateForm
                    title={this.state.title}
                    content={this.state.content}
                    submitDisabled={this.state.submitDisabled}
                    onChangeHandler={this.onChangeHandler}
                    onSubmitHandler={this.onSubmitHandler}
                />
            </div>
        );
    }
}

CreatePage.contextTypes = {
    router: React.PropTypes.object
};
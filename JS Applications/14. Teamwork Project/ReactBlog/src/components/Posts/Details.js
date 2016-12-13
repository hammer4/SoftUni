import React, {Component} from 'react';
import {loadPostDetails} from '../../models/post';
import PostControls from './PostControls';
import './Details.css';
import CommentBox from '../Comments/CommentBox';
import Comment from '../Comments/Comment';
import {addComment, loadComments} from '../../models/comment';
import observer from '../../models/observer';

export default class Details extends Component {
    constructor(props) {
        super(props);
        this.state ={
            text: '',
            title: '',
            content: '',
            author: '',
            comments: [],
            canEdit: false
        };
        sessionStorage.setItem("canEdit",false);
        this.bindEventHandlers();
    }

    bindEventHandlers() {
        this.onChangeHandler = this.onChangeHandler.bind(this);
        this.onCommentSubmitHandler = this.onCommentSubmitHandler.bind(this);
        this.onCommentsLoadSuccess = this.onCommentsLoadSuccess.bind(this);
        this.onLoadSuccess = this.onLoadSuccess.bind(this);
        this.statusChange = this.statusChange.bind(this);
        this.onAddCommentSuccess = this.onAddCommentSuccess.bind(this);
    }

    statusChange(response) {
        this.context.router.push('/');
    }

    componentDidMount() {
        loadPostDetails(this.props.params.postId, this.onLoadSuccess);
        loadComments(this.props.params.postId, this.onCommentsLoadSuccess);
    }

    onCommentsLoadSuccess(response) {
        let newState = {
            comments: response
        };

        this.setState(newState);
    }

    onLoadSuccess(response) {
        let newState = {
            title: response.title,
            content: response.content,
            author: response._acl.creator
        };
        if (response._acl.creator === sessionStorage.getItem('userId')) {
            newState.canEdit = true;

        }
        this.setState(newState);
    }

    onChangeHandler(event) {
        event.preventDefault();
        let newState = {};
        newState[event.target.name] = event.target.value;
        this.setState(newState);
    }

    onCommentSubmitHandler(event) {
        event.preventDefault();
        addComment(this.props.params.postId, this.state.text,
            sessionStorage.getItem('username'), this.onAddCommentSuccess);
        this.setState({text: ''});
    }

    onAddCommentSuccess(){
        loadComments(this.props.params.postId, this.onCommentsLoadSuccess);
        observer.showSuccess("Comment added!");
    }


    render() {

        return (
            <div className="details-box">
                <span className="titlebar">{this.state.title}</span>
                <p>{this.state.content}</p>
                <PostControls
                    postId={this.props.params.postId}
                    canEdit={this.state.canEdit}
                    author={this.state.author}
                />

                <CommentBox
                    text={this.state.text}
                    onChangeHandler={this.onChangeHandler}
                    onCommentSubmitHandler={this.onCommentSubmitHandler}
                />
                <h3>Comments</h3>
                {this.state.comments.map(function (c, i) {
                    return <Comment
                        key={i}
                        text={c.text}
                        author={c.author}
                    />
                })}

            </div>
        )
    }
}

Details.contextTypes = {
    router: React.PropTypes.object
};
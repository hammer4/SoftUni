import React, {Component} from 'react';
import {deletePost} from '../../models/post';
import observer from '../../models/observer';

export default class DeletePost extends Component {
    constructor(props) {
        super(props);
        this.bindEventHandlers();
    }


    bindEventHandlers() {
        // Make sure event handlers have the correct context
        this.deleteThisPost = this.deleteThisPost.bind(this);
        this.onDelete = this.onDelete.bind(this);
    }

    deleteThisPost(){
        deletePost(this.props.params.postId, this.onDelete)
    }

    onDelete(){
        this.context.router.push('/posts');
        observer.showSuccess("Post deleted!");
    }

    render() {
        return (
            <div>
                <h3>Are you sure you want to delete this post?</h3>
                <button onClick={this.deleteThisPost} type="button" className="btn btn-danger">Delete</button>
            </div>
        );
    }
}

DeletePost.contextTypes = {
    router: React.PropTypes.object
};
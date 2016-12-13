import React, {Component} from 'react';
import {Link} from 'react-router';

export default class PostControls extends Component {
    render() {
        let edit = null;
        let deletePost = null;
        let infoAuthor = null;

        if (this.props.canEdit) {
            edit = <Link to={"/edit/" + this.props.postId} className="btn btn-default">Edit post</Link>;
            deletePost = <Link to={"/delete/" + this.props.postId} className="btn btn-default">Delete post</Link>;
        } else{
            infoAuthor = <Link to={"/about/" + this.props.author} className="btn btn-default">About Author</Link>;
        }
        return (
            <div>
                {edit}
                {deletePost}
                {infoAuthor}
            </div>
        )
    }
}
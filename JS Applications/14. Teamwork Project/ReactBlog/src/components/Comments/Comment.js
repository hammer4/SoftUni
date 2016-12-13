import React, {Component} from 'react';

export default class Comment extends Component {
    render() {
        return <div className="comment">
            <p>{this.props.text}</p>
            <span>by {this.props.author}</span>
            </div>
    }
}
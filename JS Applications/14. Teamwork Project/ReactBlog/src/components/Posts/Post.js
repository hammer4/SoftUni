import React, {Component} from 'react';
import {Link} from 'react-router';

export default class Post extends Component {
    subContent(){
        let subString = '';
        if(this.props.content.length > 80)
            subString = this.props.content.substring(0,80) + " ...";
        else
            subString = this.props.content;

        return subString;
    }
    render() {
        return(
            <div className="post">
                    <span className="title">{this.props.title}</span>
                    <p>{this.subContent()}</p>
                <Link to={"/posts/" + this.props.id} className="post-box">
                    <button className="btn btn-default">Details</button></Link>
                <hr/>
            </div>
        )
    }
}
import React, {Component} from 'react';
import {loadRecentPosts} from '../../models/post';
import Post from '../Posts/Post';

export default class HomePage extends Component {
    constructor(props){
        super(props);
        this.state = {posts: []};
        this.bindEventHandlers();
    }

    bindEventHandlers(){
        this.getLatestPosts = this.getLatestPosts.bind(this);
        this.onPostsLoad = this.onPostsLoad.bind(this);
    }

    componentDidMount(){
        if(sessionStorage.getItem('username')) {
            this.getLatestPosts();
        }
    }
    
    getLatestPosts(){
        loadRecentPosts(this.onPostsLoad)
    }

    onPostsLoad(response){
        this.setState({posts: response})
    }
    render() {
        let message = <p>You are currently not logged in. Please, log in or register to view, create and edit
            posts.</p>;

        if (sessionStorage.getItem('username')) {
            return <div>
            <h1>Latest Posts</h1>
            {this.state.posts.map((e, i) => {
                    return <Post key={i} title={e.title} id={e._id} content={e.content}/>
                })}
                </div>
        } else {
            return (
                <div>
                    {message}
                </div>
            );
        }
    }
}
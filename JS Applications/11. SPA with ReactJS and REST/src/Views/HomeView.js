import React, { Component } from 'react';

export default class HomeView extends Component {
    render() {
        return (
            <div className="home-view">
                <h1>Home</h1>
                { this.props.username ?
                    <p>Welcome, {this.props.username}.</p> :
                    <p>Welcome to the book library.</p>
                }
            </div>
        );
    }
}

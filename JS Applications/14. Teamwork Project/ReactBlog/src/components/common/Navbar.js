import React, {Component} from 'react';

export default class Navbar extends Component {
    render() {
        return (
            <div>
                {this.props.children}
            </div>
        );
    }
}
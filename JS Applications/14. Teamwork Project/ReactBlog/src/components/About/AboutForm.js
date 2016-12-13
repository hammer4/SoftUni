import React, {Component} from 'react';

export default class AboutForm extends Component {
    render() {
        return (
            <div className="author-info" >
                <div className="author-data">
                    <label>Name: </label>
                    <span>
                        {this.props.fullName}
                    </span>
                </div>
                <div className="author-data">
                    <label>Email: </label>
                    <span >
                        {this.props.email}
                    </span>
                </div>
                <div className="author-data">
                    <label>Phone: </label>
                    <span >
                        {this.props.phone}
                    </span>
                </div>

            </div>
        );
    }
}
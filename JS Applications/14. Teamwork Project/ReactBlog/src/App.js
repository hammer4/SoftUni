import React, {Component} from 'react';
import Header from './components/common/Header';
import Navbar from './components/common/Navbar';
import Infobox from  './components/common/Infobox';
import {Link} from 'react-router';
import observer from './models/observer';
import Footer from './components/common/Footer';

class App extends Component {
    constructor(props) {
        super(props);
        this.state = { loggedIn: false,
            username: ''
        };
        observer.onSessionUpdate = this.onSessionUpdate.bind(this);
    }

    componentDidMount() {
        this.onSessionUpdate();
    }

    onSessionUpdate() {
        let name = sessionStorage.getItem("username");
        if (name) {
            this.setState({ loggedIn: true, username: sessionStorage.getItem("username") });
        } else {
            this.setState({ loggedIn: false, username: '' });
        }
    }


    render() {
        let navbar = {};
        if (!this.state.loggedIn) {
            navbar = (
                    <Navbar>
                        <Link to="/" className="btn btn-default" activeClassName="btn btn-default active" onlyActiveOnIndex={true}>Home</Link>
                        <Link to="/login" className="btn btn-default" activeClassName="btn btn-default active">Login</Link>
                        <Link to="/register" className="btn btn-default" activeClassName="btn btn-default active">Register</Link>
                    </Navbar>
                );
        } else {
            navbar = (
                <Navbar>
                    <Link to="/" className="btn btn-default" activeClassName="btn btn-default active" onlyActiveOnIndex={true}>Home</Link>
                    <Link to="/posts" className="btn btn-default" activeClassName="btn btn-default active">Posts</Link>
                    <Link to="/create" className="btn btn-default" activeClassName="btn btn-default active">Create post</Link>
                    <Link to="/logout" className="btn btn-default" activeClassName="btn btn-default active">Logout</Link>
                </Navbar>
            );
        }

        return (
            <div className="container">
                <Header loggedIn={this.state.loggedIn} user={this.state.username}>
                    {navbar}
                </Header>
                {this.props.children}
                <Infobox/>
                <Footer/>
            </div>
        )
    }
}

export default App;

import React,{Component} from 'react'
import ShowMessage from './../sub-components/ShowPopupMessage'
import UserAction from './../../actions/UserActions'

export default class UserLogout extends Component{
  componentDidMount() {
    ShowMessage.info('You successfully logged out.')
    UserAction.logoutUser();
    this.props.history.push('/user/login');
  }
  render () {
    return (<div></div>)
  }
}
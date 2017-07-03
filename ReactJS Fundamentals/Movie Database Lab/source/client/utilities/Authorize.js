import React from 'react'
import UserStore from '../stores/UserStore'
import FormActions from '../actions/FormActions'

export default function authorize (ChildComponent) {
  return class Authorization extends React.Component {
    constructor (props) {
      super(props)
      this.state = UserStore.getState()
      this.onChange = this.onChange.bind(this)
    }

    onChange (state) {
      this.setState(state)
    }

    componentWillMount () {
      if (!this.state.loggedInUserId) {
        this.props.history.pushState(null, '/user/login')
        FormActions.unauthorizedAccessAttempt()
      }
    }

    componentDidMount () {
      UserStore.listen(this.onChange)
    }

    componentWillUnmount () {
      UserStore.unlisten(this.onChange)
    }

    render () {
      return <ChildComponent {...this.props} />
    }
  }
}

export class Concealer extends React.Component {
  constructor (props) {
    super(props)
    this.state = UserStore.getState()
    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentDidMount () {
    UserStore.listen(this.onChange)
  }

  componentWillUnmount () {
    UserStore.unlisten(this.onChange)
  }

  render () {
    let ChildComponent = this.props.ChildComponent

    return this.state.loggedInUserId ? <ChildComponent {...this.props} /> : null
  }
}

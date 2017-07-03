import React from 'react'

export default class Submit extends React.Component {
  render () {
    return <input type='submit' className={`btn ${this.props.type}`} value={this.props.value} />
  }
}

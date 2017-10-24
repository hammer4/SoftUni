import React from 'react'

export default class Submit extends React.Component {
  render () {
    return (
      <input
        type='submit'
        id={this.props.id}
        className={`btn ${this.props.className ? this.props.className : ''}`}
        value={this.props.value}
      />
    )
  }
}

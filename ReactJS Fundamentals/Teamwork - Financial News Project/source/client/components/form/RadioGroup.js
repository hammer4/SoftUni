import React from 'react'

export default class RadioGroup extends React.Component {
  render () {
    return (
      <div className={`form-group ${this.props.validationState}`}>
        <span className='help-block'>{ this.props.message }</span>
        { this.props.children }
      </div>
    )
  }
}

import React from 'react'

export default class TextGroup extends React.Component {
  render () {
    return (
      <div className={'form-group ' + this.props.validationState}>
        <label htmlFor={this.props.id} className='col-md-4 control-label'>{ this.props.label }: </label>
        <div className='col-md-8'>
          <input
            type={this.props.type}
            value={this.props.value}
            onChange={this.props.handleChange}
            autoFocus={this.props.autoFocus}
            className='form-control'
            id={this.props.id}
            placeholder={this.props.label}
          />
          <span className='help-block'>{ this.props.message }</span>
        </div>
      </div>
    )
  }
}

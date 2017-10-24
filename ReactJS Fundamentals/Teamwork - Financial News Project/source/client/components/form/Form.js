import React from 'react'

export default class Form extends React.Component {
  render () {
    return (
      <div className={this.props.className}>
        <div className='panel panel-default'>
          <div className='panel-heading'>{this.props.title}</div>
          <div className='panel-body'>
            <form onSubmit={this.props.handleSubmit}>
              <div className={`form-group ${this.props.submitState}`}>
                <span className={`help-block`}>{this.props.message}</span>
              </div>
              {this.props.children}
            </form>
          </div>
        </div>
      </div>
    )
  }
}

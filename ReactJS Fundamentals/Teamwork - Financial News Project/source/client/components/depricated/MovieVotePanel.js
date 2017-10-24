import React from 'react'
import FormActions from '../../actions/FormActions'
import MovieActions from '../../actions/MovieActions'
import FormStore from '../../stores/FormStore'

export default class MovieVotePanel extends React.Component {
  constructor (props) {
    super(props)
    this.state = FormStore.getState()
    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentWillMount () {
    FormStore.listen(this.onChange)
  }

  componentWillUnmount () {
    FormStore.unlisten(this.onChange)
  }

  handleSubmit (e) {
    e.preventDefault()

    if (this.state.score > 10) {
      FormActions.scoreValidationFail()
      return
    }

    MovieActions.addVote(this.props.movieId, this.state.score)
  }

  render () {
    return (
      <div
        className='col-sm-4 col-xs-offset-8 list-group-item animated fadeIn vote'>
        <div className='media'>
          <div className='media-body'>
            <div
              className={`form-group ${ this.state.scoreValidationState}`}>
              <span className='help-block'>{ this.state.message }</span>
            </div>
            <form className='form-inline'
              onSubmit={this.handleSubmit.bind(this)}>
              <div
                className={ `form-group ${this.state.scoreValidationState}`}>
                <label className='control-label'>Score</label>
                <input className='form-control'
                  step='0.1'
                  type='number'
                  value={this.state.score ||
                  this.props.loggedInUserScore}
                  onChange={FormActions.handleScoreChange} />
                <input className='btn btn-primary' type='submit' value='Vote' />
              </div>
            </form>
          </div>
        </div>
      </div>
    )
  }
}

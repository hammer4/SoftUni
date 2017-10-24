import React from 'react'
import CategoryStore from '../../stores/CategoryStore'
import CategoryActions from '../../actions/CategoryActions'
import ShowMessage from './../sub-components/ShowPopupMessage'
import alt from '../../alt'

export default class CategoryAddPage extends React.Component {
  constructor (props) {
    super(props)

    this.state = CategoryStore.getState()

    this.onChange = this.onChange.bind(this)
    this.handleCategoryCreation = this.handleCategoryCreation.bind(this)
  }

  onChange (state) {
    this.setState(state)
    if (state.categoryCreated) {
      this.handleCategoryCreation()
    }
  }

  componentDidMount () {
    CategoryStore.listen(this.onChange)
  }

  componentWillUnmount () {
    CategoryStore.unlisten(this.onChange)
  }

  handleSubmit (ev) {
    ev.preventDefault()

    let name = this.state.name
    if (name) {
      CategoryActions.createCategory(name)
    }
  }

  handleCategoryCreation (category) {
    ShowMessage.success(`Category '${this.state.name}' created!`)
    alt.recycle(CategoryStore)
    this.props.history.push('/categories/all')
  }

  render () {
    return (
      <div className='container'>
        <div className='row flipInX animated'>
          <div className='container'>
            <div className='col-md-6 col-md-offset-3'>
              <div className='panel panel-default'>
                <div className='panel-heading'>Add new category</div>
                <div className='panel-body'>
                  <form onSubmit={this.handleSubmit.bind(this)} >
                    <div className='form-group'>
                      <label className='control-label'>Name</label>
                      <input
                        type='text'
                        name='name'
                        required
                        className='form-control'
                        onChange={CategoryActions.handleNameChange}
                        value={this.state.name} />
                    </div>
                    <button type='submit' className='btn btn-primary'>Submit</button>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    )
  }
}

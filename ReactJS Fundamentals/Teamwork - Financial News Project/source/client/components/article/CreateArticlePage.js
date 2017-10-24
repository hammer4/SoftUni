import React from 'react'
import ArticleStore from '../../stores/ArticleStore'
import ArticleActions from '../../actions/ArticleActions'
import ShowMessage from './../sub-components/ShowPopupMessage'
import alt from '../../alt'
import Auth from './../user/Auth'

export default class CreateArticlePage extends React.Component {
  constructor (props) {
    super(props)

    this.state = ArticleStore.getState()

    this.onChange = this.onChange.bind(this)
    this.handleArticleCreation = this.handleArticleCreation.bind(this)
  }

  onChange (state) {
    this.setState(state)
    if (state.articleCreated) {
      this.handleArticleCreation()
    }
  }

  componentDidMount () {
    ArticleStore.listen(this.onChange)
    ArticleActions.getAllCategories()
  }

  componentWillUnmount () {
    ArticleStore.unlisten(this.onChange)
  }

  handleSubmit (ev) {
    ev.preventDefault()

    if (!this.state.title) {
      return
    }

    if (!this.state.category) {
      return
    }

    let data = {
      title: this.state.title,
      description: this.state.description,
      category: this.state.category,
      image: this.state.image,
      creator: Auth.getToken()
    }

    ArticleActions.createArticle(data)
  }

  handleArticleCreation () {
    ShowMessage.success(`Article '${this.state.title}' created!`)
    let id = this.state._id;
    alt.recycle(ArticleStore)
    this.props.history.push(`/article/${id}`)
  }

  render () {
    let categories = this.state.categories.map(c => {
      return <option key={c._id} value={c._id}>{c.name}</option>
    })

    return (
      <div className='container'>
        <div className='row flipInX animated'>
          <div className='container'>
            <div className='col-md-6 col-md-offset-3'>
              <div className='panel panel-default'>
                <div className='panel-heading'>Add new article</div>
                <div className='panel-body'>
                  <form onSubmit={this.handleSubmit.bind(this)}>
                    <div className='form-group'>
                      <label className='control-label'>Title</label>
                      <input type='text'
                        className='form-control'
                        value={this.state.title}
                        onChange={ArticleActions.handleTitleChange} />
                    </div>
                    <div className='form-group'>
                      <label className='control-label'>Description</label>
                      <textarea
                        className='form-control'
                        rows='5'
                        value={this.state.description}
                        onChange={ArticleActions.handleDescriptionChange} />
                    </div>
                    <div className='form-group'>
                      <label className='control-label'>Category</label>
                      <select
                        className='form-control'
                        value={this.state.category}
                        onChange={ArticleActions.handleCategoryChange}
                        required >
                        <option disabled>Select a category</option>
                        {categories}
                      </select>
                    </div>
                    <div className='form-group'>
                      <label className='control-label'>Image</label>
                      <input type='url'
                        className='form-control'
                        value={this.state.image}
                        onChange={ArticleActions.handleImageChange} />
                    </div>
                    <button type='submit' className='btn btn-primary'>Submit
                    </button>
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

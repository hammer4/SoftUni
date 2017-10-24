import React from 'react'

import ArticleActions from '../actions/ArticleActions'
import ArticleStore from '../stores/ArticleStore'
import Helpers from '../utilities/Helpers'
import {Link} from 'react-router'

export default class Home extends React.Component {
  constructor (props) {
    super(props)

    this.state = ArticleStore.getState()

    this.onChange = this.onChange.bind(this)
  }

  onChange (state) {
    this.setState(state)
  }

  componentDidMount () {
    ArticleStore.listen(this.onChange)
    ArticleActions.getLatestNews()
  }

  componentWillUnmount () {
    ArticleStore.unlisten(this.onChange)
  }

  render () {
    let news = this.state.latestNews.map((article, index) => {
      return (
        <div className='single-article' key={index}>
          <Link to={`/article/${article._id}`}>
            <img src={article.image} alt='article' />
            <h3>{article.title}</h3>
          </Link>
          <p>{Helpers.formatDate(article.dateCreated)}</p>
          <p>{article.description.substr(0, 300)}</p>
        </div>
      )
    })

    return (
      <div className='container'>
        <h3 className='text-center'>Welcome to
          <strong> Financial News</strong>
        </h3>
        <div className='list-group'>
          {news}
        </div>
      </div>
    )
  }
}

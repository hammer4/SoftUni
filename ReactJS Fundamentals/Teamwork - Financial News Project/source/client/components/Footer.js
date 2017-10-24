import React from 'react'
import { Link } from 'react-router'

import ArticleActions from '../actions/ArticleActions'
import ArticleStore from '../stores/ArticleStore'

export default class Footer extends React.Component {
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
  }

  componentWillUnmount () {
    ArticleStore.unlisten(this.onChange)
    clearInterval(this.interval)
  }

  render () {
    return (
      <footer>
        <div className='container'>
          <div className='row'>
            <div className='col-sm-5'>
              <p className='lead'>
                <strong>Information</strong> and
                <strong> Copyright</strong>
              </p>
              <p>
                Powered by
                <strong> Express</strong>,
                <strong> MongoDB</strong> and
                <strong> React</strong>
              </p>
              <p>© 2017 Financial News.</p>
            </div>
            <div className='col-sm-4 hidden-xs'>
              <p className='lead'>
                <strong>Newest</strong> 6 News
              </p>
              <ul className='list-inline'>

              </ul>
            </div>
            <div className='col-sm-3'>
              <p className='lead'>Team Project</p>
              <a href='https://github.com/worminer/React.js-Financial-News'>
                <strong>Cal Poli green</strong>
              </a>
            </div>
          </div>
        </div>
      </footer>
    )
  }
}

import React from 'react'
import ArticleStore from '../../stores/ArticleStore'
import ArticleActions from '../../actions/ArticleActions'
import ArticleCard from './ArticleCard'

export default class ArticleDetailsPage extends React.Component {
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
    ArticleActions.getById(this.props.params.id)
  }

  componentWillUnmount () {
    ArticleStore.unlisten(this.onChange)
  }

  render () {
    console.log(this.state.article.creator)
    return (
      <ArticleCard article={this.state.article}
                   comments={this.state.comments}
                   creator={this.state.creator}
                   category={this.state.category} />
    )
  }
}

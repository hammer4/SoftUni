import React from 'react'
import {Link} from 'react-router'
import Helpers from '../../utilities/Helpers'

class ArticleCard extends React.Component {
  render () {
    return (
      <div className='container'>
        <div className='well'>
          <div className='media'>
            <div className="media-container col-md-12">
              <img className='media-object pull-left' src={this.props.article.image} />
            </div>
            <div className='media-body'>
              <div className="well">
                <h4 className='media-heading'><strong>{this.props.article.title}</strong></h4>
                <span className="pull-right">
                   Whiten by:{this.props.creator.username}
                </span>
              </div>
              <div className="jumbotron">
                <p>{this.props.article.description}</p>
              </div>
              <div>
                <ul className='list-inline list-unstyled'>
                  <li><span><i className='glyphicon glyphicon-calendar' />
                    {Helpers.formatDate(this.props.article.dateCreated)}</span></li>
                  <li>|</li>
                  <span><i className='glyphicon glyphicon-comment' /> {this.props.comments.length} comments</span>
                  <li>|</li>
                  <li>
                    <span className='glyphicon glyphicon-thumbs-up' /><span> {this.props.article.likes}</span>
                  </li>
                  <li>|</li>
                </ul>
              </div>

            </div>
          </div>
        </div>
      </div>
    )
  }
}

export default ArticleCard

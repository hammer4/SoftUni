import React from 'react'

import UserReviewsPanel from './UserReviewsPanel'

export default class UserReviews extends React.Component {
  constructor (props) {
    super(props)

    this.state = {
      showReviewsPanel: false
    }
  }

  toggleReviews () {
    this.setState(prevState => ({
      showReviewsPanel: !prevState.showReviewsPanel
    }))
  }

  render () {
    return (
      <div className='container profile-container'>
        <div className='profile-stats clearfix'>
          <ul>
            <li>
              <span className='stats-number'>{this.props.reviews
                ? this.props.reviews.length
                : 0}</span>Reviews
            </li>
          </ul>
        </div>
        <div className='pull-right btn-group'>
          <a className='btn btn-primary'
            onClick={this.toggleReviews.bind(this)}>
            { this.state.showReviewsPanel ? 'Hide' : 'Reviews' }
          </a>
        </div>
        { this.state.showReviewsPanel
        ? <UserReviewsPanel reviews={this.props.reviews} /> : null }
      </div>
    )
  }
}

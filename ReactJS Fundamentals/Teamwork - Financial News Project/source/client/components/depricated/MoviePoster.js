import React from 'react'

export default class MoviePoster extends React.Component {
  constructor (props) {
    super(props)
  }

  render () {
    let poster
    if (this.props.posterUrl) {
      poster = (
        <div className='pull-left thumb-lg'>
          <img className='media-object' src={this.props.posterUrl} />
        </div>
      )
    }

    return poster
  }
}

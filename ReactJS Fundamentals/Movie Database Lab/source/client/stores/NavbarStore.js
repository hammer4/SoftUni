import alt from '../alt'
import NavbarActions from '../actions/NavbarActions'

class NavbarStore {
  constructor () {
    this.bindActions(NavbarActions)

    this.ajaxAnimationClass = ''
  }

  onUpdateAjaxAnimation (animationClass) {
    this.ajaxAnimationClass = animationClass
  }
}

export default alt.createStore(NavbarStore)

import { Component, Input } from '@angular/core'

@Component({
  selector: 'detail',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})

export class DetailsComponent {
  @Input() article;

  showImage = true;
  currentLength = 250;
  size = 20;
  textColor = 'black';
  backgroundColor = 'white'
  showHideImage () {
    this.showImage = !this.showImage;
  }

  cutText(text) {
    return this.article.description.substr(0, this.currentLength)
  }

  showMore() {
    this.currentLength += 250;
  }

  changeSize(currentSize) {
    this.size = currentSize;
  }

  changeTextColor (event) {
    this.textColor = event.target.value;
  }

  changeBackgroundColor (event) {
    this.backgroundColor = event.target.value;
  }
}
import {Directive, ElementRef} from '@angular/core'

@Directive({
  selector: '[borderRadius]'
})

export class BorderRadiusDirective {
  constructor (private el: ElementRef) {
    this.el.nativeElement.style.borderRadius = '20%'
  }
}
import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';
// declare var componentHandler: any;

// @Component({
//   selector: 'filter-text',
//   templateUrl: './filter-text.component.html',
//   styleUrls: ['./filter-text.component.css']  
// })
// export class FilterTextComponent implements OnInit {
//   @Output() changed: EventEmitter<string>;
//   filter: string;

//   clear() {
//     this.filter = '';
//   }

//   filterChanged(event: any) {
//     event.preventDefault();
//     console.log(`Filter Changed: ${this.filter}`);
//     this.changed.emit(this.filter);
//   }

//   ngOnInit() {
//     this.changed = new EventEmitter<string>();
//     // componentHandler.upgradeDom();
//   }  
// }

// import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'filter-text',
  templateUrl: './filter-text.component.html',
  styleUrls: ['./filter-text.component.css']
})
export class FilterTextComponent implements OnInit {
  @Output() changed: EventEmitter<string>;
  filter: string;
  
  constructor() { 
    this.changed = new EventEmitter<string>();
  }

  filterChanged(event: any) {
    event.preventDefault();
    console.log(`Filter Changed: ${this.filter}`);
    this.changed.emit(this.filter);
  }  

  ngOnInit() {
    // componentHandler.upgradeDom();
  }    

}

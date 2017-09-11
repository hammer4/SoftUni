import { Component, OnInit } from '@angular/core';

import { NgRedux } from 'ng2-redux';
import { IAppState } from '../store';

@Component({
  selector: 'message-handler',
  template:`<div>{{message}}</div>`
})
export class MessageHandlerComponent implements OnInit {
  message: string;

  constructor (private ngRedux: NgRedux<IAppState>) { }

  ngOnInit () {
    this.ngRedux
      .select(state =>state.core.message)
      .subscribe(message => this.message = message);
  }
}
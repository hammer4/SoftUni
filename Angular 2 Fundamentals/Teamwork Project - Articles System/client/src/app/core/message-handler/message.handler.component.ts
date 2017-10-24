import { Component, OnInit } from '@angular/core';
import {NgRedux} from 'ng2-redux';
import {IAppState} from '../../store/app.state';
import {IMessage} from '../../store/core/core.state';


@Component({
  selector: 'app-message-handler',
  templateUrl: './message.handler.component.html',
  styleUrls: ['./message.handler.component.css']
})
export class MessageHandlerComponent implements OnInit{
  message: string;
  errors: IMessage[];

  constructor(private ngRedux: NgRedux<IAppState>) { }

  ngOnInit(): void {

    this.ngRedux
      .select(state => state.core.message)
      .subscribe(message => this.message = message);

    this.ngRedux
      .select(state => state.core.errors)
      .subscribe(errors => this.errors = errors);
  }




}

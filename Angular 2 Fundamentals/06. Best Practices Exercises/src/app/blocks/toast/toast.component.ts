import { Component, OnInit } from '@angular/core';
import { ToastService } from './toast.service'

@Component({
  selector: 'toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css']
})
export class ToastComponent implements OnInit {
  private _defaults = {
    title: '',
    message: 'May the Force be with You'
  };
  title: string;
  message: string;
  private _toastElement: any;

  constructor(toastService: ToastService) {
    toastService.activate = this.activate.bind(this);
  }

  activate(message = this._defaults.message, title = this._defaults.title) {
    this.title = title;
    this.message = message;
    this._show();
  }  


  private _show() {
    console.log(this.message);
    this._toastElement.style.opacity = 1;
    this._toastElement.style.zIndex = 9999;

    window.setTimeout(() => this._hide(), 2500);
  }

  private _hide() {
    this._toastElement.style.opacity = 0;
    window.setTimeout(() => this._toastElement.style.zIndex = 0, 400);
  }  

  ngOnInit() {
    this._toastElement = document.getElementById('toast');
  }

}

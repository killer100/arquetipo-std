import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'menu-options',
  templateUrl: './menu-options.component.html'
})
export class MenuOptionsComponent implements OnInit {

  @Input() options: Array<object>;

  constructor() { }

  ngOnInit() {
  }

}
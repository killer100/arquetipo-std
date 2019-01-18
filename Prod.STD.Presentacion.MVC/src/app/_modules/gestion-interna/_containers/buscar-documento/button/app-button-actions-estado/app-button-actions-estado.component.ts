import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-button-actions-estado',
  templateUrl: './app-button-actions-estado.component.html',
})
export class AppButtonActionsEstadoComponent implements OnInit {

  @Input()
  codEstadoDocInterno: number;
  
  constructor() { }

  ngOnInit() {
  }

}

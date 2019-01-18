import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-app-button-actions-documento',
  templateUrl: './app-button-actions-documento.component.html',
})
export class AppButtonActionsDocumentoComponent implements OnInit {

  @Input()
  documento: any;
  constructor() { }
  ngOnInit() {
   
  }

}

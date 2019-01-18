import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'logo-section',
  templateUrl: './logo-section.component.html'
})
export class LogoSectionComponent implements OnInit {

  @Input() logo: string;
  @Input() nombreDesc: string;

  constructor() { }

  ngOnInit() {
  }

}
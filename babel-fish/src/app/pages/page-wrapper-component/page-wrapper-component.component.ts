import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../header/header.component';
import { HeaderService } from '../../services/header.service';

@Component({
  selector: 'app-page-wrapper-component',
  templateUrl: './page-wrapper-component.component.html',
  styleUrls: ['./page-wrapper-component.component.scss']
})
export class PageWrapperComponent implements OnInit {

  constructor(private headerService: HeaderService) { }

  ngOnInit(): void {
    this.headerService.setTitle('Intelligence');
  }

}

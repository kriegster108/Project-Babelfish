import { Component, OnInit } from '@angular/core';
import { DifferatorService } from '../../services/differator.service';
import { HeaderService } from '../../services/header.service';

@Component({
  selector: 'app-differator',
  templateUrl: './differator.component.html',
  styleUrls: ['./differator.component.scss']
})
export class DifferatorComponent implements OnInit {

  completeMessage : string;
  loading = false;

  constructor(
    private differatorService: DifferatorService,
    private headerService: HeaderService
  ) { }

  ngOnInit(){
    this.headerService.setTitle('Differator');
  }

  differentiate(language : string){
    this.loading = true;
    this.differatorService.differentiateItBroSki(language).subscribe(data => {
      data.subscribe(data2 => {
        this.completeMessage = 'Differentiation complete!';
        this.loading = false;
      });
    });

  }
}

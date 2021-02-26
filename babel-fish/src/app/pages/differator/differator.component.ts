import { Component, OnInit } from '@angular/core';
import { DifferatorService } from '../../services/differator.service'

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
  ) { }

  ngOnInit(): void {
  }

  differentiate(language : string){
    this.loading = true;
    this.differatorService.differentiateItBroSki(language).subscribe(data => {
      data.subscribe(data2 => {
        this.completeMessage = 'Differentiation complete!';
        this.loading = false;
      })
    })
  }

//   whoever uses it from the UI, all you gotta do is inject DifferatorService into your component, and then call
// differentiateItBroSki(language: string) with language being like en or es

}

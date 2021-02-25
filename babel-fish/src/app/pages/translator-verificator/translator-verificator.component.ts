import { Component, OnInit, Input } from '@angular/core';
@Component({
  selector: 'app-translator-verificator',
  templateUrl: './translator-verificator.component.html',
  styleUrls: ['./translator-verificator.component.scss'],
})

export class TranslatorVerificatorComponent implements OnInit {

  @Input() translation : any

  translating = false;

  constructor() {

  }

  ngOnInit(): void {

    // this.nextTranslation(this.translation);

  }

  newTranslation(){
    setTimeout(() => {
      this.translating = true;
    }, 1000);
    }

    doneTranslation(){
      this.translating = false
    }

  }


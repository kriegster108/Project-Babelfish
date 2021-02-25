import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TranslationStationService } from '../../services/translation-station.service';

@Component({
  selector: 'app-translator-verificator',
  templateUrl: './translator-verificator.component.html',
  styleUrls: ['./translator-verificator.component.scss'],
})

export class TranslatorVerificatorComponent implements OnInit {
  languageObject: any;
  @Input() translation : any;
  langList: string[] = ['es'];
  myGroup:any;
  languageSelected = false;
  loading = false;
  translating = false;

  constructor(
    private langService : TranslationStationService
  ) {

  }

  ngOnInit(): void {
    this.myGroup = new FormGroup({
      langs: new FormControl()
    });
  }

  loadLanguage() {
    this.loading = true;
    this.langService.getUnverifiedLanguage(this.myGroup.controls.langs.value).subscribe(data => {
      this.languageObject = data;
      console.log(this.languageObject);
      this.languageSelected = true;
      this.loading = false;
    });
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


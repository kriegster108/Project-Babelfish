import { Component, OnInit, Input, ChangeDetectorRef } from '@angular/core';
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
  verificationForm: any;
  languageSelected = false;
  loading = false;
  translating = false;
  iterator = 0;
  translationsDone = false;
  constructor(
    private langService : TranslationStationService,
    private cd: ChangeDetectorRef 
  ) {

  }

  ngOnInit(): void {
    this.myGroup = new FormGroup({
      langs: new FormControl()
    });
    this.verificationForm = new FormGroup({
      english: new FormControl('', []),
      spanish: new FormControl()
    });
  }

  loadLanguage() {
    this.loading = true;
    // this.langService.getUnverifiedLanguage(this.myGroup.controls.langs.value).subscribe(data => {
    //   this.languageObject = data;
    //   console.log(this.languageObject);
    //   this.setItem();
    //   this.languageSelected = true;
    //   this.loading = false;
    // });
    //temporary
    this.languageObject = [
      {
        key: "thing",
        enVal: "thing",
        value: "spanish thing"
      },
      {
        key: "thing2",
        enVal: "thing2",
        value: "spanish thing2"
      }
    ];
    if(this.languageObject.length > 0) {
      this.setItem();
      this.languageSelected = true;
      this.loading = false;
    } else {
      this.outOfThings();
    }
    
  }

  setItem() {
    this.languageSelected = false;
    let item = this.languageObject[this.iterator];
    this.verificationForm.controls["english"].value = item.enVal;
    this.verificationForm.controls["english"].disable();
    this.verificationForm.controls["spanish"].value = item.value;
    this.cd.detectChanges();
    this.languageSelected = true;
  }

  nextItem() {
    if(this.iterator < this.languageObject.length - 1){
      this.iterator = this.iterator + 1;
      this.setItem();
    } else {
      this.outOfThings();
    }
  }

  submitTranslation() {
    // todo
  }

  outOfThings() {
    this.languageSelected = false;
    this.translationsDone = true;
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


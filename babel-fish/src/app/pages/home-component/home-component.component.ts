import { Component, OnInit } from '@angular/core';
import { LanguageService } from '../../services/language.service';
import { FormControl, FormGroup} from '@angular/forms';

@Component({
  selector: 'app-home-component',
  templateUrl: './home-component.component.html',
  styleUrls: ['./home-component.component.scss']
})
export class HomeComponent implements OnInit {
  myGroup:any;
  languageNotSelected = true;
  loading = false;
  showLangs = false;
  langList: string[] = ['en', 'es'];
  languageObject: any;
  langForm: any;
  constructor(
    private langService : LanguageService
  ) { }

  ngOnInit(): void {
    this.myGroup = new FormGroup({
      langs: new FormControl()
    });
  }

  loadLanguage() {
    this.languageNotSelected = false;
    this.loading = true;
    console.log(this.myGroup.controls.langs.value);
    this.langService.getLanguageObject(this.myGroup.controls.langs.value).subscribe(data => {
      this.languageObject = data;
      console.log(this.languageObject);
      this.languageNotSelected = true;
      this.loading = false;
      this.showLangs = true;
    });
  }

}

import { Component, OnInit } from '@angular/core';
import {DifferatorService} from '../services/differator.service'
import { LanguageService } from '../services/language.service';
import * as englishObj from '../../languages/english.json';

@Component({
  selector: 'app-differator',
  templateUrl: './differator.component.html',
  styleUrls: ['./differator.component.scss']
})
export class DifferatorComponent implements OnInit {
  private _diff: DifferatorService
  private _lang: LanguageService
  private _langObj;
  constructor(differator: DifferatorService, language: LanguageService) { this._diff = differator, this._lang = language}

  ngOnInit(): void {
   this._lang.getLanguageObject('en').subscribe((obj) =>{
     this._langObj = obj;
   })
  }
  public execute() {
    this._diff.differator(this._langObj, englishObj)
  }

}

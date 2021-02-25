import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import * as english from '../../languages/english.json';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  constructor() { }

  getLanguageObject(language: string): Observable<any> {
    return new Observable((observer) => {
      if(language === 'en') {
        observer.next(english);
        observer.complete();
      } else {
        this.getThatOtherLanguage(language).subscribe((data) => {
          observer.next(data);
          observer.complete();
        });
      }
    });
  }

  getThatOtherLanguage(language: string) {
    //this will hit the BE and get the other language objects
    return new Observable();
  }
}
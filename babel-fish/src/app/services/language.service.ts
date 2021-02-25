import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import english from '../../languages/english.json';
import { TranslationStationService } from './translation-station.service';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {

  constructor(
    private translationStationService: TranslationStationService
  ) { }

  getLanguageObject(language: string): Observable<any> {
    return new Observable((observer) => {
      if(language === 'en') {
        observer.next(english);
        observer.complete();
      } else {
        this.translationStationService.getLanguage(language).subscribe((data) => {
          observer.next(data);
          observer.complete();
        });
      }
    });
  }

}

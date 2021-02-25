import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './pages/home-component/home-component.component';
import { PageWrapperComponent } from './pages/page-wrapper-component/page-wrapper-component.component';
import { HeaderComponent } from './pages/header/header.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
<<<<<<< Updated upstream
import { HttpClientModule } from '@angular/common/http';
import { DifferatorComponent } from './differator/differator.component';
=======
import { TranslatorVerificatorComponent } from './pages/translator-verificator/translator-verificator.component';
>>>>>>> Stashed changes

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PageWrapperComponent,
    HeaderComponent,
<<<<<<< Updated upstream
    DifferatorComponent
=======
    TranslatorVerificatorComponent
>>>>>>> Stashed changes
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

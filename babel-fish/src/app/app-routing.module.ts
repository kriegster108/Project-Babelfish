import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageWrapperComponent } from './pages/page-wrapper-component/page-wrapper-component.component';
import { HomeComponent } from './pages/home-component/home-component.component'
import { TranslatorVerificatorComponent } from './pages/translator-verificator/translator-verificator.component';
import { DifferatorComponent } from './pages/differator/differator.component';

const routes: Routes = [
  {
    path: '',
    component: PageWrapperComponent,
    children: [
      {
        path: '',
        component: HomeComponent
      },
      {
        path: 'translator-verificator',
        component: TranslatorVerificatorComponent
      },
      {
        path: 'differator',
        component: DifferatorComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

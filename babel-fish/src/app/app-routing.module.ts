import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageWrapperComponent } from './pages/page-wrapper-component/page-wrapper-component.component';
import { HomeComponent } from './pages/home-component/home-component.component'

const routes: Routes = [
  {
    path: '',
    component: PageWrapperComponent,
    children: [
      {
        path: '',
        component: HomeComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

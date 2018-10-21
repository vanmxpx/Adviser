import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FoodcostComponent } from './Components/foodcost/foodcost.component';
import { PurchasesComponent } from './Components/purchases/purchases.component';
import { AppComponent } from './app.component';
import { SettingsComponent } from './Components/settings/settings.component';

const routes: Routes = [

  {path: 'foodcost', component: FoodcostComponent},
  {path: 'purchases', component: PurchasesComponent},
  {path: 'settings', component: SettingsComponent},
  {path: '**', component: PurchasesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

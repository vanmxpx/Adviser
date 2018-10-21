import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FoodcostComponent } from './Components/foodcost/foodcost.component';
import { PurchasesComponent } from './Components/purchases/purchases.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatMenuModule,
  MatButtonModule,
  MatIconModule,
  MatListModule,
  MatCardModule
} from '@angular/material';
import { DynamicChartComponent } from './Components/purchases/dynamic-chart/dynamic-chart.component';
import { SettingsComponent } from './Components/settings/settings.component';

@NgModule({
  declarations: [
    AppComponent,
    FoodcostComponent,
    PurchasesComponent,
    DynamicChartComponent,
    SettingsComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    MatListModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  exports: [

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FoodcostComponent } from './Components/foodcost/foodcost.component';
import { PurchasesComponent } from './Components/purchases/purchases.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatTableModule,
  MatMenuModule,
  MatExpansionModule,
  MatButtonModule,
  MatIconModule,
  MatListModule,
  MatFormFieldModule,
  MatInputModule,
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
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatFormFieldModule,
    MatInputModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MatListModule,
    MatMenuModule,
    MatButtonModule,
    MatIconModule,
    MatExpansionModule,
    MatCardModule
  ],
  exports: [

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

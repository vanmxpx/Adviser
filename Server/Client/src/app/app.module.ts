import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FoodcostComponent } from './Components/foodcost/foodcost.component';
import { PurchasesComponent } from './Components/purchases/purchases.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
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
import { DaterpickerRangeComponent } from './Components/purchases/daterpicker-range/daterpicker-range.component';

@NgModule({
  declarations: [
    AppComponent,
    FoodcostComponent,
    PurchasesComponent,
    DynamicChartComponent,
    SettingsComponent,
    DaterpickerRangeComponent
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
    MatCardModule,
    NgbModule
  ],
  exports: [

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

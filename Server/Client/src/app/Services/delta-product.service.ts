import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DeltaProductSetup } from '../Components/purchases/purchases.component';

import { DeltaProduct } from '../Models/deltaProduct';
import { DeltaDTO } from '../Models/deltaDTO';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Injectable({
  providedIn: 'root'
})
export class DeltaProductService {

  constructor(private http: HttpClient) { }
  public async GetDeltaProduct(): Promise<DeltaProductSetup[]> {
    let delta1 = await this.http.get<DeltaDTO[]>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=3&year=2016').toPromise();
    let delta2 = await this.http.get<DeltaDTO[]>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=4&year=2016').toPromise();
    let delta3 = await this.http.get<DeltaDTO[]>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=5&year=2016').toPromise();
    let delta4 = await this.http.get<DeltaDTO[]>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=6&year=2016').toPromise();

    const products: DeltaProductSetup[] = [

    ];
    // tslint:disable-next-line:prefer-const
    let prod1: DeltaProductSetup = new DeltaProductSetup();
    prod1.CurrentMonth = {
      Name: 'RedBull',
      SupplySum: 100,
      WastedSum: 8,
      InventorySum: 92,
      Sales: 100,
      Delta: 0,
      Leftovers: 3,
      LeftoversUnit: 'l'
    };
    prod1.LastMonth = {
      Name: 'RedBull',
      SupplySum: 99,
      WastedSum: 7,
      InventorySum: 91,
      Sales: 99,
      Delta: 1,
      Leftovers: 2,
      LeftoversUnit: 'l'
    };

    let prod2: DeltaProductSetup = new DeltaProductSetup();
    prod2.CurrentMonth = {
      Name: 'Coffee',
      SupplySum: 50,
      WastedSum: 0,
      InventorySum: 11,
      Sales: 100,
      Delta: 1,
      Leftovers: 3,
      LeftoversUnit: 'l'
    };
    prod2.LastMonth = {
      Name: 'Coffee',
      SupplySum: 34,
      WastedSum: 2,
      InventorySum: 23,
      Sales: 99,
      Delta: 1,
      Leftovers: 2,
      LeftoversUnit: 'l'
    };

products.push(prod1);
products.push(prod2);
    return products;
  }
}

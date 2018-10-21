import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DeltaProductSetup } from '../Components/purchases/purchases.component';

import { map, catchError } from 'rxjs/operators';

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
    // tslint:disable-next-line:max-line-length
    // const delta1 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=3&year=2016').toPromise();

    // const delta2 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=4&year=2016').toPromise();
    // const delta3 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=5&year=2016').toPromise();
    // const delta4 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=6&year=2016').toPromise();

    const products: DeltaProductSetup[] = [

    ];
    const delta1: DeltaProductSetup = new DeltaProductSetup();
    const delta2: DeltaProductSetup = new DeltaProductSetup();

    const prod1: DeltaProduct = {
       Name: 'RedBull',
       SupplySum: 10,
       WastedSum: 2,
       InventorySum: 89,
       Sales: 40,
       Delta: -32,
       Leftovers: 49,
       LeftoversUnit: 's',
    };
    const prod2: DeltaProduct = {
      Name: 'RedBull',
      SupplySum: 120,
      WastedSum: 5,
      InventorySum: 115,
      Sales: 34,
      Delta: 81,
      Leftovers: 81,
      LeftoversUnit: 's',
   };

   const prod3: DeltaProduct = {
    Name: 'Coca-cola',
    SupplySum: 90,
    WastedSum: 12,
    InventorySum: 89,
    Sales: 40,
    Delta: -32,
    Leftovers: 47,
    LeftoversUnit: 's',
 };
 const prod4: DeltaProduct = {
   Name: 'Coca-cola',
   SupplySum: 100,
   WastedSum: 20,
   InventorySum: 79,
   Sales: 34,
   Delta: 23,
   Leftovers: 12,
   LeftoversUnit: 's',
};


    delta1.CurrentMonth = prod1;
    delta1.LastMonth = prod2;

    delta2.CurrentMonth = prod3;
    delta2.LastMonth = prod4;

    products.push(delta1);
    products.push(delta2);
    return products;
  }
  private toDelta(dto: DeltaDTO): DeltaProduct {
    const delta: DeltaProduct = new DeltaProduct();
    delta.Delta = dto.delta;
    delta.InventorySum = dto.inventory;
    delta.Name = dto.product;
    delta.Sales = dto.sales;
    delta.SupplySum = dto.supplies;
    delta.WastedSum = dto.wastes;
    return delta;
  }
}

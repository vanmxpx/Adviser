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
    const delta1 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=3&year=2016').toPromise();

    const delta2 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=4&year=2016').toPromise();
    const delta3 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=5&year=2016').toPromise();
    const delta4 = await this.http.get<string>('https://posanalitycs.azurewebsites.net/api/delta/byMonth?month=6&year=2016').toPromise();

    const products: DeltaProductSetup[] = [

    ];
    const delta: DeltaProductSetup = new DeltaProductSetup();

    delta.CurrentMonth = this.toDelta(JSON.parse(delta2));
    delta.LastMonth = this.toDelta(JSON.parse(delta1));

    products.push(delta);
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

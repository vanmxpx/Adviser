import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { DeltaProduct } from '../Models/deltaProduct';

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
  public GetDeltaProduct(): DeltaProduct[] {
    // return this.http.get<Post[]>('http://localhost:5000/api/posts/postsByPage?authorId='
    // + profileId.toString() + '&page=' + page.toString());

    const products: Array<DeltaProduct> = [

    ];
    products.push({
      Name: 'RedBull',
      SupplySum: 100,
      WastedSum: 8,
      InventorySum: 92,
      Sales: 100,
      Delta: 0,
      Leftovers: 3,
      LeftoversUnit: 'l'
    });
    products.push({
      Name: 'Vlod',
      SupplySum: 1,
      WastedSum: 1,
      Sales: 34,
      InventorySum: 0,
      Delta: 0,
      Leftovers: 0,
      LeftoversUnit: 's'
    });
    products.push({
      Name: 'Coffee',
      SupplySum: 100,
      WastedSum: 10,
      Sales: 89,
      InventorySum: 90,
      Delta: 0,
      Leftovers: 0,
      LeftoversUnit: 'l'
    });
    return products;
  }
}

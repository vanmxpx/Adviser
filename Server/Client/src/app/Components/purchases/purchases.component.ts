import { Component, OnInit } from '@angular/core';
import { DeltaProduct } from '../../Models/deltaProduct';
import { DeltaProductService } from '../../Services/delta-product.service';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.scss']
})
export class PurchasesComponent implements OnInit {
  CurrentMonth: DeltaProduct[] = [];
  LastMonth: DeltaProduct[] = [];

  DeltaProduct: [DeltaProduct, DeltaProduct];

  constructor(private deltaProductService: DeltaProductService) {

  }
  ngOnInit() {
this.GetCurrentMonthProduct();
  }
  GetCurrentMonthProduct() {
    const res = this.deltaProductService.GetDeltaProduct();
    res.forEach(item => {
      this.CurrentMonth.push(item);
    });

  }
  GetLastMonthProduct() {
    const res = this.deltaProductService.GetDeltaProduct();
    res.forEach(item => {
      this.LastMonth.push(item);
    });

  }


}

import { Component, OnInit } from '@angular/core';
import { DeltaProduct } from '../../Models/deltaProduct';
import { DeltaProductService } from '../../Services/delta-product.service';

@Component({
  selector: 'app-purchases',
  templateUrl: './purchases.component.html',
  styleUrls: ['./purchases.component.scss']
})

// tslint:disable-next-line:component-class-suffix
export class DeltaProductSetup {
  public CurrentMonth: DeltaProduct;
  public LastMonth: DeltaProduct;
}
export class PurchasesComponent implements OnInit {
  Setup: DeltaProductSetup[] = [];



  constructor(private deltaProductService: DeltaProductService) {

  }
  ngOnInit() {
    this.GetSetupProduct();
  }
  GetSetupProduct() {
    const res = this.deltaProductService.GetDeltaProduct();
    res.forEach(item => {
      this.Setup.push(item);
    });
  }
}





import { Component, OnInit, ViewChild } from '@angular/core';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import { Ingredient } from 'src/app/Models/ingredient';


@Component({
  selector: 'app-foodcost',
  templateUrl: './foodcost.component.html',
  styleUrls: ['./foodcost.component.scss']
})

export class FoodcostComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'cost', 'supplier', 'left_overs', 'chart'];
  dataSource = ELEMENT_DATA;
  constructor() { }
  ngOnInit() {
  }
}


const ELEMENT_DATA: Ingredient[] = [
  {position: 1, name: 'Hydrogen', cost: 1.0079, supplier: 'H', left_overs: 1},
  {position: 2, name: 'Helium', cost: 4.0026, supplier: 'He', left_overs: 10 },
  {position: 3, name: 'Lithium', cost: 6.941, supplier: 'Li', left_overs: 1},
  {position: 4, name: 'Beryllium', cost: 9.0122, supplier: 'Be', left_overs: 1},
];

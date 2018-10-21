import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Ingredient } from 'src/app/Models/ingredient';


@Component({
  selector: 'app-foodcost',
  templateUrl: './foodcost.component.html',
  styleUrls: ['./foodcost.component.scss']
})

export class FoodcostComponent implements OnInit {
  displayedColumns: string[] = ['position', 'name', 'cost', 'supplier', 'left_overs'];
  dataSource = ELEMENT_DATA;
  constructor() { }
  ngOnInit() {  
  }
}


const ELEMENT_DATA: Ingredient[] = [
  {position: 1, name: 'Соль', cost: 400, supplier: 'Ваня Иванов', left_overs: 3},
  {position: 2, name: 'Текила', cost: 5000, supplier: 'Jonh Doe', left_overs: 5 },
  {position: 3, name: 'Лайм', cost: 2000, supplier: 'Fuck Fuck', left_overs: 10},
];

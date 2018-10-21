import { Component, OnInit, AfterViewInit , ElementRef, ViewChild } from '@angular/core';
import { Chart } from 'chart.js';


@Component({
  selector: 'app-dynamic-chart',
  templateUrl: './dynamic-chart.component.html',
  styleUrls: ['./dynamic-chart.component.scss']
})
export class DynamicChartComponent implements OnInit, AfterViewInit {
  @ViewChild('canvas') canvas: ElementRef;
  panelOpenState = false;
  chart = [];
    labels: any = ['aaa'];

    data = [];

    constructor() { }

    ngOnInit() {
this.data.push(12);
    }
    ngAfterViewInit() {
        this.chart = new Chart(this.canvas.nativeElement.getContext('2d'), {
            type: 'bar',
            labels: this.labels,
            data: {
                labels: this.labels,
                data: this.data
            },
            options: {
                responsive: true
            }
        });

    }

}

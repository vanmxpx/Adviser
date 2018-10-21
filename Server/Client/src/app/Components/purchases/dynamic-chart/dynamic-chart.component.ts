import { Component, OnInit, AfterViewInit , ElementRef, ViewChild, ChangeDetectorRef } from '@angular/core';
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
    labels: any = ['Jun', 'July', 'Aug', 'Sep'];

    data = [0, 44, 81, -32];

    constructor(private ref: ChangeDetectorRef) { }

    ngOnInit() {
this.data.push(12);
    }
    ngAfterViewInit() {
        this.chart = new Chart(this.canvas.nativeElement.getContext('2d'), {
            type: 'line',
            labels: this.labels,
            data: {
                labels: this.labels,
                datasets: [
                    {
                      data: this.data,
                      borderColor: "#3cba9f",
                      fill: false
                    }
                ]
            },
            options: {
                responsive: true,
                
                    legend: {
                      display: false
                    },
            }
        });
        this.ref.detectChanges();
    }

}

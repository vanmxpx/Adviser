import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';


@Component({
  selector: 'app-dynamic-chart',
  templateUrl: './dynamic-chart.component.html',
  styleUrls: ['./dynamic-chart.component.scss']
})
export class DynamicChartComponent implements OnInit {
  chart: any;
  ngOnInit() {
    this.chart = new Chart(document.getElementById('canvas'), {
      type: 'line',
      data: {
        labels: ['one', 'two', 'hell', 'sss'],
        datasets: [
          {
            data: [1, 2, 3, 4],
            borderColor: '#3cba9f',
            fill: true
          },
          {
            data: [4, 3, 2, 1],
            borderColor: '#ffcc00',
            fill: false
          },
        ]
      },
      options: {
        legend: {
          display: false
        },
        scales: {
          xAxes: [{
            display: true
          }],
          yAxes: [{
            display: true
          }]
        }
      }
    });
  }


}

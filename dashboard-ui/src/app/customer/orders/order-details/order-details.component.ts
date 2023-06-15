import {Component, OnInit, ViewChild} from '@angular/core';
import {OrderDetail} from "../../../shared/models/order-detail";
import {AppService} from "../../../app.service";
import {ActivatedRoute, Router} from "@angular/router";
import {
  ApexAxisChartSeries,
  ApexChart,
  ApexDataLabels,
  ApexFill,
  ApexPlotOptions,
  ApexTitleSubtitle,
  ApexXAxis,
  ApexYAxis,
  ChartComponent,
} from "ng-apexcharts";


export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})

export class OrderDetailsComponent implements OnInit {
  orderDetails: OrderDetail[];
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor(private service: AppService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
        const url = "/customer/" + params['id'] + '/orders/' + params['orderId'];
        this.service
          .get(url)
          .subscribe((data: any) => {
            this.orderDetails = data;
            if (this.orderDetails.length > 0) {
              this.defineChart();
            }
          })
        ;
      }
    )

  }

  defineChart() {
    this.chartOptions = {
      series: [
        {
          name: "Total sales",
          data: this.orderDetails.map((orderDetail) => {
            return +(orderDetail.salesTotal).toPrecision(2);
          })
        },
      ],
      chart: {
        height: 360,
        width: 720,
        type: "bar",
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: 'top'
          }
        }
      },
      dataLabels: {
        enabled: true,
        formatter: function (val) {
          return "$" + val;
        },
        offsetY: -20,
        style: {
          fontSize: "12px",
          colors: ["#304758"],
        },
      },
      xaxis: {
        categories: this.orderDetails.map((orderDetail) => orderDetail.productName),
        // position: "bottom",
        labels: {
          show: false,
        },
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        crosshairs: {
          fill: {
            type: "gradient",
            gradient: {
              colorFrom: "#D8E3F0",
              colorTo: "#BED1E6",
              stops: [0, 100],
              opacityFrom: 0.4,
              opacityTo: 0.5,
            },
          },
        },
      },
      fill: {
        type: "gradient",
        gradient: {
          shade: "light",
          type: "horizontal",
          shadeIntensity: 0.25,
          gradientToColors: undefined,
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [50, 0, 100, 100],
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        labels: {
          show: false,
          formatter: function (val) {
            return "$" + val;
          },
          align: "center"
        },
      },
      title: {
        text: "Total Sales by Product",
        floating: false,
        offsetY: 340,
        align: "center",
        style: {
          color: "#444",
        },
      },
    }
  }

}

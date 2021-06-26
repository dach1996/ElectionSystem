import { HttpStatusCode } from '@angular/common/http';
import {
  AfterViewInit,
  Component,
  OnInit,
} from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';
import { PageBase } from 'src/app/models/pageBase';
import {
  EventBaseResponse,
  EventGetResultResponse,
  OrderBy,
  TypeFilterEvent,
} from 'src/app/serviceApi/models';
import { EventService } from 'src/app/serviceApi/services';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.css', '../../../app.component.css'],
})
export class ResultsComponent implements OnInit, AfterViewInit, PageBase {
  constructor(private eventService: EventService) {}
  loading: boolean = false;
  titlePage: string = 'RESULTADOS DE EVENTO';
  errorMessage: string = '';
  event?: EventBaseResponse;
  listEvents?: Array<EventBaseResponse>;
  results?: EventGetResultResponse;

  private eventRequest = {
    Offset: 0,
    OrderBy: OrderBy.Asc,
    Limit: 100,
    TypeFilter: TypeFilterEvent.Relation,
  };
  ngAfterViewInit(): void {}

  ngOnInit() {
    this.loadEvents();
    Math.round(5);

  }
  public barChartOptions?: ChartOptions;
  public barChartLabels: Label[] = ['', ''];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];
  public barChartData: ChartDataSets[] = [];

  loadBarChart(): void {
    let namesCandidates = this.results?.candidates?.map(
      (c) => c.user?.firstName + ' ' + c.user?.firstLastName
    );
    let votesCandidates = this.results?.candidates?.map(
      (c) => c.numberVotes
    ) as number[];

    this.barChartLabels = namesCandidates!;
    this.barChartData = [
      {
        label: 'Canidatas',
        data: votesCandidates,
        lineTension: 0.4,
        borderWidth: 0,
        backgroundColor: '#fff',
        pointRadius: 0,
        maxBarThickness: 6,
      },
    ];
    this.barChartOptions = {
      responsive: true,
      maintainAspectRatio: false,
      legend: { display: false },
      tooltips: {
        enabled: true,
        mode: 'index',
        intersect: false,
      },
      scales: {
        yAxes: [
          {
            gridLines: {
              display: false,
            },
            ticks: {
              suggestedMin: 0,
              suggestedMax: Math.max.apply(null, votesCandidates),
              beginAtZero: true,
              padding: 0,
              fontSize: 14,
              lineHeight: 3,
              fontColor: '#fff',
              fontStyle: 'normal',
              fontFamily: 'Open Sans',
            },
          },
        ],
        xAxes: [
          {
            gridLines: {
              display: false,
            },
            ticks: {
              display: false,
              padding: 20,
            },
          },
        ],
      },
    };
  }
  loadEvents(): void {
    this.loading = true;
    this.eventService.apiEventsGet$Json$Response(this.eventRequest).subscribe(
      (res) => {
        if (res.status == HttpStatusCode.Ok) {
          this.listEvents = res.body.content?.listEvents!;
          if (this.listEvents === null)
            Swal.fire({
              icon: 'error',
              text:
                'Error: ' + 'No se encontraron eventos relacionados con usted.',
              confirmButtonColor: '#d33',
            });
        }
      },
      (err) => {
        if (err.error.code == 150)
          this.errorMessage = 'Es necesario llenar todos los campos';
        else this.errorMessage = err.error.message;
        Swal.fire({
          icon: 'error',
          text: 'Error: ' + this.errorMessage,
          confirmButtonColor: '#d33',
        });
      },
      () => (this.loading = false)
    );
  }
  loadResults(): void {
    this.loading = true;
    this.eventService
      .apiEventsIdEventResultsGet$Json$Response({ idEvent: this.event?.id! })
      .subscribe(
        (res) => {
          if (res.status == HttpStatusCode.Ok) {
            this.results = res.body.content!;
            this.loadBarChart();
            if (this.listEvents === null)
              Swal.fire({
                icon: 'error',
                text:
                  'Error: ' +
                  'No se encontraron eventos relacionados con usted.',
                confirmButtonColor: '#d33',
              });
          }
        },
        (err) => {
          if (err.error.code == 150)
            this.errorMessage = 'Es necesario llenar todos los campos';
          else this.errorMessage = err.error.message;
          Swal.fire({
            icon: 'error',
            text: 'Error: ' + this.errorMessage,
            confirmButtonColor: '#d33',
          });
        },
        () => {
          this.loading = false;
          this.loadBarChart();
        }
      );
  }
  round5(number:number):number{
    return Math.ceil(number/5)*5
  }
}

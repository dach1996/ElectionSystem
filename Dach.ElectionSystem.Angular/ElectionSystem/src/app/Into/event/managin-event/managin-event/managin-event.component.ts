import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { EventBaseResponse } from 'src/app/serviceApi/models';

@Component({
  selector: 'app-managin-event',
  templateUrl: './managin-event.component.html',
  styleUrls: ['./managin-event.component.css'],
})
export class EventManagintComponent implements OnInit, PageBase {
  public event?: EventBaseResponse;
  public idEvent?: number;
  constructor(
    private activeRouter: ActivatedRoute,
  ) {}
  errorMessage: string = '';
  loading: boolean = false;
  titlePage: string = 'ADMINISTRAR EVENTO';

  ngOnInit(): void {
    this.activeRouter.paramMap.subscribe((paramsMap: ParamMap) => {
      this.idEvent = Number(paramsMap.get('idEvent')!);
    });
  }
}

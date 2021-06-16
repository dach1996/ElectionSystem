import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';

@Component({
  selector: 'app-records-managin',
  templateUrl: './records-managin.component.html',
  styleUrls: ['./records-managin.component.css', '../../../app.component.css'],
})
export class RecordsManaginComponent implements OnInit, PageBase {

  constructor(
  ) {}
  errorMessage: string = '';
  loading: boolean = false;
  titlePage: string = 'MIS REGISTROS EN EVENTOS';
  ngOnInit(): void {
  }
}

import { Component, OnInit } from '@angular/core';
import { PageBase } from 'src/app/models/pageBase';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css','../../../app.component.css']
})
export class CandidateComponent implements OnInit, PageBase {

  loading: boolean=false;
  titlePage: string='VER CANDIDATO';
  errorMessage: string='';
  constructor() { }

  ngOnInit(): void {
  }

}

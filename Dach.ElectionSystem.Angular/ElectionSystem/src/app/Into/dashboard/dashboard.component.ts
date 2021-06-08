import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScriptService } from 'src/app/service/scripService';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
  constructor(private scriptService: ScriptService, private route: Router) {
    console.log('Loading External Scripts');
    this.scriptService.load('FontAwesome', 'ButtonsJs');
  }

  ngOnInit(): void {}
}

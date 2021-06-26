import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageBase } from 'src/app/models/pageBase';
import { ScriptService } from 'src/app/service/scripService.service';
import { StorageCache } from 'src/app/service/storageCache.service';
import { UserBaseResponse } from 'src/app/serviceApi/models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit  {
  public titlePage: string = '';
  public userCurrent: UserBaseResponse | undefined;
  constructor(
    private scriptService: ScriptService,
    private storage: StorageCache,
    private route: Router
  ) {
    this.userCurrent = storage.UserCurrent;
  }
  messageTitleEvent($event: PageBase ) {
    this.titlePage = $event.titlePage;
  }
  ngOnInit(): void {}
}

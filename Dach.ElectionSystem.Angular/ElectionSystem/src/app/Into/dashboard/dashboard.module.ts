import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { EventComponent } from '../event/event/event.component';
import { DashboardComponent } from './dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { UtilsModule } from 'src/app/utils/utils.module';

@NgModule({
  declarations: [
    EventComponent,
    DashboardComponent,
  
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    HttpClientModule,
    UtilsModule
  ]
})
export class DashboardModule { }

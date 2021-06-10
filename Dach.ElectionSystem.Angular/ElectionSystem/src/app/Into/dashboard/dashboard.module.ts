import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { EventComponent } from '../event/event/event.component';
import { DashboardComponent } from './dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { UtilsModule } from 'src/app/utils/utils.module';
import { EventCreateComponent } from '../event/create-event/create-event.component';
import { BrowserModule } from '@angular/platform-browser';
import { EventEditComponent } from '../event/event-edit/event-edit.component';
import { StorageCache } from '../../service/storageCache.service'

@NgModule({
  declarations: [
    EventComponent,
    EventCreateComponent,
    EventEditComponent,
    DashboardComponent,
    
  ],
  imports: [
    BrowserModule,
    CommonModule,
    DashboardRoutingModule,
    HttpClientModule,
    FormsModule,
    UtilsModule
  ]
})
export class DashboardModule { }

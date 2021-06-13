import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { EventComponent } from '../event/event/event.component';
import { DashboardComponent } from './dashboard.component';
import { HttpClientModule } from '@angular/common/http';
import { UtilsModule } from 'src/app/utils/utils.module';
import { EventCreateComponent } from '../event/create-event/create-event.component';
import { BrowserModule } from '@angular/platform-browser';
import { EventEditComponent } from '../event/event-edit/event-edit.component';
import { EditUserComponent } from '../user/edit-user/edit-user.component';
import { EventModalSelectComponent } from '../event/event-modal-select/event-modal-select.component';
import { EventManagintComponent } from '../event/managin-event/managin-event/managin-event.component';
import { EventDetailsComponent } from '../event/managin-event/event-details/event-details.component';
import { ListUserComponent } from '../user/list-user/list-user.component';

@NgModule({
  declarations: [
    EventComponent,
    EventCreateComponent,
    EventEditComponent,
    DashboardComponent,
    EditUserComponent,
    EventModalSelectComponent,
    EventManagintComponent,
    EventDetailsComponent,
    ListUserComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    DashboardRoutingModule,
    HttpClientModule,
    FormsModule,
    UtilsModule,
  ],
  providers:[DatePipe]
})
export class DashboardModule { }

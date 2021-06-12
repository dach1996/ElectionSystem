import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventCreateComponent } from '../event/create-event/create-event.component';
import { EventEditComponent } from '../event/event-edit/event-edit.component';
import { EventComponent } from '../event/event/event.component';
import { EditUserComponent } from '../user/edit-user/edit-user.component';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      {  path: '',   component: EventComponent, },
      {  path: 'event',    component: EventComponent, },
      {  path: 'event/create',    component: EventCreateComponent, },
      {  path: 'event/edit/:idEvent',    component: EventEditComponent, },
      {  path: 'user/edit/:idUser',    component: EditUserComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}

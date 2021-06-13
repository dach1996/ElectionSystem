import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventCreateComponent } from '../event/create-event/create-event.component';
import { EventEditComponent } from '../event/event-edit/event-edit.component';
import { EventComponent } from '../event/event/event.component';
import { EventCandidatesComponent } from '../event/managin-event/event-candidates/event-candidates.component';
import { EventDetailsComponent } from '../event/managin-event/event-details/event-details.component';
import { EventParticipantsComponent } from '../event/managin-event/event-participants/event-participants.component';
import { EventManagintComponent } from '../event/managin-event/managin-event/managin-event.component';
import { EditUserComponent } from '../user/edit-user/edit-user.component';
import { ListUserComponent } from '../user/list-user/list-user.component';
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
      {  path: 'event/administrator/:idEvent',    component: EventManagintComponent, 
      children:[
        {path:'', component:EventDetailsComponent},
        {path:'detail', component:EventDetailsComponent},
        {path:'candidate', component:EventCandidatesComponent},
        {path:'participant', component:EventParticipantsComponent}
      ]},
      {  path: 'list',    component: ListUserComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}

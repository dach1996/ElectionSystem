import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditCandidateComponent } from '../candidate/edit-candidate/edit-candidate.component';
import { EventCreateComponent } from '../event/create-event/create-event.component';
import { EventEditComponent } from '../event/event-edit/event-edit.component';
import { EventComponent } from '../event/event/event.component';
import { EventCandidatesComponent } from '../event/managin-event/event-candidates/event-candidates.component';
import { EventDetailsComponent } from '../event/managin-event/event-details/event-details.component';
import { EventParticipantsComponent } from '../event/managin-event/event-participants/event-participants.component';
import { EventManagintComponent } from '../event/managin-event/managin-event/managin-event.component';
import { RecordsAdministratorComponent } from '../myRecords/records-administrator/records-administrator.component';
import { RecordsCandidateComponent } from '../myRecords/records-candidate/records-candidate.component';
import { RecordsManaginComponent } from '../myRecords/records-managin/records-managin.component';
import { RecordsParticipantComponent } from '../myRecords/records-participant/records-participant.component';
import { ResultsComponent } from '../results/results/results.component';
import { EditUserComponent } from '../user/edit-user/edit-user.component';
import { ListUserComponent } from '../user/list-user/list-user.component';
import { VoteComponent } from '../vote/vote/vote.component';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent,
    children: [
      { path: '', component: EventComponent },
      { path: 'event', component: EventComponent },
      { path: 'event/create', component: EventCreateComponent },
      { path: 'event/edit/:idEvent', component: EventEditComponent },
      { path: 'user/edit/:idUser', component: EditUserComponent },
      {
        path: 'event/administrator/:idEvent',
        component: EventManagintComponent,
        children: [
          { path: '', component: EventDetailsComponent },
          { path: 'detail', component: EventDetailsComponent },
          { path: 'candidate', component: EventCandidatesComponent },
          { path: 'participant', component: EventParticipantsComponent },
        ],
      },
      {
        path: 'myRecords',
        component: RecordsManaginComponent,
        children: [
          { path: '', component: RecordsCandidateComponent },
          { path: 'candidate', component: RecordsCandidateComponent },
          { path: 'participant', component: RecordsParticipantComponent },
          { path: 'administrator', component: RecordsAdministratorComponent },
        ],
      },
      {
        path: 'event/:idEvent/candidate/:idUser',
        component: EditCandidateComponent,
      },
      { path: 'list', component: ListUserComponent },
      { path: 'results', component: ResultsComponent },
      { path: 'vote', component: VoteComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}

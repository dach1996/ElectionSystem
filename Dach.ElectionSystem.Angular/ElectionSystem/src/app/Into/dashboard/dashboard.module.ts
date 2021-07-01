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
import { EventCandidatesComponent } from '../event/managin-event/event-candidates/event-candidates.component';
import { EventParticipantsComponent } from '../event/managin-event/event-participants/event-participants.component';
import { EventAdministratorModalComponent } from '../event/managin-event/event-administrator-modal/event-administrator-modal.component';
import { RecordsManaginComponent } from '../myRecords/records-managin/records-managin.component';
import { RecordsCandidateComponent } from '../myRecords/records-candidate/records-candidate.component';
import { RecordsParticipantComponent } from '../myRecords/records-participant/records-participant.component';
import { RecordsAdministratorComponent } from '../myRecords/records-administrator/records-administrator.component';
import { EditCandidateComponent } from '../candidate/edit-candidate/edit-candidate.component';
import { CandidateComponent } from '../candidate/candidate/candidate.component';
import { ResultsComponent } from '../results/results/results.component';
import { VoteComponent } from '../vote/vote/vote.component';
import { ModalDetailCandidateComponent } from '../vote/modal-detail-candidate/modal-detail-candidate.component';
import { ChartsModule } from 'ng2-charts';
import { YouTubePlayerModule } from '@angular/youtube-player';

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
    EventCandidatesComponent,
    EventParticipantsComponent,
    ListUserComponent,
    EventAdministratorModalComponent,
    EditCandidateComponent,
    CandidateComponent,
    RecordsManaginComponent,
    RecordsCandidateComponent,
    RecordsParticipantComponent,
    RecordsAdministratorComponent,
    ResultsComponent,
    VoteComponent,
    ModalDetailCandidateComponent

  ],
  imports: [
    BrowserModule,
    CommonModule,
    DashboardRoutingModule,
    HttpClientModule,
    FormsModule,
    UtilsModule,
    ChartsModule,
    YouTubePlayerModule,

  ],
  providers:[DatePipe]
})
export class DashboardModule { }

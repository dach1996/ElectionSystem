import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForggotePasswordComponent } from './forggote-password/forggote-password.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { DashboardModule } from './Into/dashboard/dashboard.module';
import { UtilsModule } from './utils/utils.module';
import { EditCandidateComponent } from './Into/candidate/edit-candidate/edit-candidate.component';
import { CreateCandidateComponent } from './Into/candidate/create-candidate/create-candidate.component';
import { DesactiveCandidateComponent } from './Into/candidate/desactive-candidate/desactive-candidate.component';
import { CandidateComponent } from './Into/candidate/candidate/candidate.component';
import { UpdateCandidateComponent } from './Into/candidate/update-candidate/update-candidate.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
// import { ListUserComponent } from './Into/user/list-user/list-user.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForggotePasswordComponent,
    EditCandidateComponent,
    CreateCandidateComponent,
    DesactiveCandidateComponent,
    CandidateComponent,
    UpdateCandidateComponent,
    //ListUserComponent
    
  ],
  imports: [
    BrowserModule,
    SweetAlert2Module,
    FormsModule,
    DashboardModule,
    UtilsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  exports:[],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

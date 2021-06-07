import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForggotePasswordComponent } from './forggote-password/forggote-password.component';
import { DashboardComponent } from './Into/dashboard/dashboard.component';
import { FormsModule } from '@angular/forms';
import { LoadingComponent } from './utils/loading/loading.component';
import { HttpClientModule } from '@angular/common/http';
import { AlertComponent } from './utils/alert/alert.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForggotePasswordComponent,
    DashboardComponent,
    LoadingComponent,
    AlertComponent  ],
  imports: [
    BrowserModule,
    SweetAlert2Module,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

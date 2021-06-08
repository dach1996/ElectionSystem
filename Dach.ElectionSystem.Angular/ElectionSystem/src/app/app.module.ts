import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ForggotePasswordComponent } from './forggote-password/forggote-password.component';
import { FormsModule } from '@angular/forms';
import { LoadingComponent } from './utils/loading/loading.component';
import { HttpClientModule } from '@angular/common/http';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { DashboardModule } from './Into/dashboard/dashboard.module';
import { UtilsModule } from './utils/utils.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ForggotePasswordComponent
  ],
  imports: [
    BrowserModule,
    SweetAlert2Module,
    FormsModule,
    DashboardModule,
    UtilsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  exports:[LoadingComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

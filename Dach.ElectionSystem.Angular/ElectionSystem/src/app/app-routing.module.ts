import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForggotePasswordComponent } from './forggote-password/forggote-password.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'forggotepassword', component: ForggotePasswordComponent, pathMatch: 'full' },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

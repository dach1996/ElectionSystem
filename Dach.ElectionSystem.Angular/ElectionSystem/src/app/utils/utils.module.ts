import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UtilsRoutingModule } from './utils-routing.module';
import { LoadingComponent } from './loading/loading.component';


@NgModule({
  declarations: [
    LoadingComponent
  ],
  imports: [
    CommonModule,
    UtilsRoutingModule,
  ],
  exports:[LoadingComponent]
})
export class UtilsModule { }

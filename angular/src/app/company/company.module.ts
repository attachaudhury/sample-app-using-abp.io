import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CompanyRoutingModule } from './company-routing.module';
import { CompanyComponent } from './company.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [CompanyComponent],
  imports: [
    CompanyRoutingModule,
    SharedModule,
    NgbDatepickerModule, // add this line
  ]
})
export class CompanyModule { }

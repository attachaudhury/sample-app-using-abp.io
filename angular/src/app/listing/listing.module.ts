import { NgModule } from '@angular/core';
import { ListingRoutingModule } from './listing-routing.module';
import { ListingComponent } from './listing.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [ListingComponent],
  imports: [SharedModule, ListingRoutingModule, NgbDatepickerModule],
})
export class ListingModule { }

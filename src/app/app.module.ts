import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import * as _ from 'lodash';

// Services
import {ApartmentService } from './services/apartment.service';
// Components
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ListApartmentsComponent } from './list-apartments/list-apartments.component';
import { AddApartmentComponent } from './add-apartment/add-apartment.component';
import { ApartmentDetailComponent } from './apartment-detail/apartment-detail.component';

// Dialog components
import { DialogAddApartmentComponent } from './dialogs/dialog-add-apartment/dialog-add-apartment.component';
import { DialogEditApartmentComponent } from './dialogs/dialog-edit-apartment/dialog-edit-apartment.component';
import { DialogDeleteApartmentComponent } from './dialogs/dialog-delete-apartment/dialog-delete-apartment.component';
import { DialogBuyApartmentComponent } from './dialogs/dialog-buy-apartment/dialog-buy-apartment.component';

// Filters pipes
import { FilterRoomsPipe } from './pipes/filter-rooms.pipe';
import { FilterAddressPipe } from './pipes/filter-address.pipe';
import { FilterPriceFromPipe } from './pipes/filter-price-from.pipe';
import { FilterPriceToPipe } from './pipes/filter-price-to.pipe';

// Routing
import { AppRoutingModule } from './app-routing.module';

//Angular Material Components
import {MatCheckboxModule} from '@angular/material';
import {MatButtonModule} from '@angular/material';
import {MatInputModule} from '@angular/material/input';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatRadioModule} from '@angular/material/radio';
import {MatSelectModule} from '@angular/material/select';
import {MatSliderModule} from '@angular/material/slider';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatMenuModule} from '@angular/material/menu';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatListModule} from '@angular/material/list';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import {MatStepperModule} from '@angular/material/stepper';
import {MatTabsModule} from '@angular/material/tabs';
import {MatExpansionModule} from '@angular/material/expansion';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatChipsModule} from '@angular/material/chips';
import {MatIconModule} from '@angular/material/icon';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatTableModule} from '@angular/material/table';
import {MatSortModule} from '@angular/material/sort';
import {MatPaginatorModule} from '@angular/material/paginator';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'apartment/:id', component: ApartmentDetailComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListApartmentsComponent,
    DialogAddApartmentComponent,
    DialogEditApartmentComponent,
    DialogDeleteApartmentComponent,
    AddApartmentComponent,
    ApartmentDetailComponent,
    DialogBuyApartmentComponent,
    FilterRoomsPipe,
    FilterAddressPipe,
    FilterPriceFromPipe,
    FilterPriceToPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    AppRoutingModule,
    BrowserAnimationsModule,
    MatCheckboxModule,
    MatCheckboxModule,
    MatButtonModule,
    MatInputModule,
    MatAutocompleteModule,
    MatDatepickerModule,
    MatFormFieldModule,
    MatRadioModule,
    MatSelectModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatMenuModule,
    MatSidenavModule,
    MatToolbarModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatStepperModule,
    MatTabsModule,
    MatExpansionModule,
    MatButtonToggleModule,
    MatChipsModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatDialogModule,
    MatTooltipModule,
    MatSnackBarModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule
  ],
  entryComponents : [ 
    DialogAddApartmentComponent, 
    DialogEditApartmentComponent,
    DialogDeleteApartmentComponent,
    DialogBuyApartmentComponent
  ],
  providers: [
    ApartmentService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }





import { Component, OnInit } from '@angular/core';
import { ApartmentService } from '../services/apartment.service';
import {Router } from "@angular/router";
import * as _ from 'lodash';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public apartmentData: Array<any>;
  public currentApartment: any;
  public closed = true;

  constructor (private apartmentService: ApartmentService,
    private router: Router) {
    apartmentService.get().subscribe((data: any) => this.apartmentData = data);
    this.currentApartment = this.setInitialValuesForApartmentData();
  }

  ngOnInit() {
  }

  private setInitialValuesForApartmentData () {
    return {
      id: undefined,
      title: '',
      address: '',
      nbOfRooms: 0
    }
  }

  public createOrUpdateApartment = function(apartment: any) {
    // if apartment is present in apartmentData, we can assume this is an update
    // otherwise it is adding a new element
    let apartmentWithId;
    apartmentWithId = _.find(this.apartmentData, (el => el.id === apartment.id));

    if (apartmentWithId) {
      const updateIndex = _.findIndex(this.apartmentData, {id: apartmentWithId.id});
      this.apartmentService.update(apartment).subscribe(
        apartmentRecord =>  this.apartmentData.splice(updateIndex, 1, apartment)
      );
    } else {
      this.apartmentService.add(apartment).subscribe(
        apartmentRecord => this.apartmentData.push(apartment)
      );
    }
    this.currentApartment = this.setInitialValuesForApartmentData();
    window.location.reload();
  };
 
}

import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ApartmentService } from '../services/apartment.service';

@Component({
  selector: 'app-apartment-detail',
  templateUrl: './apartment-detail.component.html',
  styleUrls: ['./apartment-detail.component.css']
})
export class ApartmentDetailComponent implements OnInit {
  @Input() apartment: any;

  constructor(private location: Location,
    private route: ActivatedRoute,
    private apartmentService: ApartmentService) { }

  ngOnInit() {
    this.getApartment();
  }

  getApartment(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.apartmentService.getById(id)
      .subscribe(apartment => this.apartment = apartment);
  }

  goBack(): void {
    this.location.back();
  }

}

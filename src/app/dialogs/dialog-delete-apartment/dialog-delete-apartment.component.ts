import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatTreeFlatDataSource } from '@angular/material';
import { ApartmentService } from 'src/app/services/apartment.service';
import * as _ from 'lodash';

@Component({
  selector: 'app-dialog-delete-apartment',
  templateUrl: './dialog-delete-apartment.component.html',
  styleUrls: ['./dialog-delete-apartment.component.css']
})
export class DialogDeleteApartmentComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogDeleteApartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public apartmentService: ApartmentService) { }

  public onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    this.apartmentService.remove(this.data).subscribe(
      result =>  window.location.reload()
    );
    window.alert("Apartment deleted successfully");
  }

  ngOnInit() { }

}

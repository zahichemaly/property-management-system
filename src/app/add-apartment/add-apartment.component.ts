import { Component, EventEmitter, Input, Output, OnInit, Inject } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DialogAddApartmentComponent } from '../dialogs/dialog-add-apartment/dialog-add-apartment.component';

@Component({
  selector: 'app-add-apartment',
  templateUrl: './add-apartment.component.html',
  styleUrls: ['./add-apartment.component.css']
})
export class AddApartmentComponent implements OnInit {

  @Output() apartmentCreated = new EventEmitter<any>();
  public title: string;
  public address: string;
  public nbOfRooms: number;

  constructor(public dialog: MatDialog) {
    this.clearApartmentInfo();
  }

  ngOnInit() { }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(DialogAddApartmentComponent, {
      data:
      {
        title: this.title,
        address: this.address,
        nbOfRooms: this.nbOfRooms
      }
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      this.apartmentCreated.emit(result);
      this.clearApartmentInfo();
    });
  }

  private clearApartmentInfo = function () {
    // Create an empty apartment object
    this.apartmentInfo = {
      id: undefined,
      title: '',
      address: '',
      nbOfRooms: 0
    };
  };

  public addOrUpdateApartmentRecord = function (event) {
    this.apartmentCreated.emit(this.apartmentInfo);
    this.clearApartmentInfo();
  };

}
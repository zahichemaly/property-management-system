import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

export interface DialogData {
  title: string;
  address: string;
  nbOfRooms: number;
  price: number;
}

@Component({
  selector: 'app-dialog-edit-apartment',
  templateUrl: './dialog-edit-apartment.component.html',
  styleUrls: ['./dialog-edit-apartment.component.css']
})
export class DialogEditApartmentComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogEditApartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {
    }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(){}

}

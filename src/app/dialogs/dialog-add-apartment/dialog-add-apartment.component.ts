import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

export interface DialogData {
  title: string;
  address: string;
  nbOfRooms: number;
}

@Component({
  selector: 'app-dialog-add-apartment',
  templateUrl: './dialog-add-apartment.component.html',
  styleUrls: ['./dialog-add-apartment.component.css']
})
export class DialogAddApartmentComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogAddApartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) {}

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit(){}

}

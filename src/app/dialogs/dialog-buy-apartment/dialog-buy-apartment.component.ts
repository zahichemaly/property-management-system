import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { BuyerService } from 'src/app/services/buyer.service';
import { Config } from 'protractor';

export interface DialogData {
  id: undefined;
  title: string;
  address: string;
  nbOfRooms: number;
}

@Component({
  selector: 'app-dialog-buy-apartment',
  templateUrl: './dialog-buy-apartment.component.html',
  styleUrls: ['./dialog-buy-apartment.component.css']
})
export class DialogBuyApartmentComponent implements OnInit {

  public buyersData: Array<any>;
  public buyerSelected: any;
  public apartmentSelected: any;

  constructor(
    public dialogRef: MatDialogRef<DialogBuyApartmentComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData,
    private buyerService: BuyerService ) { }

  ngOnInit() {
    this.getBuyers();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSubmit(): void {
    const buyerId = this.buyerSelected.id;
    const apartmentId = this.data.id;
    this.buyerService.buy(buyerId, apartmentId).subscribe( result => {
      window.alert("Purchase successful");
      window.location.reload();
    });
  }

  getBuyers(): void {
    this.buyerService.get().subscribe((data: any) => this.buyersData = data);
  }

}

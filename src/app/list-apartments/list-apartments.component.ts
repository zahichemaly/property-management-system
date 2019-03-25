import { Component, EventEmitter, Input, Output, OnInit, Inject, ViewChild } from '@angular/core';
import { MatDialog, PageEvent, MatTableDataSource, MatPaginator, MatGridTileHeaderCssMatStyler, MatSort, MatTab } from '@angular/material';
import { Router } from '@angular/router';
import { DialogEditApartmentComponent } from '../dialogs/dialog-edit-apartment/dialog-edit-apartment.component';
import { DialogDeleteApartmentComponent } from '../dialogs/dialog-delete-apartment/dialog-delete-apartment.component';
import { DialogBuyApartmentComponent } from '../dialogs/dialog-buy-apartment/dialog-buy-apartment.component';
import { Apartment } from '../models/apartment';
import { ApartmentService } from '../services/apartment.service';

@Component({
  selector: 'app-list-apartments',
  templateUrl: './list-apartments.component.html',
  styleUrls: ['./list-apartments.component.css']
})
export class ListApartmentsComponent implements OnInit {

  @Output() recordDeleted = new EventEmitter<any>();
  @Output() apartmentUpdated = new EventEmitter<any>();

  @Input() apartmentData: Array<any>;
  @Input() apartmentInfo: any;

  apartmentSelected: any;

  public columnsToDisplay = ['id', 'title', 'address', 'nbOfRooms', 'price', 'action'];
  public title: string;
  public address: string;
  public nbOfRooms: number;
  public price: number;
  public confirm: boolean;
  // search fields
  public searchAddress: string;
  public searchNbOfRooms: number;
  public searchPriceFrom: number;
  public searchPriceTo: number;
  // Paginator

  public pageSizeOptions: number[] = [5, 10, 25, 50, 100];
  public pageSize = 5;
  public currentPage = 0;
  public dataSource: MatTableDataSource<any>;
  public array: any;
  public totalSize = 0;
  public pageEvent: PageEvent;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(public dialog: MatDialog,
    private router: Router,
    private apartmentService: ApartmentService) {
    this.getArray();
  }

  ngOnInit() { }

  private getArray() {
    this.apartmentService.get()
      .subscribe((response: any) => {
        this.dataSource = new MatTableDataSource<any>(response);
        this.array = response;
        this.dataSource.paginator = this.paginator;
        this.totalSize = this.array.length;
      });
  }

  openEditDialog(record) {
    const dialogRef = this.dialog.open(DialogEditApartmentComponent, {
      data: record
    });
    dialogRef.disableClose = true;
    dialogRef.afterClosed().subscribe(result => {
      this.apartmentUpdated.emit(result);
    });
  }

  openDeleteDialog(record) {
    const dialogRef = this.dialog.open(DialogDeleteApartmentComponent, {
      data: record
    });
    dialogRef.disableClose = true;
  }

  openBuyDialog(record) {
    this.apartmentInfo = Object.assign({}, record);
    const dialogRef = this.dialog.open(DialogBuyApartmentComponent, {
      data: this.apartmentInfo
    });
    dialogRef.disableClose = true;
  }
}

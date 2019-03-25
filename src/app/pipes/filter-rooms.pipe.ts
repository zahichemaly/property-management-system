import { Pipe, PipeTransform } from '@angular/core';
import { MatTableDataSource } from '@angular/material';

@Pipe({
  name: 'filterRooms'
})
export class FilterRoomsPipe implements PipeTransform {

  transform(values: MatTableDataSource<any>, nbOfRooms: string) {

    if (nbOfRooms == null) {
      return values;
    }

    values.filterPredicate =
    (data: any, filter: string) => data.nbOfRooms == filter;
  
    values.filter = nbOfRooms;
    return values;
  }
}

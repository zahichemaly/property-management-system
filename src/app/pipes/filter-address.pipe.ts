import { Pipe, PipeTransform } from '@angular/core';
import { MatTableDataSource } from '@angular/material';

@Pipe({
  name: 'filterAddress'
})
export class FilterAddressPipe implements PipeTransform {

  transform(values: MatTableDataSource<any>, address: string) {

    if (address == null){
      return values;
    }

    values.filterPredicate =
    (data: any, filter: string) => data.address.toLowerCase().includes(filter);
    
    address = address.trim(); // Remove whitespace
    address = address.toLowerCase(); // Datasource defaults to lowercase matches
    values.filter = address;
    return values;
  }
}

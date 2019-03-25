import { Pipe, PipeTransform } from '@angular/core';
import { MatTableDataSource } from '@angular/material';

@Pipe({
  name: 'filterPriceTo'
})
export class FilterPriceToPipe implements PipeTransform {

  transform(values: MatTableDataSource<any>, priceTo: string) {
    
    if (priceTo != null){
      values.filterPredicate =
      (data: any, filter: string) => data.price <= +filter;

      values.filter = priceTo;
      return values;
    }
    return values;
  }

}

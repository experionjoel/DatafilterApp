import { Injectable } from '@angular/core';

@Injectable()
export class GetdateService {

  constructor() { }
  date_Value;

  // return the start date and end date

  parseDate(dateString: string): Date {
    if (dateString) {
        this.date_Value= new Date(dateString);
        return(this.date_Value);
    } else {
        return null;
    }
}

}

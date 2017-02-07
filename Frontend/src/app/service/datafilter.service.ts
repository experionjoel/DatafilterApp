import { Injectable } from '@angular/core';
import { OperatorListRequest } from '../commonClasses/operator-list-request';
import { HttpService } from './http.service';
import { Router } from '@angular/router';
import { Employee } from '../commonClasses/employee';
import { Observable } from 'rxjs';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';

@Injectable()
export class DatafilterService {

  constructor(
    private httpService: HttpService
  ) { }

  sendOperatorRequest(requestOperator: any): any {
    console.log(" reached service");
    var response = this.httpService.sendOperatorRequest(requestOperator).subscribe(
      (data) => {
        if (data == null) {
          // this.router.navigate(['/main']);
          alert("No operators available !");
        }
        else {
          console.log(data);
          return data;
        }
      });
    console.log(response + "final");
  }

  completeTableData():Observable <any> {
    console.log(" reached service");
    var holder;
    var response = this.httpService.completeTableData().subscribe(
      (data) => {
        if (data == null) {
          // this.router.navigate(['/main']);
          alert("data available !");
        }
        else {
          console.log(data);
          return data.map((res:Response) => res.json());;
        }
      });
      return null;
  }
}



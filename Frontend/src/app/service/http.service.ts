
import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import 'rxjs/Rx';
import { Observable } from 'rxjs';
import { LoginUser } from '../commonClasses/login-user';
import { Employee } from '../commonClasses/employee';
import { Filterparameters } from '../commonClasses/filterparameters';
import { OperatorListRequest } from '../commonClasses/operator-list-request';


@Injectable()
export class HttpService {

  constructor(private http: Http) { }
  operatorRequest: OperatorListRequest;

  getDataByFilter(filterData: Filterparameters):Observable <any>
  {
    const body = JSON.stringify(filterData);
    console.log();
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:52431/api/getEmployeesByCondition', filterData, { headers:headers})
    .map((res:Response) => res.json());
  }

  completeTableData( ):Observable <any>
  {
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.get('http://localhost:52431/api/getAllEmployees', { headers:headers })
    .map((res:Response) => res.json());
  }

  // Send request for operators applicable on the current field selected.
  sendOperatorRequest( request:any ):Observable <any>
  {
    console.log(typeof(request));

    var requestOperators = { "FieldName": request };
    const body = JSON.stringify(request);
    console.log(request);
    const headers = new Headers();
    headers.append('Content-Type','application/json'); 
    return this.http.post('http://localhost:52431/api/getOperators', requestOperators, { headers:headers})
    .map((res:Response) => res.json());
  }

  // Authorize a user by Http request
  LoginAuthorize(user: LoginUser):Observable <any>
  {
    console.log("From http service",user.UserName,user.Password);
    const body = JSON.stringify(user);
    console.log(user)
    const headers = new Headers();
    headers.append('Content-Type','application/json');
    return this.http.post('http://localhost:52431/api/userauth', user, {headers:headers})
    .map((response : Response) => response.json());
  }

}


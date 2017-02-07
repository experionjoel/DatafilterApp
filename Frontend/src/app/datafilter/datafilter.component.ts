import { Component, OnInit, OnChanges } from '@angular/core';
import { Employee } from '../commonClasses/employee';
import { OperatorListRequest } from '../commonClasses/operator-list-request';
import { GetdateService } from '../service/getdate.service';
import { DatafilterService } from '../service/datafilter.service';
import { Observable } from 'rxjs';
import { Filterparameters } from '../commonClasses/filterparameters';
import { HttpService } from '../service/http.service';
import { Subscription } from 'rxjs/Rx';


@Component({
  selector: 'app-datafilter',
  templateUrl: './datafilter.component.html',
  styleUrls: ['./datafilter.component.css']
})
export class DatafilterComponent implements OnInit, OnChanges {

  constructor(
    private getdateService: GetdateService,
    private datafilterService: DatafilterService,
    private httpService: HttpService
  ) { }

  employeeSet: Employee;
  employees: any;
  currentFilter: Filterparameters = {
    FieldName : null,
    value : null, 
    DateOfJoining: null,
    FromDate: null,
    ToDate: null,
    operator: {
      OperatorSymbol: null
    }
  };

  ngOnInit() {
    this.Reset();
  }

  ngOnChanges() {
    this.Reset();
  }

  SelectedValue: string = null;
  date_Value;
  SelectedValueno: string = null;
  SelectedValuename: string = null;
  SelectedValueband: string = null;
  SelectedValueop: string = null;
  public operatorList: any[] = null;
  FieldName: string;

  // parseDate(dateString: string): Date {
  //     if (dateString) {
  //         this.date_Value= new Date(dateString);
  //         return(this.date_Value);
  //     } else {
  //         return null;
  //     }
  // }

  FetchFieldOperators(fieldValue: string): any {
    console.log(" reached service ");
    this.FieldName = fieldValue;
    var response = this.httpService.sendOperatorRequest(this.FieldName).subscribe(
      (data) => {
        this.operatorList = data;
        console.log(this.operatorList);
      }
    );
  }

  Reset(): Observable<any> {
    console.log(" reached service");
    var response = this.httpService.completeTableData().subscribe(
      (data) => {
        if (data == null) {
          alert("data not available !");
        }
        else {
          console.log(data);
          this.employees = data;
        }
      });
    this.currentFilter = {
        FieldName : null,
        value : null, 
        DateOfJoining: null,
        FromDate: null,
        ToDate: null,
        operator: {
          OperatorSymbol: null
        }
      };      
    return this.employees;
  }

  // Function that accepts the filter parameters
  FilterData(formContent: Filterparameters) {
    console.log(formContent);
    console.log(this.currentFilter);
    var response = this.httpService.getDataByFilter(this.currentFilter).subscribe(
      (data) => {
        if (data == null) {
          alert("data not available !");
        }
        else {
          console.log(data);
          this.employees = data;
        }
      });
  }

  MainFields = {
    "details": [
      {
        "id": 1,
        "name": "--Select--",
        "value": ""
      },
      {
        "id": 2,
        "name": "Employee Number",
        "value": "EmployeeNo"
      },
      {
        "id": 3,
        "name": "Employee Name",
        "value": "EmployeeName"
      },
      {
        "id": 4,
        "name": "Date of Joining",
        "value": "DateOfJoining"
      },
      {
        "id": 5,
        "name": "Designation",
        "value": "Designation"
      },
      {
        "id": 6,
        "name": "Band",
        "value": "Band"
      }
    ]
  };

}


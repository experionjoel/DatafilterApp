using DataFilterWebApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataFilterWebApp.Models;

namespace DataFilterWebApp.Controllers
{
    public class DataFilterController : ApiController
    {
        public LoginResponse SessionResponse = null;
        public FieldOperators FieldOperatorsList;
        private readonly AppContext _appContext;
        public DataFilterController()
        {
            _appContext = new AppContext();
        }

        // Method to authenticate users
        [HttpPost]
        [Route("api/userauth")]
        public LoginResponse UserAuth(LoginRequest SessionRequest)
        {
            var UserList = _appContext.UsersDb.AsEnumerable();
            var ValidUser = UserList.Where(u => u.UserName == SessionRequest.UserName && u.Password == SessionRequest.Password)
                            .FirstOrDefault();

            if (ValidUser == null)
            {
                this.SessionResponse = new LoginResponse
                {
                    Status = false
                };
            }
            else
            {
                this.SessionResponse = new LoginResponse
                {
                    Status = true
                };
            }
            return this.SessionResponse;
        }

        // Method to fetch the operators associated with the currently selected
        // dropdown field.
        [HttpPost]
        [Route("api/getOperators")]
        public IEnumerable<Operator> FieldOperatorMapping (OperatorListRequest Field)
        {
            var Operators = _appContext.OperatorsDb.AsEnumerable();
            var FieldOperatorsMapped = _appContext.FieldOperatorDb.AsEnumerable();

            var operators = FieldOperatorsMapped.Where(f => f.FieldName == Field.FieldName)
                            .Select(fo => new Operator
                            {
                                Id = fo.OperatorId,
                                OperatorSymbol = fo.Operator.OperatorSymbol
                            });
            return operators;
        }

        // Method to fetch the list of employees after filtering
        [HttpPost]
        [Route("api/getEmployeesByCondition")]
        public IEnumerable<Employee> FilterResult(Filter inputsToFilter)
        {
            var employees = _appContext.EmployeesDb.AsEnumerable();
            var operators = _appContext.OperatorsDb.AsEnumerable();
            IEnumerable<Employee> selectedEmployees = null;

            switch (inputsToFilter.FieldName)
            {
                case "EmployeeName":
                    selectedEmployees = SelectByEmployeeName(inputsToFilter);
                    break;
                case "Designation":
                case "Band":
                    selectedEmployees = SelectByEmployeeDesignationAndBand(inputsToFilter);
                    break;
                case "DateOfJoining":
                case "EmployeeNo":
                    selectedEmployees = SelectByEmployeeDoJAndNumber(inputsToFilter);
                    break;
            };

            return selectedEmployees;
        }

        // Method to process employees using operators common to
        // Employee Date of Joining and Employee Number.
        IEnumerable<Employee> SelectByEmployeeDoJAndNumber(Filter inputsToFilter)
        {
            var employees = _appContext.EmployeesDb.AsEnumerable();
            IEnumerable<Employee> selectEmployees = null;

            // NOT OPERATOR <>
            if (inputsToFilter.Operator.OperatorSymbol == "<>")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining != inputsToFilter.DateOfJoining
                                          select e;                  
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo.ToString() != inputsToFilter.value
                                          select e;
                        break;
                };
            }
            // BETWEEN OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == "BETWEEN")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining > inputsToFilter.FromDate 
                                                && e.DateOfJoining < inputsToFilter.ToDate
                                          select e;
                        break;
                };
            }
            // LESS THAN (<) OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == "<")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining < inputsToFilter.DateOfJoining
                                          select e;
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo < Int32.Parse(inputsToFilter.value)
                                          select e;
                        break;
                };
            }
            // GREATER THAN (>) OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == ">")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining > inputsToFilter.DateOfJoining
                                          select e;
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo > Int32.Parse(inputsToFilter.value)
                                          select e;
                        break;
                };
            }
            // LESS THAN OR EQUAL TO (<=) OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == "<=")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining <= inputsToFilter.DateOfJoining
                                          select e;
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo <= Int32.Parse(inputsToFilter.value)
                                          select e;
                        break;
                };
            }
            // GREATER THAN OR EQUAL TO(<) OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == ">=")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining >= inputsToFilter.DateOfJoining
                                          select e;
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo >= Int32.Parse(inputsToFilter.value)
                                          select e;
                        break;
                };
            }
            // EQUALITY(==) OPERATOR
            else if (inputsToFilter.Operator.OperatorSymbol == "=")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "DateOfJoining":
                        selectEmployees = from e in employees
                                          where e.DateOfJoining == inputsToFilter.DateOfJoining
                                          select e;
                        break;
                    case "EmployeeNo":
                        selectEmployees = from e in employees
                                          where e.EmployeeNo == Int32.Parse(inputsToFilter.value)
                                          select e;
                        break;
                };
            }
            return selectEmployees;
        }

        // Method to process employees using operators common to
        // Employee Designation and Band.
        IEnumerable<Employee> SelectByEmployeeDesignationAndBand(Filter inputsToFilter)
        {
            var employees = _appContext.EmployeesDb.AsEnumerable();
            IEnumerable<Employee> selectEmployees = null;

            // IS-NOT OPERATOR
            if (inputsToFilter.Operator.OperatorSymbol == "IS NOT")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "Designation":
                        selectEmployees = from e in employees
                                          where e.Designation != inputsToFilter.value
                                          select e;
                        break;
                    case "Band":
                        selectEmployees = from e in employees
                                          where e.Band != inputsToFilter.value
                                          select e;
                        break;
                };
            }
            // IS OPERATOR
            if (inputsToFilter.Operator.OperatorSymbol == "IS")
            {
                switch (inputsToFilter.FieldName)
                {
                    case "Designation":
                        selectEmployees = from e in employees
                                          where e.Designation.Equals(inputsToFilter.value)
                                          select e;
                        break;
                    case "Band":
                        selectEmployees = from e in employees
                                          where e.Band.Equals(inputsToFilter.value)
                                          select e;
                        break;
                };
            }

            return selectEmployees;
        }

        // Method to process employees using operators applicable
        // for Employee name field only.
        IEnumerable<Employee> SelectByEmployeeName(Filter inputsToFilter)
        {
            var employees = _appContext.EmployeesDb.AsEnumerable();
            IEnumerable<Employee> selectEmployees = null;

            if(inputsToFilter.FieldName == "EmployeeName")
            {
                switch (inputsToFilter.Operator.OperatorSymbol)
                {
                    case "=": // Equal to operator
                        selectEmployees = from e in employees
                                          where e.EmployeeName.Equals(inputsToFilter.value)
                                          select e;
                        break;
                    case "<>": // NOT operator
                        selectEmployees = from e in employees
                                          where e.EmployeeName != inputsToFilter.value
                                          select e;
                        break;
                    case "LIKE": // LIKE operator
                        selectEmployees = from e in employees
                                          where e.EmployeeName.Contains(inputsToFilter.value)
                                          select e;
                        break;
                };
            }

            return selectEmployees;
        }

        // Method to fetch the list of all employees
        [HttpGet]
        [Route("api/getAllEmployees")]
        public IEnumerable<Employee> Reset()
        {
            var employees = _appContext.EmployeesDb.AsEnumerable();
            return employees;
        }
    }
}

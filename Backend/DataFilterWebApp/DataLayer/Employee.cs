using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.DataLayer    
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string Band { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public int EmployeeNo { get; set; }
    }
}
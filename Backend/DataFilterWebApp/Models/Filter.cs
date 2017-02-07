using DataFilterWebApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.Models
{
    public class Filter
    {
        public string FieldName { get; set; }
        public string value { get; set; }

        public DateTime? DateOfJoining { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public Operator Operator { get; set; }

    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.Models
{
    public class FieldOperators
    {
        public string FieldName { get; set; }
        public List<FieldOperatorList> OperatorList { get; set; }
    }
}
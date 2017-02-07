using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.DataLayer
{
    public class Operator
    {
        public int Id { get; set; }
        public string OperatorSymbol { get; set; }

        // Single operator can be related to many Field names.
        public ICollection<FieldOperator> FieldOperators { get; set; }
    }
}
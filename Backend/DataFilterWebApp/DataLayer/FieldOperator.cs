using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.DataLayer
{
    public class FieldOperator
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public virtual Operator Operator { get; set; }

        // Foreign Key of Operator Table
        public int OperatorId { get; set; }
    }
}
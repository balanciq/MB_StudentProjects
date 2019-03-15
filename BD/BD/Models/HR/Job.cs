using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Models.HR
{
    public class Job
    {
        public string JobId { get; set; }

        public int Salary { get; set; }

        public int? EmployeeId { get; set;}
        public virtual Employee Employee { get; set; }
    }
}
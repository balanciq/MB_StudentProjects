using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Models.HR
{
    public class Department
    {
        public int DepartmentId { get; set; }
        
        public string DepartmentName { get; set; }
        public string DepartmentCity { get; set; }
        public string DepartmentAddress { get; set; }
        //количество рабочих
        public int EmplQuant { get; set; }

        public int? CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Department()
        {
            Employees = new List<Employee>();
        }
    }
}
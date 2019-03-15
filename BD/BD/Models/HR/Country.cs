using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Models.HR
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public int DepQuant { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        public Country()
        {
            Departments = new List<Department>();
        }

    }
}
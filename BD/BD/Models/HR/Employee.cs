using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Models.HR
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        //ФИО
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        //Паспортные данные
        public string PasportData { get; set; }

        public string PhoneNumber { get; set; }
        //образование
        public string Graduate { get; set; }

        //Дата рождения
        public DateTime BirthDate { get; set; }
        //Адресс
        public string Address { get; set; }
        //Языки
        public string Languages { get; set; }
        //Последняя занимаемая должность
        public string LastJob { get; set; }
        //Дата приема
        public DateTime СomeDate { get; set; }
        //Срок контракта
        public int ContractTerm { get; set; }
        
        public bool Status { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
        public Employee()
        {
            Jobs = new List<Job>();
        }
    }
}
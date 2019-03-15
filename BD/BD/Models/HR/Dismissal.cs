using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Models.HR
{
    public class Dismissal
    {
        public int DismissalId { get; set; }
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
        public DateTime? BirthDate { get; set; }
        //Адресс
        public string Address { get; set; }
        //Языки
        public string Languages { get; set; }
        //Последняя занимаемая должность
        public string LastJob { get; set; }
        //Дата приема
        public DateTime? СomeDate { get; set; }
        //Срок контракта
        public int ContractTerm { get; set; }
        //Дата увольнения 
        public DateTime? DisDate { get; set; }

        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
using BD.Models.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BD.Data
{
    public class DummyData
    {
        public static List<Country> GetCountries()
        {
            List<Country> countries = new List<Country>()
            {
                new Country()
                {
                    CountryId=1,
                    CountryCode="UK",
                    CountryName="United Kingdom",
                    DepQuant = 1

                },
                new Country()
                {
                    CountryId=2,
                    CountryCode="UA",
                    CountryName="UKRAINE",
                    DepQuant = 1

                },


            };
            return countries;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>()
        {
             new Department()
                {

                    DepartmentCity = "London",
                    DepartmentName = "NineStrangeLandon",
                    DepartmentAddress ="Bakker,st 144B",
                    DepartmentId = 1,
                    EmplQuant =2,
                    CountryId = 1



                },
                new Department()
                {
                    DepartmentId = 2,
                    DepartmentName = "NineStrangeKharkiv",
                    DepartmentCity = "Kharkiv",
                    DepartmentAddress ="Silovaya 9",
                    EmplQuant =2,
                    CountryId = 2


                },

        };
            return departments;

        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>()
        {
             new Employee()
                {

                   EmployeeId=1,
                   Name = "Valera",
                   Surname ="Zhmishenko",
                   MiddleName = "Fedorovich",
                   PasportData = "MT324801",
                   PhoneNumber ="+38021234121",
                   Graduate = "KHPI",
                   BirthDate = new DateTime(1978, 3, 22),
                   Languages = "English,Ukranian,Polish",
                   Address = "Zhitomer, st Kozaka 25",
                   LastJob = "Strimer",
                   СomeDate = new DateTime(2015, 4, 21),
                   ContractTerm = 2,
                   DepartmentId = 1



                },
                new Employee()
                {
                    EmployeeId=2,
                   Name = "Denis",
                   Surname ="Sahno",
                   MiddleName = "Olegovich",
                   PasportData = "MT213101",
                   PhoneNumber ="+38032222869",
                   Graduate = "KHAI",
                   Languages = "Ukranian",
                   BirthDate = new DateTime(1998, 5, 26),
                   LastJob = "Security",
                   СomeDate = new DateTime(2014, 4, 11),
                   ContractTerm = 3,
                    Address = "Kharkiv, st Silovaya 25",
                   DepartmentId = 2


                },
                new Employee()
                {
                   EmployeeId=3,
                   Name = "Yuri",
                   Surname ="Novikov",
                   MiddleName = "Aleksandrovich",
                   PasportData = "MT256101",
                   PhoneNumber ="+38032222869",
                   Graduate = "KHAI",
                   Languages = "Ukranian",
                   BirthDate = new DateTime(1997, 12, 12),
                    Address = "Kharkiv, st Zhilardi 25",
                   LastJob = "Sailor",
                   СomeDate = new DateTime(2014, 4, 11),
                   ContractTerm = 2,
                   DepartmentId = 2


                }

        };
            return employees;

        }

        public static List<Job> GetJobs()
        {
            List<Job> jobs = new List<Job>()
        {
             new Job()
                {

                   JobId = "Sales Manager",
                   Salary = 300,
                   EmployeeId = 1



                },
                new Job()
                {
                   JobId = "Clean Manager",

                   Salary = 80,
                   EmployeeId = 2


                },
                new Job()
                {
                   JobId = "HR",

                   Salary = 800,
                   EmployeeId = 3


                }

        };
            return jobs;

        }
    }

   

}
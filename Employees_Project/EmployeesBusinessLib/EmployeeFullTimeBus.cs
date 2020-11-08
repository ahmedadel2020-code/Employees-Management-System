using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesEntity;


namespace EmployeesBusinessLib
{
    public class EmployeeFullTimeBus:EmployeeFullTimeEntity
    {
        // create a static FullTime list
        public static List<EmployeeFullTimeEntity> _EmployeeFullTimeList;

        // make a constructor to make inistance from the list
        static EmployeeFullTimeBus()
        {
            _EmployeeFullTimeList = new List<EmployeeFullTimeEntity>();
        }

        // this method check if the name has number in it
        public static void ExName (EmployeeFullTimeBus ExN)
        {
            bool isDigitPresent;

            if (isDigitPresent = ExN.Name.Any(c => char.IsDigit(c)))
            {
                throw new Exception("Name can't have Numbers");
            }
        }

        // this method check age
        public static void ExBirthday (EmployeeFullTimeBus ExB)
        {
            DateTime now = DateTime.Now;
            TimeSpan sub = now - ExB.Birthday;
            int age = sub.Days / 365;
            if (age < 10)
            {
                throw new Exception("Age cant be < 10");
            }
        }

        // this method check if salary has minus sign in it
        public static void ExSalary(EmployeeFullTimeBus ExS)
        {
            ExS.CalculationResultFull = ExS.CalcSalary(ExS);
            if (ExS.Salary.ToString().Contains("-"))
            {
                throw new Exception("Salary cant be negative");
            }
        }

        // this method Add FullTime Employees to the list
        public static void AddEmployeesFull(EmployeeFullTimeBus EmployeeFull)
        {
         
            _EmployeeFullTimeList.Add(EmployeeFull);
            
        }

        // this method delete fullTime Employee from the list
        public static void DeleteFullTimeEmployee(EmployeeFullTimeBus DeleteFullEmp)
        {
            _EmployeeFullTimeList.RemoveAll(r => r.ID == DeleteFullEmp.ID);
        }

        // this method display one item in the list
        public static void DisplayByIdFull(EmployeeFullTimeEntity displayFull)
        {
            
            EmployeeFullTimeEntity cust =  _EmployeeFullTimeList.Find(x => x.ID == displayFull.ID);

            Console.WriteLine("Name = {0}, ID = {1}, Birthday = {2}, FullTimeSalary = {3}", cust.Name, cust.ID, cust.Birthday.ToShortDateString(), cust.CalculationResultFull);

        }
        
        // this method display all items in the list
        public static void DisplayAllEmployeesFull()
        {
            foreach(EmployeeFullTimeBus emf in _EmployeeFullTimeList)
            {
                Console.WriteLine("Name = {0}, ID = {1}, Birthday = {2}, FullTimeSalary = {3}", emf.Name, emf.ID, emf.Birthday.ToShortDateString(), emf.CalculationResultFull);
            }
        }

        // this method calculate the salary by multiply it by 10
        public double CalcSalary(EmployeeFullTimeEntity x)
        {
            return x.Salary * 10;
        }
    }
}

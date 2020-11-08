using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeesEntity;


namespace EmployeesBusinessLib
{
    public class EmployeePartTimeBus: EmployeePartTimeEntity
    {
        // create a static PartTime list
        public static List<EmployeePartTimeEntity> _EmployeePartTimeList;

        // make a constructor to make inistance from the list
        static EmployeePartTimeBus()
        {
            _EmployeePartTimeList = new List<EmployeePartTimeEntity>();
        }

        // this method check if the name has number in it
        public static void ExName(EmployeePartTimeBus ExN)
        {
            bool isDigitPresent;

            if (isDigitPresent = ExN.Name.Any(c => char.IsDigit(c)))
            {
                throw new Exception("Name can't have Numbers");
            }
        }

        // this method check age
        public static void ExBirthday(EmployeePartTimeBus ExB)
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
        public static void ExSalary(EmployeePartTimeBus ExS)
        {
            ExS.CalculationResultPart = ExS.CalcSalary(ExS);
            if (ExS.Salary.ToString().Contains("-"))
            {
                throw new Exception("Salary cant be negative");
            }
        }

        // this method Add PartTime Employees to the list
        public static void AddEmployeePart(EmployeePartTimeBus EmployeePart)
        {

            _EmployeePartTimeList.Add(EmployeePart);

        }

        // this method delete fullTime Employee from the list
        public static void DeletePartTimeEmployee(EmployeePartTimeBus DeletePartEmp)
        {
            _EmployeePartTimeList.RemoveAll(r => r.ID == DeletePartEmp.ID);
        }


        // this method display one item in the list
        public static void DisplayByIdPart(EmployeePartTimeEntity displayPart)
        {

            EmployeePartTimeEntity cust = _EmployeePartTimeList.Find(x => x.ID == displayPart.ID);

            Console.WriteLine("Name = {0}, ID = {1}, Birthday = {2}, FullTimeSalary = {3}", cust.Name, cust.ID, cust.Birthday.ToShortDateString(), cust.CalculationResultPart);

        }

        // this method display all items in the list
        public static void DisplayAllEmployeesPart()
        {
            foreach (EmployeePartTimeBus emp in _EmployeePartTimeList)
            {
                Console.WriteLine("Name = {0}, ID = {1}, Birthday = {2}, PartTimeSalary = {3}", emp.Name, emp.ID, emp.Birthday.ToShortDateString(), emp.CalculationResultPart);
            }
        }

        // this method calculate the salary by multiply it by 5
        public double CalcSalary(EmployeePartTimeEntity x)
        {
            return x.Salary * 5;
        }
    }
}

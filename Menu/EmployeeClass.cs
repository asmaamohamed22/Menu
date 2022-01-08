using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    public class EmployeeClass
    {
        private int id;
        private string name;
        private double salary;

        private static readonly List<EmployeeClass> Employees = new List<EmployeeClass>();

        public static void New()
        {
            EmployeeClass employee = new EmployeeClass();

            bool validId = false;
            bool validName = false;
            bool validSalary = false;

            Console.WriteLine("Add New Employee\n");
            Console.WriteLine("------------------------------------------------------");

            while (!validId)
            {
                Console.Write("Enter The ID Of Employee : ");
                string EID = Console.ReadLine();

                if (int.TryParse(EID, out employee.id) && employee.id != 0 && !Employees.Any(x => x.id == employee.id))
                {
                    validId = true;
                }
                else
                {
                    Console.WriteLine("please Enter A Valid ID !!");
                    Console.WriteLine("------------------------------------------------------");
                }
            }

            while (!validName)
            {
                Console.Write("Enter The Name Of Employee : ");
                employee.name = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(employee.name) && !ValidateName(employee.name))
                {
                    validName = true;
                }
                else
                {
                    Console.WriteLine("please Enter A Valid Name !!");
                    Console.WriteLine("------------------------------------------------------");
                }
            }

            while (!validSalary)
            {
                Console.Write("Enter The Salary Of Employee : ");
                string ESalary = Console.ReadLine();

                if (double.TryParse(ESalary, out employee.salary) && employee.salary != 0)
                {
                    validSalary = true;
                }
                else
                {
                    Console.WriteLine("please Enter A Valid Salary !!");
                    Console.WriteLine("------------------------------------------------------");
                }
            }

            Employees.Add(employee);

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Employees Added Successfully . . . ");
        }

        public static void Display()
        {
            Console.WriteLine("The List Of Employees\n");
            Console.WriteLine("------------------------------------------------------");

            if (Employees.Count != 0)
            {
                foreach (var employee in Employees)
                {
                    Console.WriteLine("Employee ID is : " + employee.id);
                    Console.WriteLine("Employee Name is : " + UpperCaseFirst(employee.name));
                    Console.WriteLine("Employee Salary is : "+ employee.salary);
                    Console.WriteLine("------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("List Of Employees is Empty . . . ");
                Console.WriteLine("------------------------------------------------------");
            }
        }

        public static void Sort()
        {
            List<EmployeeClass> sortedEmployees = Employees.OrderBy(x => x.name).ToList();

            Console.WriteLine("The List Of Sorted Employees\n");
            Console.WriteLine("------------------------------------------------------");

            if (sortedEmployees.Count != 0)
            {
                int i = 0;

                foreach (var emp in sortedEmployees)
                {
                    Console.Write("{0}. ", (i + 1));
                    Console.WriteLine(UpperCaseFirst(emp.name));
                    i++;
                }
                Console.WriteLine("------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("List Of Sorted Employees is Empty . . . ");
                Console.WriteLine("------------------------------------------------------");
            }
        }

        private static string UpperCaseFirst(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        private static bool ValidateName(string name)
        {
            return name.Any(char.IsDigit);
        }
    }
}

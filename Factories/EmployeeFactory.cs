using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Factories
{
    public class EmployeeFactory: IFactory<Employee>
    {
        public Employee Create(params object[] parameters)
        {
            if (parameters.Length != 5)
            {
                throw new ArgumentException("Invalid number of parameters for creating an Employee.");
            }

            // Assuming parameters are passed in the order: Name, LastName, Sex, Profession, EmployedDate, BirthDate
            string name = parameters[0] as string;
            string lastName = parameters[1] as string;
            string profession = parameters[2] as string;
            DateTime employedDate = (DateTime)parameters[3];
            DateTime birthDate = (DateTime)parameters[4];

            // Create and return the Employee instance
            return new Employee
            {
                Name = name,
                LastName = lastName,
                Profession = profession,
                EmployedDate = employedDate,
                BirthDate = birthDate
            };
        }
    }
}
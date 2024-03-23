using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PersonalManagement.DAL
{
    public class PersonalManagementInitializer: DropCreateDatabaseIfModelChanges<PersonalManagementContext>
    {
        protected override void Seed(PersonalManagementContext context)
        {
            var random = new Random();
            var maleNames = new List<string> { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Charles", "Thomas" };
            var femaleNames = new List<string> { "Mary", "Patricia", "Jennifer", "Linda", "Elizabeth", "Susan", "Jessica", "Sarah", "Karen", "Nancy" };
            var lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones", "Miller", "Davis", "Garcia", "Rodriguez", "Martinez" };
            var professions = new List<string> { "Software Engineer", "HR Manager", "Accountant", "Marketing Specialist", "Project Manager", "Graphic Designer", "Sales Representative", "Financial Analyst", "Teacher", "Nurse" };
            var deductionTypes = new List<string> { "Health Insurance", "401(k) Contribution", "Flexible Spending Account", "Life Insurance", "Dental Insurance", "Vision Insurance", "Gym Membership", "Transportation Benefit", "Education Assistance", "Childcare Assistance" };

            foreach (var type in deductionTypes)
            {
                context.DeductionTypes.Add(new DeductionType { Name = type });
            }

            context.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                string firstName, lastName;

                if (random.Next(2) == 0)
                {
                    firstName = maleNames[random.Next(maleNames.Count)];
                }
                else
                {
                    firstName = femaleNames[random.Next(femaleNames.Count)];
                }

                lastName = lastNames[random.Next(lastNames.Count)];

                var employee = new Employee
                {
                    Name = firstName,
                    LastName = lastName,
                    Profession = professions[random.Next(professions.Count)],
                    EmployedDate = DateTime.Now.AddYears(-random.Next(1, 10)),
                    BirthDate = DateTime.Now.AddYears(-random.Next(20, 60)) 
                };

                context.Employees.Add(employee);

                for (int j = 0; j < 2; j++)
                {
                    var deduction = new Deduction
                    {
                        DeductionTypeID = random.Next(1, deductionTypes.Count),
                        Sum = random.Next(50, 300),
                        EmployeeID = employee.ID,
                    };

                    employee.Deductions.Add(deduction);
                }
            }

            context.SaveChanges();
        }
    }
}
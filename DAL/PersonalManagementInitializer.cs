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

            for (int i = 0; i < 10; i++)
            {
                string firstName, lastName;
                char sex;

                if (random.Next(2) == 0)
                {
                    firstName = maleNames[random.Next(maleNames.Count)];
                    sex = 'M';
                }
                else
                {
                    firstName = femaleNames[random.Next(femaleNames.Count)];
                    sex = 'F';
                }

                lastName = lastNames[random.Next(lastNames.Count)];

                var employee = new Employee
                {
                    Name = firstName,
                    LastName = lastName,
                    Sex = sex,
                    Profession = professions[random.Next(professions.Count)],
                    EmployedDate = DateTime.Now.AddYears(-random.Next(1, 10)), // Random employment date within the last 10 years
                    BirthDate = DateTime.Now.AddYears(-random.Next(20, 60)) // Random birth date between 20 and 60 years ago
                };

                context.Employees.Add(employee);

                for (int j = 0; j < 2; j++)
                {
                    var deduction = new Deduction
                    {
                        DeductionType = deductionTypes[random.Next(deductionTypes.Count)],
                        Sum = random.Next(50, 300), // Random deduction amount between 50 and 300
                        EmployeeID = employee.ID,
                    };

                    employee.Deductions.Add(deduction);
                }
            }

            context.SaveChanges();
        }
    }
}
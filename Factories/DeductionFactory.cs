using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Factories
{
    public class DeductionFactory: IFactory<Deduction>
    {
        public Deduction Create(params object[] parameters)
        {
            if (parameters.Length != 3)
            {
                throw new ArgumentException("Invalid number of parameters for creating a Deduction.");
            }

            // Assuming parameters are passed in the order: Sum, EmployeeID, DeductionTypeID
            int sum = (int)parameters[0];
            int employeeID = (int)parameters[1];
            int deductionTypeID = (int)parameters[2];

            // Create and return the Deduction instance
            return new Deduction
            {
                Sum = sum,
                EmployeeID = employeeID,
                DeductionTypeID = deductionTypeID
            };
        }
    }
}
using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalManagement.Factories
{
    public class DeductionTypeFactory: IFactory<DeductionType>
    {
        public DeductionType Create(params object[] parameters)
        {
            if (parameters.Length != 1)
            {
                throw new ArgumentException("Invalid number of parameters for creating a DeductionType.");
            }

            string name = parameters[0].ToString();

            DeductionType deductionType = new DeductionType
            {
                Name = name,
            };

            return deductionType;
        }
    }
}
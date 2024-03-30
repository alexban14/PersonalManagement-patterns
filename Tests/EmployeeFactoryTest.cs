using PersonalManagement.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class EmployeeFactoryTest
    {
        [Test]
        public void Create_ValidParameters_ReturnsEmployeeInstance()
        {
            var factory = new EmployeeFactory();
            string name = "John";
            string lastName = "Doe";
            string profession = "Developer";
            DateTime employedDate = DateTime.Now;
            DateTime birthDate = new DateTime(1990, 1, 1);

            var employee = factory.Create(name, lastName, profession, employedDate, birthDate);

            // Assertions
            Assert.IsNotNull(employee);
            Assert.That(name, Is.EqualTo(employee.Name));
            Assert.That(lastName, Is.EqualTo(employee.LastName));
            Assert.That(profession, Is.EqualTo(employee.Profession));
            Assert.That(employee.EmployedDate, Is.EqualTo(employedDate));
            Assert.That(birthDate, Is.EqualTo(employee.BirthDate));
        }

        [Test]
        public void Create_InvalidParameters_ThrowsArgumentException()
        {
            var factory = new EmployeeFactory();
            string name = "John";
            string lastName = "Doe";
            string profession = "Developer";
            DateTime employedDate = DateTime.Now;
            DateTime birthDate = new DateTime(1990, 1, 1);

            //Assert
            Assert.Throws<ArgumentException>(() => factory.Create(name, lastName, profession, employedDate));
        }
    }
}

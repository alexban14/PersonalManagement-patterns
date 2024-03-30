using Moq;
using PersonalManagement.Models;
using PersonalManagement.Repositories;
using PersonalManagement.Services;

namespace Tests
{
    public class LoggingRespositroyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Create_LogsCreation_Success()
        {
            var mockRepository = new Mock<IRepository<Employee>>();
            var mockLogger = new Mock<ILogger>();
            var loggingRepository = new LoggingRepository<Employee>(mockRepository.Object, mockLogger.Object);
            var employee = new Employee { Name = "John", LastName = "Doe", Profession = "Developer" };

            loggingRepository.Create(employee);

            // Asserting
            mockLogger.Verify(x => x.LogCreation(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Edit_LogsEdit_Success()
        {
            var mockRepository = new Mock<IRepository<Employee>>();
            var mockLogger = new Mock<ILogger>();
            var loggingRepository = new LoggingRepository<Employee>(mockRepository.Object, mockLogger.Object);
            int employeeId = 1;
            var employee = new Employee { ID = employeeId, Name = "John", LastName = "Doe", Profession = "Developer" };
            var expectedMessage = $"Entity edited: ID={employeeId}.";

            loggingRepository.Edit(employee);

            // Asserting
            mockLogger.Verify(x => x.LogEdit(typeof(Employee).Name, expectedMessage), Times.Once);
        }
    }
}
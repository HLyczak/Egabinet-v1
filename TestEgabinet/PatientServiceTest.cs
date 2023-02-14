using Core.Domain;
using Core.Repositories;
using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace TestEgabinet
{
    public class PatientServiceTest
    {
        [Fact]
        public async Task GetPatientAsync_Invoke()
        {
            //Arrange
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();

            patientRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Patient() { Id = "1", Address = "Krakow" }));

            var patientService = new PatientService(patientRepositoryMock.Object, userRepositoryMock.Object, timeSheetRepositoryMock.Object);

            // Act
            var resultUser = await patientService.GetPatientAsync("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Krakow", resultUser.Address);
            patientRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task GetUpdatePatientViewModell_Invoke()
        {
            //Arrange
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();

            patientRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Patient() { Id = "1", Address = "Krakow" }));

            var patientService = new PatientService(patientRepositoryMock.Object, userRepositoryMock.Object, timeSheetRepositoryMock.Object);

            // Act
            var resultUser = await patientService.GetUpdatePatientViewModel("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Krakow", resultUser.Address);
            patientRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task GetUser_Invoke()
        {
            //Arrange
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();

            userRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new IdentityUser() { Id = "1", Email = "janek@gmail.com" }));

            var patientService = new PatientService(patientRepositoryMock.Object, userRepositoryMock.Object, timeSheetRepositoryMock.Object);

            // Act
            var resultUser = await patientService.GetUser("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("janek@gmail.com", resultUser.Email);
            userRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task UpdatePatientAsync_Invoke()
        {
            //Arrange
            var patient = new Patient() { Id = "1", Name = "Janek", Address = "Krakow" };
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();

            patientRepositoryMock.Setup(d => d.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(patient));
            patientRepositoryMock.Setup(d => d.UpdateAsync(It.IsAny<Patient>()));

            var patientService = new PatientService(patientRepositoryMock.Object, userRepositoryMock.Object, timeSheetRepositoryMock.Object);

            // Act
            await patientService.UpdatePatientAsync(new UpdatePatientViewModel() { Address = "Warszawa" });

            // Assert
            Assert.Equal("1", patient.Id);
            Assert.Equal("Janek", patient.Name);
            Assert.Equal("Warszawa", patient.Address);
            patientRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<Patient>()), Times.Once());
            patientRepositoryMock.Verify(c => c.GetByIdAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task DeleteVisitAsync_Invoke()
        {
            //Arrange
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var userRepositoryMock = new Mock<IUserRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();

            timeSheetRepositoryMock.Setup(d => d.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new TimeSheet()));

            var patientService = new PatientService(patientRepositoryMock.Object, userRepositoryMock.Object, timeSheetRepositoryMock.Object);

            // Act
            await patientService.DeleteVisitAsync("1");

            // Assert
            timeSheetRepositoryMock.Verify(c => c.RemoveAsync(It.IsAny<string>()), Times.Once());
        }
    }
}

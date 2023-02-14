using Core.Domain;
using Core.Repositories;
using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace TestEgabinet
{
    public class NurseServiceTest
    {
        [Fact]
        public async Task GetNurseAsync_Invoke()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var nurseRepositoryMock = new Mock<INurseRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var doctorRepositoryMock = new Mock<IDoctorRepository>();

            nurseRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Nurse() { Id = "1", Address = "Krakow" }));

            var nurseService = new NurseService(userRepositoryMock.Object, nurseRepositoryMock.Object, timeSheetRepositoryMock.Object, roomRepositoryMock.Object, patientRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            var resultUser = await nurseService.GetNurseAsync("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Krakow", resultUser.Address);
            nurseRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task GetUpdateNurseViewModel_Invoke()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var nurseRepositoryMock = new Mock<INurseRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var doctorRepositoryMock = new Mock<IDoctorRepository>();

            nurseRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Nurse() { Id = "1", Address = "Krakow" }));

            var nurseService = new NurseService(userRepositoryMock.Object, nurseRepositoryMock.Object, timeSheetRepositoryMock.Object, roomRepositoryMock.Object, patientRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            var resultUser = await nurseService.GetUpdateNurseViewModel("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Krakow", resultUser.Address);
            nurseRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task GetUser_Invoke()
        {
            //Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var nurseRepositoryMock = new Mock<INurseRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var doctorRepositoryMock = new Mock<IDoctorRepository>();

            userRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new IdentityUser() { Id = "1", Email = "janek@gmail.com" }));

            var nurseService = new NurseService(userRepositoryMock.Object, nurseRepositoryMock.Object, timeSheetRepositoryMock.Object, roomRepositoryMock.Object, patientRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            var resultUser = await nurseService.GetUser("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("janek@gmail.com", resultUser.Email);
            userRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task UpdateNurseAsync_Invoke()
        {
            //Arrange
            var nurse = new Nurse() { Id = "1", Name = "Janek", Address = "Krakow", PermissionNumber = "12345" };
            var userRepositoryMock = new Mock<IUserRepository>();
            var nurseRepositoryMock = new Mock<INurseRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var doctorRepositoryMock = new Mock<IDoctorRepository>();

            nurseRepositoryMock.Setup(d => d.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(nurse));

            var nurseService = new NurseService(userRepositoryMock.Object, nurseRepositoryMock.Object, timeSheetRepositoryMock.Object, roomRepositoryMock.Object, patientRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            await nurseService.UpdateNurseAsync(new UpdateNurseViewModel() { Address = "Warszawa", PermissionNumber = "98765" });

            // Assert
            Assert.Equal("1", nurse.Id);
            Assert.Equal("Warszawa", nurse.Address);
            Assert.Equal("98765", nurse.PermissionNumber);
            nurseRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<Nurse>()), Times.Once());
            nurseRepositoryMock.Verify(c => c.GetByIdAsync(It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task DeleteVisitAsync_Invoke()
        {
            //Arrange
            var nurse = new Nurse() { Id = "1", Name = "Janek", Address = "Krakow", PermissionNumber = "12345" };
            var userRepositoryMock = new Mock<IUserRepository>();
            var nurseRepositoryMock = new Mock<INurseRepository>();
            var timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            var roomRepositoryMock = new Mock<IRoomRepository>();
            var patientRepositoryMock = new Mock<IPatientRepository>();
            var doctorRepositoryMock = new Mock<IDoctorRepository>();

            timeSheetRepositoryMock.Setup(d => d.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new TimeSheet()));

            var nurseService = new NurseService(userRepositoryMock.Object, nurseRepositoryMock.Object, timeSheetRepositoryMock.Object, roomRepositoryMock.Object, patientRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            await nurseService.DeleteVisitAsync("1");

            // Assert
            timeSheetRepositoryMock.Verify(c => c.RemoveAsync(It.IsAny<string>()), Times.Once());
        }
    }
}


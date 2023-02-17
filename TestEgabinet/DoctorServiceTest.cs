using Core.Domain;
using Core.Repositories;
using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace TestEgabinet
{
    public class DoctorServiceTest
    {
        [Fact]
        public async Task GetDoctorAsync_Invoke()
        {
            //Arrange
            Mock<ITimesheetRepository> timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IDoctorRepository> doctorRepositoryMock = new Mock<IDoctorRepository>();

            doctorRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Doctor() { Id = "1", Name = "Janek" }));

            DoctorService doctorService = new DoctorService(userRepositoryMock.Object, timeSheetRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            DoctorViewModel resultUser = await doctorService.GetDoctorAsync("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Janek", resultUser.Name);
        }

        [Fact]
        public async Task GetUpdateDoctorViewModel_Invoke()
        {
            //Arrange
            Mock<ITimesheetRepository> timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IDoctorRepository> doctorRepositoryMock = new Mock<IDoctorRepository>();

            doctorRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new Doctor() { Id = "1", Name = "Janek" }));

            DoctorService doctorService = new DoctorService(userRepositoryMock.Object, timeSheetRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act execute
            UpdateDoctorViewModel resultUser = await doctorService.GetUpdateDoctorViewModel("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("Janek", resultUser.Name);
            doctorRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());

        }

        [Fact]
        public async Task GetUser_Invoke()
        {
            //Arrange
            Mock<ITimesheetRepository> timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            Mock<IDoctorRepository> doctorRepositoryMock = new Mock<IDoctorRepository>();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            userRepositoryMock.Setup(d => d.GetByNameAsync(It.IsAny<string>())).Returns(Task.FromResult(new IdentityUser() { Id = "1", Email = "janek@gmail.com" }));

            DoctorService doctorService = new DoctorService(userRepositoryMock.Object, timeSheetRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            IdentityUser resultUser = await doctorService.GetUser("janek@gmail.com");

            // Assert
            Assert.Equal("1", resultUser.Id);
            Assert.Equal("janek@gmail.com", resultUser.Email);
            userRepositoryMock.Verify(c => c.GetByNameAsync(It.IsAny<string>()), Times.Once());

        }

        [Fact]
        public async Task UpdateDoctorAsync_Invoke()
        {
            //Arrange
            Doctor doctor = new Doctor() { Id = "1", Name = "Janek", Surname = "Nowak" };
            Mock<ITimesheetRepository> timeSheetRepositoryMock = new Mock<ITimesheetRepository>();
            Mock<IDoctorRepository> doctorRepositoryMock = new Mock<IDoctorRepository>();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();

            doctorRepositoryMock.Setup(d => d.GetByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(doctor));
            doctorRepositoryMock.Setup(d => d.UpdateAsync(It.IsAny<Doctor>()));

            DoctorService doctorService = new DoctorService(userRepositoryMock.Object, timeSheetRepositoryMock.Object, doctorRepositoryMock.Object);

            // Act
            await doctorService.UpdateDoctorAsync(new UpdateDoctorViewModel() { Name = "Adam", Surname = "Kowalski" });

            // Assert
            Assert.Equal("1", doctor.Id);
            Assert.Equal("Adam", doctor.Name);
            Assert.Equal("Kowalski", doctor.Surname);
            doctorRepositoryMock.Verify(c => c.UpdateAsync(It.IsAny<Doctor>()), Times.Once());
            doctorRepositoryMock.Verify(c => c.GetByIdAsync(It.IsAny<string>()), Times.Once());
        }
    }
}
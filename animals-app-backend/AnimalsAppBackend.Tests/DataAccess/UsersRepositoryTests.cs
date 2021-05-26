using AnimalsAppBackend.DataAccess;
using AnimalsAppBackend.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AnimalsAppBackend.Tests.DataAccess
{
    public class UsersManagementServiceTests
    {
        private readonly Mock<AnimalsAppDbContext> _animalsAppDbContext;
        private readonly Mock<DbSet<User>> _userSetMock;

        private readonly IGenericRepository<User> _genericRepository;

        public UsersManagementServiceTests()
        {
            _animalsAppDbContext = new Mock<AnimalsAppDbContext>();
            _userSetMock = new Mock<DbSet<User>>();
            _genericRepository = new GenericRepository<User>(_animalsAppDbContext.Object);
        }

        [Fact]
        public async void GetUserById_ShouldGetUserById()
        {
            //Arrange
            _userSetMock.Setup(s => s.FindAsync(It.IsAny<Guid>())).Returns(ValueTask.FromResult(new User()));
            _animalsAppDbContext.Setup(s => s.Set<User>()).Returns(_userSetMock.Object);

            //Act
            var user = await _genericRepository.GetById(Guid.NewGuid());

            //Assert
            Assert.NotNull(user);
            Assert.IsAssignableFrom<User>(user);
            _animalsAppDbContext.Verify(x => x.Set<User>());
            _userSetMock.Verify(x => x.FindAsync(It.IsAny<Guid>()));
        }
    }
}

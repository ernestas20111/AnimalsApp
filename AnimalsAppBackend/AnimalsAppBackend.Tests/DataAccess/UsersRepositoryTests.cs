using AnimalsAppBackend.DataAccess;
using Moq;
using System;
using Xunit;

namespace AnimalsAppBackend.Tests.DataAccess
{
    public class UsersManagementServiceTests
    {
        private readonly Mock<AnimalsAppDbContext> _animalsAppDbContext;
        public UsersManagementServiceTests()
        {
            _animalsAppDbContext = new Mock<AnimalsAppDbContext>();
        }

        [Fact]
        public void GetUserById_ShouldGetUserById()
        {

        }
    }
}

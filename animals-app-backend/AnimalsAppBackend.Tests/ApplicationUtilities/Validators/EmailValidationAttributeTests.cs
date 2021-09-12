using AnimalsAppBackend.ApplicationUtilities.Validators;
using Xunit;

namespace AnimalsAppBackend.Tests.ApplicationUtilities.Validators
{
    public class EmailValidationAttributeTests
    {
        [Theory]
        [InlineData("nice@gmail.com")]
        [InlineData("n@gmail.com")]
        [InlineData("coolStuff201211@gmail.com")]
        public void TestIfEmailIsValid_ShouldPass(string email)
        {
            //Arrange
            object value = email;
            EmailValidationAttribute emailValidationAttribute = new EmailValidationAttribute();

            //Act
            bool result = emailValidationAttribute.IsValid(value);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("@gmail.com")]
        [InlineData("n@hotmail.co")]
        [InlineData("coolStuff201211@g.c")]
        public void TestIfEmailIsValid_ShouldFail(string email)
        {
            //Arrange
            object value = email;
            EmailValidationAttribute emailValidationAttribute = new EmailValidationAttribute();

            //Act
            bool result = emailValidationAttribute.IsValid(value);

            //Assert
            Assert.False(result);
        }
    }
}

using AnimalsAppBackend.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace AnimalsAppBackend.Tests.ApplicationUtilities
{
    public class EmailValidationAttributeTests
    {
        [Theory]
        [InlineData("nice@gmail.com")]
        [InlineData("n@gmail.com")]
        [InlineData("coolStuff201211@gmail.com")]
        public void TestIfPasswordIsValid_ShouldPass(string email)
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
        public void TestIfPasswordIsValid_ShouldFail(string email)
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

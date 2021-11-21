using AnimalsAppBackend.ApplicationUtilities.ValidationAttributes;
using Xunit;

namespace AnimalsAppBackend.Tests.ApplicationUtilities.ValidationAttributes
{
    public class PhoneValidationAttributeTests
    {
        [Theory]
        [InlineData("+37061234112")]
        [InlineData("+37012344112")]
        [InlineData("861234411")]
        public void TestIfPhoneIsValid_ShouldPass(string phone)
        {
            //Arrange
            object value = phone;
            PhoneValidationAttribute phoneValidationAttribute = new PhoneValidationAttribute();

            //Act
            bool result = phoneValidationAttribute.IsValid(value);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("37061234112")]
        [InlineData("+36012344112")]
        [InlineData("8512344112")]
        public void TestIfPhoneIsValid_ShouldFail(string phone)
        {
            //Arrange
            object value = phone;
            PhoneValidationAttribute phoneValidationAttribute = new PhoneValidationAttribute();

            //Act
            bool result = phoneValidationAttribute.IsValid(value);

            //Assert
            Assert.False(result);
        }
    }
}

using Phonebook.RyanW84.Validators;

namespace Phonebook.Ryanw84.UnitTests;

[TestClass]
public class ValidationTests
    {
    public static IEnumerable<object[]> EmailTestData => new List<object[]>
    {
        new object[] { "test@example.com", true },  // Valid phoneNumber
        new object[] { "invalid-phoneNumber", false },    // Invalid phoneNumber
        new object[] { "invalid-emailatoxo.com", false }    // Invalid phoneNumber
    };

    public static IEnumerable<object[]> PhoneTestData => new List<object[]>
    {
        new object[] { "+441111111111", true },  // Valid Phone Number
        new object[] { "125l", false }    // Invalid Phone Number
    };

    // Naming method MethodName_Scenario_ExpectedOutcome
    [TestMethod]
 
    public void WhenphoneNumberStringIsValidReturnTrue()
        {
        //Arrange
        var phoneNumber = "+441234567891";
        //Act
        var result = ContactValidator.IsPhoneNumberValid(phoneNumber);
        //Assert
        Assert.IsTrue(result);
        }
[TestMethod]
    public void WhenPhoneNumberStringIsNotValidReturnFalse()
        {
        //Arrange
       var phoneNumber = "123456";
        //Act
        var result = ContactValidator.IsPhoneNumberValid(phoneNumber);
        //Assert
        Assert.IsFalse(result);
        }
    [TestMethod]
    public void WhenEmailAddressStringIsValidReturnTrue()
        {
        //Arrange
        var emailAddress = "oxo@oxo.com";
        //Act
        var result = ContactValidator.IsEmailAddressValid(emailAddress);
        //Assert
        Assert.IsTrue(result);
        }
    [TestMethod]
    public void WhenEmailAddressStringIsNotValidReturnFalse( )
        {
        //Arrange
        var emailAddress = "oxoatxoo.com";
        //Act
        var result = ContactValidator.IsEmailAddressValid(emailAddress);
        //Assert
        Assert.IsFalse(result);
        }

    [DataTestMethod]
    [DynamicData(nameof(EmailTestData), DynamicDataSourceType.Property)]

    public void IsEmailAddressValid_ReturnsExpectedResult(string email, bool expectedResult)
    {
        // Act
        var result = ContactValidator.IsEmailAddressValid(email);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [DataTestMethod]
    [DynamicData(nameof(PhoneTestData) , DynamicDataSourceType.Property)]

    public void IsPhoneNumberValid_ReturnsExpectedResult(string phoneNumber , bool expectedResult)
        {
        // Act
        var result = ContactValidator.IsPhoneNumberValid(phoneNumber);

        // Assert
        Assert.AreEqual(expectedResult , result);
        }
    }



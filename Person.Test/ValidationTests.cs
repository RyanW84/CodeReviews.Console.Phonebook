using Phonebook.RyanW84.Validators;

namespace Phonebook.Ryanw84.UnitTests;

[TestClass]
public class ValidationTests
    {

    // Naming method MethodName_Scenario_ExpectedOutcome
    [TestMethod]
    public void WhenphoneNumberStringIsValidReturnTrue()
        {
        //Arrange
        var phoneNumber = "+441234567891";
        //Act
        var result = ContactValidator.isPhoneNumberValid(phoneNumber);
        //Assert
        Assert.IsTrue(result);
        }
[TestMethod]
    public void WhenPhoneNumberStringIsNotValidReturnFalse()
        {
        //Arrange
       var phoneNumber = "123456";
        //Act
        var result = ContactValidator.isPhoneNumberValid(phoneNumber);
        //Assert
        Assert.IsFalse(result);
        }
    [TestMethod]
    public void WhenEmailAddressStringIsValidReturnTrue()
        {
        //Arrange
        var emailAddress = "oxo@oxo.com";
        //Act
        var result = ContactValidator.isEmailAddressValid(emailAddress);
        //Assert
        Assert.IsTrue(result);
        }
    [TestMethod]
    public void WhenEmailAddressStringIsNotValidReturnFalse()
        {
        //Arrange
        var emailAddress = "oxoatxoo.com";
        //Act
        var result = ContactValidator.isEmailAddressValid(emailAddress);
        //Assert
        Assert.IsFalse(result);
        }
    }



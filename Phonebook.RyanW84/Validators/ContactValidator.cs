using System.Text.RegularExpressions;

namespace Phonebook.RyanW84.Validators;

internal class ContactValidator
    {
    internal const string phoneMotif = @"^\+[1-9]\d{1,14}$";
    internal const string emailMotif = @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+";

    internal static bool isPhoneNumberValid(string phoneNumber)
        {
        if (phoneNumber != null)
            {
            return Regex.IsMatch(phoneNumber, phoneMotif);
            }
        else
            return false;
        }

    internal static bool isEmailAddressValid(string emailAddress)
        {
        if (emailAddress != null)
            {
            return Regex.IsMatch(emailAddress, emailMotif);
            }
        else
            return false;
        }


    }



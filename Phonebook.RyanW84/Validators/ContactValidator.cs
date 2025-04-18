using System.Text.RegularExpressions;

namespace Phonebook.RyanW84.Validators;

public class ContactValidator
    {
    public const string phoneMotif = @"^\+[1-9]\d{1,14}$";
    public const string emailMotif = @"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+";

    public static bool IsPhoneNumberValid(string phoneNumber)
        {
        if (phoneNumber != null)
            {
            return Regex.IsMatch(phoneNumber, phoneMotif);
            }
        else
            return false;
        }

    public static bool IsEmailAddressValid(string emailAddress)
        {
        if (emailAddress != null)
            {
            return Regex.IsMatch(emailAddress, emailMotif);
            }
        else
            return false;
        }
    }



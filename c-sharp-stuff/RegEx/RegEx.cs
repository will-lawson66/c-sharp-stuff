using System;
using System.Text.RegularExpressions;

namespace ReGex
{
    public class Utilities
    {
        public static bool IsPhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null) throw new ArgumentNullException(nameof(phoneNumber));
            var pattern = @"^[+(]{0,2}"
                          + @"\d{0,3}"
                          + @"[)\.\-\s]{0,3}"
                          + @"[()\-\d]{3,9}"
                          + @"[\s\d\-\.ext]{3,16}"
                          + @"$";
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.Match(phoneNumber, pattern, RegexOptions.IgnoreCase).Success;
        }
    }
}

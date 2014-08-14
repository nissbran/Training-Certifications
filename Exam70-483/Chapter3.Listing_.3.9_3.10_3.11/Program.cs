using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chapter3
{
    /// <summary>
    /// Using regular expressions 
    /// 
    /// A regular expression is a specific pattern used to parse and find matches in strings.
    /// A regular expression is sometimes called regex or regexp. Regular expressions are flexible. 
    /// For example, the regex ^(\(\d{3}\)|^\d{3}[.-]?)?\d{3}[.- ]?\d{4}$ matches North American telephone numbers
    /// with or without parentheses around the area code, and with or without hyphens or dots between the numbers. 
    /// 
    /// Regular expressions have a history of being hard to write and use. Luckily, a lot of patterns are already written by someone else.
    /// Websites such as http://regexlib.com/ contain a lot of examples that you can use or adapt to your own needs.
    /// Regular expressions can be useful when validating application input,
    /// reducing to a few lines of code what can take dozens or more with manual parsing. 
    /// Maybe you allow a user to use both slashes and dashes to input a valid date. Or you allow white space when entering a ZIP Code.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // -- Listing 3-11
            // This shows an example of using a RegEx expression to remove all excessive use of white space.
            // Every single space is allowed but multiple spaces are replaced with a single space.
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{2,}", options);

            string input = "1 2 3 4   5";
            string result = regex.Replace(input, " ");

            Console.WriteLine(result);
            Console.ReadLine();

            // Although regex looks more difficult than writing the validation code in plain C#, 
            // it’s definitely worth learning how it works.
            // A regular expression can dramatically simplify your code, 
            // and it’s worth examining if you are in a situation requiring validation. 
        }

        /// <summary>
        /// Manually validating a dutch ZIP Code
        /// </summary>
        static bool ValidateZipCode(string zipcode)
        {
            // Valid zipcodes: 1234AB | 1234 AB | 1001 AB

            if (zipcode.Length < 6) return false;

            string numberPart = zipcode.Substring(0, 4);
            int number;
            if (!int.TryParse(numberPart, out number)) return false;

            string characterPart = zipcode.Substring(4);

            if (numberPart.StartsWith("0")) return false;
            if (characterPart.Trim().Length < 2) return false;
            if (characterPart.Length == 3 && characterPart.Trim().Length != 2)
                return false;

            return true;
        }
        /// <summary>
        /// If you use a regular expression, the code is much shorter. 
        /// A regular expression that matches Dutch ZIP Codes is ^[1-9][0-9]{3}\s?[a-zA-Z]{2}$.
        /// You can use this pattern with the RegEx class that can be found in the System.Text.RegularExpressions namespace.
        /// </summary>
        static bool ValidateZipCodeRegEx(string zipCode)
        {
            Match match = Regex.Match(zipCode, @"^[1-9][0-9]{3}\s?[a-zA-Z]{2}$", RegexOptions.IgnoreCase);
            return match.Success;
        }
    }


}

using System;
using System.Text.RegularExpressions;

namespace Users.Core.Validations
{
    public class PasswordCharSequenceRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;
            Regex regexCharRang = new Regex(@"(.)\1{ 1,}");
            Match match = regexCharRang.Match(str);
            return !match.Success;
        }
    }
}

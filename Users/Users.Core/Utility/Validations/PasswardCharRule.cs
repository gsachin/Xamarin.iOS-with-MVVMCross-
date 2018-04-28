using System;
using System.Text.RegularExpressions;
using Users.Core.Validations;

namespace Users.Core.Validations
{
    public class PasswardCharRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }  

        public bool Check(T value)  
        {  
        if (value == null)  
        {  
            return false;  
        }  

        var str = value as string;  
            Regex regexCharRang = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{5,15}$");  
            Match match = regexCharRang.Match(str);
        return match.Success;  
    }  
    }
}

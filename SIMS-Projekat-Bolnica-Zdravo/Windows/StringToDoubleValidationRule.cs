using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace PrimerCas4.Validation
{
    public class StringToDoubleValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                Regex r = new Regex("[A-Z]{1}[a-z]+");              
                if (r.IsMatch((string)value))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Popuni lepo");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
    public class ValidationForNumber : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                Regex r = new Regex("\\+[0-9]{1,12}");
                if (r.IsMatch((string)value))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Popuni lepo");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }

    public class ValidationForAddress : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                Regex r = new Regex("[A-Z]{1}[a-z]+[1-9]+");
                if (r.IsMatch((string)value))
                    return ValidationResult.ValidResult;
                else
                    return new ValidationResult(false, "Popuni lepo");
            }
            catch
            {
                return new ValidationResult(false, "Unknown error occured.");
            }
        }
    }
}

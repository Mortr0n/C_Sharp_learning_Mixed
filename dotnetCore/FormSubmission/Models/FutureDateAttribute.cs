using System;
using System.ComponentModel.DataAnnotations;

namespace Validations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt;
            // safely unbox value to DateTime
            if(value is DateTime)
                dt = (DateTime)value;
            else
                return new ValidationResult("Invalid datetime");
            
            if(dt < DateTime.Now)
                return new ValidationResult("Date must be in the future");

            return ValidationResult.Success;
        }
    }
}


// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

// namespace FormSubmission.Models
// {
//     public class FutureDateAttribute : ValidationAttribute
//     {
//         // protected override ValidationResult? IsValid(DateTime dateTimeValue, ValidationContext validationContext)
//         // {
//         //     if(dateTimeValue < DateTime.Now){
//         //         return new ValidationResult("Date must be in the future.");
//         //     }
//         //     return ValidationResult.Success;
//         // }
//     }
// }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCVidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
        
            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success; // If you want to return successfull validation result, use "Success" static field.
            }

            if(customer.Birthday == null)
            {
                return new ValidationResult("Birthdate is required."); // In order to indicate an error, we instantiate a new validation result.
            }

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership.");
        }
    }
}
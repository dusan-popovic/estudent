using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace estudent.Models
{
    public class BIAttribute : ValidationAttribute
    {
        //private string BI;

        public BIAttribute(/*string BI*/)
        {
            //this.BI = BI;
        }

        //public ValidationResult IsValidEncapsulationBraker(object value, ValidationContext validationContext)
        //{
        //    return IsValid(value, validationContext);
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //Student student = (Student)validationContext.ObjectInstance;

            if(value==null)
                return new ValidationResult("Broj indeksa nije u adekvatnom obliku.");

            if (((string)value).Trim() != ((string)value))
                return new ValidationResult("Broj indeksa nije u adekvatnom obliku.");

            string[] parts = ((string)value).Split(new char[] { '/' });
            int year, num;

            if (parts.Length == 2 && int.TryParse(parts[0], out year) && int.TryParse(parts[1], out num) && ((year > 1950 && year <= 2050) || (year > 0 && year <= 99)) && num > 0 && num <= 5000)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Broj indeksa nije u adekvatnom obliku.");
        }
    }
}
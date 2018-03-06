using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NLTU_Labs.Models
{
    public class ConvertValue
    {
        public ConvertValue()
        {
            Value = "";
            Result = "";
        }

        public ConvertValue(string value, string result)
        {
            Value = value;
            Result = result;
        } 

        [MaxLength(50, ErrorMessage = "Value field can't be longer than 50 characters.")]
        [Required(ErrorMessage = "The value for converting can't be empty!")] 
        [Display(Name = "Enter value for converting: ")]
        public string Value { get; set; }

        public string Result { get; set; }
        [Display(Name = "Choose option type for converting: ")]
        public string OptionValue { get; set; }
    }
}
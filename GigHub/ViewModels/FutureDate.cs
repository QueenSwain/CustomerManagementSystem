using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class FutureDate:ValidationAttribute
    {
        public override bool IsValid(object value)   //value returns boolean value.So converting datetime to boolen
        {
            DateTime dateTime;
            var isValid=DateTime.TryParseExact(Convert.ToString(value),
                "MM/dd/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            //here out datetime will hold the output if user input is correcnt

            return (isValid && dateTime > DateTime.Now);
          
        }
    }

    
}
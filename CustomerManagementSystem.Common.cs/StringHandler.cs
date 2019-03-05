using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Common.cs
{
    public static class StringHandler
    {
        //public static string InsrtSpaces(tring Source)  //only static method 
        public static string InsrtSpaces(this string Source) //extension method
        {
            string result = string.Empty; //initializing result
            if (!String.IsNullOrWhiteSpace(Source)) //if string is not IsNullOrWhiteSpace 
            {
                foreach (Char letter in Source) //check all letters in source 
                {
                    if (Char.IsUpper(letter)) //if it finds an upper case letter then it inserts a space
                    {
                        //trim any space if already there
                        result = result.Trim();
                        result = result + " ";
                    }
                    result += letter; //process the result with all letters
                }
                result = result.Trim();
            }
            return result;
        }
    }
}

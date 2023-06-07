using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Rule
{
    public class Rule
    {
        //Grap Check 
        public static void IsValidUserID(int Id)
        {
            if (Id < 1)
            {
                throw new ArgumentException("userId");
            }
        }
   
         public static bool IsValidEmail(string email)
        {
            Regex validateEmailRegex = new Regex("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            if (validateEmailRegex.IsMatch(email))
            return true;
            
            else
             throw new ArgumentException("Valid email address");
        }
        public static bool isValidphone(string phone)
        {
            Regex validatePhoneNumberRegex = new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");
            if (validatePhoneNumberRegex.IsMatch(phone))
                return true;
            else
                throw new ArgumentException("Valid phone ");
            
        }
        public static bool isEqualstring(string str1,string str2)
        {
           if (str1.Equals(str2))
                return true;
           else

                return false;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailOTPModuleLibrary
{
    public class EmailService
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidDomain(string email)
        {
            int atIndex = email.IndexOf('@');
            if (atIndex == -1)
            {
                return false;
            }

            string domain = email.Substring(atIndex + 1);

            string pattern = @"(\.dso|\.org|\.sg)$";

            return Regex.IsMatch(domain, pattern, RegexOptions.IgnoreCase);
        }

        public bool send_email(string emailAddress, string emailBody)
        {
            // Placeholder: Assume email sending is implemented here
            return true;
        }
    }

}

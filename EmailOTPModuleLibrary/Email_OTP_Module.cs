using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailOTPModuleLibrary
{
    public class Email_OTP_Module
    {
        private readonly EmailService emailService;
        private readonly OTPService otpService;
        private readonly int maxTries = 10;

        public Email_OTP_Module()
        {
            emailService = new EmailService();
            otpService = new OTPService();
        }

        private string currentOTP;

        public void Start()
        {
            // Optional to implement
        }

        public void Close()
        {
            // Optional to implement
        }

        public int Generate_OTP_Email(string user_email)
        {
            if (!emailService.IsValidEmail(user_email))
            {
                return EmailOTPStatus.STATUS_EMAIL_INVALID;
            }

            if (!emailService.IsValidDomain(user_email))
            {
                return EmailOTPStatus.STATUS_EMAIL_INVALID;
            }

            currentOTP = otpService.GenerateOTP();

            string emailBody = $"Your OTP Code is {currentOTP}. The code is valid for 1 minute.";
            Console.WriteLine(emailBody);

            bool emailSent = emailService.send_email(user_email, emailBody);

            if (emailSent)
            {
                return EmailOTPStatus.STATUS_EMAIL_OK;
            }
            else
            {
                return EmailOTPStatus.STATUS_EMAIL_FAIL;
            }
        }

        public int Check_OTP(IOStream input)
        {
            int tries = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (tries < 10)
            {
                double remainingTime = 60 - stopwatch.Elapsed.TotalSeconds;

                if (remainingTime <= 0)
                {
                    return EmailOTPStatus.STATUS_OTP_TIMEOUT;
                }

                string userOTP = otpService.ReadOTPWithTimeout(input, remainingTime);

                if (userOTP == null)
                {
                    return EmailOTPStatus.STATUS_OTP_TIMEOUT;
                }

                if (otpService.IsOTPValid(userOTP))
                {
                    return EmailOTPStatus.STATUS_OTP_OK;
                }
                else
                {
                    Console.WriteLine("Invalid OTP!!!");
                    tries++;
                }
            }

            return EmailOTPStatus.STATUS_OTP_FAIL;
        }

        

    }

}

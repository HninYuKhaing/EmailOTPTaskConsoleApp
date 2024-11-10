using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPModuleLibrary
{
    public class OTPService
    {
        private string currentOTP;
        private DateTime otpGeneratedTime;
        private const int OtpTimeoutSeconds = 60;

        public string GenerateOTP()
        {
            Random rnd = new Random();
            int otp = rnd.Next(0, 999999);
            currentOTP = otp.ToString("D6");
            otpGeneratedTime = DateTime.Now;
            return currentOTP;
        }

        public bool IsOTPValid(string enteredOTP)
        {
            if (DateTime.Now.Subtract(otpGeneratedTime).TotalSeconds > OtpTimeoutSeconds)
            {
                return false;
            }
            return currentOTP == enteredOTP;
        }

        public string ReadOTPWithTimeout(IOStream input, double remainingTime)
        {
            string userOTP = null;

            try
            {
                Task<string> otpTask = Task.Run(() => input.readOTP());

                if (otpTask.Wait(TimeSpan.FromSeconds(remainingTime)))
                {
                    userOTP = otpTask.Result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }

            return userOTP;
        }

    }
}

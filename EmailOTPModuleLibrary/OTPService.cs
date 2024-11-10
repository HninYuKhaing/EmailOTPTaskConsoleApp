using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace EmailOTPModuleLibrary
{
    public class OTPService
    {
        private string hashedCurrentOTP;
        private DateTime otpGeneratedTime;
        private const int OtpTimeoutSeconds = 60;

        public string GenerateOTP()
        {
            Random rnd = new Random();
            int otp = rnd.Next(0, 999999);
            string currentOTP = otp.ToString("D6");
            otpGeneratedTime = DateTime.Now;
            hashedCurrentOTP = HashOTP(currentOTP);
            return currentOTP;
        }

        public string HashOTP(string otp)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(otp));
            return Convert.ToBase64String(bytes);
        }

        public bool IsOTPValid(string enteredOTP)
        {
            if (DateTime.Now.Subtract(otpGeneratedTime).TotalSeconds > OtpTimeoutSeconds)
            {
                return false;
            }
            string hashedEnteredOTP = HashOTP(enteredOTP);
            return hashedCurrentOTP == hashedEnteredOTP;
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

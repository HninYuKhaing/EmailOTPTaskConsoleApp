using EmailOTPModuleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPTaskConsoleApp
{
    public class ConsoleIOStream : IOStream
    {
        public string readOTP()
        {
            Console.Write("Enter your OTP: ");
            return Console.ReadLine();
        }
    }
}

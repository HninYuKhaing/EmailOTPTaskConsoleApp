using EmailOTPModuleLibrary;
using EmailOTPTaskConsoleApp;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Email_OTP_Module otpModule = new Email_OTP_Module();
        otpModule.Start();

        bool continueTesting = true;

        while (continueTesting)
        {
            Console.Write("Enter your email address (or type 'exit' to quit): ");
            string userEmail = Console.ReadLine();

            if (userEmail.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                continueTesting = false;
                break;
            }

            int emailStatus = otpModule.Generate_OTP_Email(userEmail);

            if (emailStatus == EmailOTPStatus.STATUS_EMAIL_OK)
            {
                Console.WriteLine("OTP sent successfully to your email.");

                IOStream input = new ConsoleIOStream();
                int otpStatus = otpModule.Check_OTP(input);

                if (otpStatus == EmailOTPStatus.STATUS_OTP_OK)
                {
                    Console.WriteLine("OTP verified successfully!");
                }
                else if (otpStatus == EmailOTPStatus.STATUS_OTP_FAIL)
                {
                    Console.WriteLine("Failed to verify OTP after maximum attempts.");
                }
                else if (otpStatus == EmailOTPStatus.STATUS_OTP_TIMEOUT)
                {
                    Console.WriteLine("OTP verification timed out.");
                }
            }
            else if (emailStatus == EmailOTPStatus.STATUS_EMAIL_INVALID)
            {
                Console.WriteLine("Invalid email address.");
            }
            else
            {
                Console.WriteLine("Failed to send OTP email.");
            }
        }

        otpModule.Close();
        Console.WriteLine("Program terminated.");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPModuleLibrary
{
    public static class EmailOTPStatus
    {
        public const int STATUS_EMAIL_OK = 0;
        public const int STATUS_EMAIL_FAIL = 1;
        public const int STATUS_EMAIL_INVALID = 2;

        public const int STATUS_OTP_OK = 0;
        public const int STATUS_OTP_FAIL = 1;
        public const int STATUS_OTP_TIMEOUT = 2;
    }
}

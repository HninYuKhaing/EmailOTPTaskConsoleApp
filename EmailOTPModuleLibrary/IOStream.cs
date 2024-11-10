using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPModuleLibrary
{
    public interface IOStream
    {
        string readOTP();
    }
}

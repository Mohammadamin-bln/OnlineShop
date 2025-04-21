using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.OtpService
{
    public interface IOtpService
    {
        public Task SendOtpAsync(string phoneNumber);
        public  Task<bool> VerifyOtpAsync(string phoneNumber, string otpCode);
    }
}
